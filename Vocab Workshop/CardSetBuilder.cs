using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;

namespace Vocab_Workshop
{
    public partial class CardSetEditor : Form
    {
        public CardSet cardSet = new CardSet();

        public CardSetEditor()
        {
            InitializeComponent();
        }


        public string ReturnPath()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView1.CurrentCell.Value = ReturnPath();
            }
        }

        private void textBoxNewSetTitle_Validated(object sender, EventArgs e)
        {
            cardSet.Title = textBoxNewSetTitle.Text;
        }

        private void textBoxCardSetDescription_Validated(object sender, EventArgs e)
        {
            cardSet.Description = textBoxCardSetDescription.Text;
        }

        private void UpdateCardSet()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows){
                Card card = new Card();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (dataGridView1[column.Index, row.Index].Value != null)
                        card.Sides.Add(dataGridView1[column.Index, row.Index].Value.ToString().ToLower());
                }
                cardSet.Cards.Add(card);
            }
        }


        private void WriteXml()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text2.xml";
            //XmlSerializer xml = new XmlSerializer(typeof(CardSet));
            var xml = new DataContractSerializer(typeof(CardSet));
            using (var writer = new FileStream(filePath, FileMode.Create))
            {
                
                xml.WriteObject(writer, cardSet);

                MessageBox.Show(filePath + " completed.");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateCardSet();
            WriteXml();
        }
    }
}
