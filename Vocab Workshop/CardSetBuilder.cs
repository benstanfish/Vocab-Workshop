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
using System.Runtime.InteropServices;

namespace Vocab_Workshop
{
    

    public partial class CardSetEditor : Form
    {
        public CardSet cardSet = new CardSet();
        

        public CardSetEditor(CardSet aSet = null)
        {
            InitializeComponent();

            if (aSet != null)
            {
                MessageBox.Show("Non-null Card Set");
                cardSet = aSet;
            }
            else
            {
                var xmlSet = CardSet.ReadXml(@"C:\Users\benst\Documents\Vocab Workshop\Card Sets\N1 Vocabulary List 2020 v1.xml");

                

                //foreach (Card card in xmlSet.Cards)
                //{
                //    bs.Add(card.Sides.ToList());
                //}

                var bindingList = new BindingList<Card>(xmlSet.Cards);
                
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AutoSize = true;
                dataGridView1.DataSource = new BindingSource(bindingList,null);
            }

        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Add(cardSet.Cards.Count-1);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < cardSet.Cards[i].Sides.Count; j++)
                {
                    dataGridView1[j, i].Value = cardSet.Cards[i].Sides[j];
                }
            }
        }


        private string GetFilePath()
        {
            var filePath = string.Empty;

            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }
            return filePath;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView1.CurrentCell.Value = GetFilePath();
                dataGridView1.EndEdit();
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

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
