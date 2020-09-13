using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Vocab_Workshop
{
    public partial class CardViewer : Form
    {

        string[,] cardSet;
        int currentCard = 0;
        int currentSide = 0;
        string front = "Front";
        string middle = "Middle";
        string back = "Back";

        public CardViewer()
        {
            InitializeComponent();
            labelStage.Text = front;
        }



        private void CycleForward()
        {
            switch (currentSide)
            {
                case 0:
                    GotoMiddle();
                    currentSide = 1;
                    break;
                case 1:
                    GotoBack();
                    currentSide = 2;
                    break;
                case 2:
                    GotoFront();
                    currentSide = 0;
                    break;
                default:
                    break;
            }
        }
        private void CycleBack()
        {
            switch (currentSide)
            {
                case 0:
                    GotoBack();
                    currentSide = 2;
                    break;
                case 1:
                    GotoFront();
                    currentSide = 0;
                    break;
                case 2:
                    GotoMiddle();
                    currentSide = 1;
                    break;
                default:
                    break;
            }
        }

        private void GotoFront()
        {
            //labelStage.Text = front;
            labelStage.Text = cardSet[currentCard, 0];
        }
        private void GotoBack()
        {
            //labelStage.Text = back;
            labelStage.Text = cardSet[currentCard, 2];
        }
        private void Newbie()
        {

        }

        private void GotoMiddle()
        {
            //labelStage.Text = middle;
            if (cardSet[currentCard, 1] == string.Empty) { labelStage.Text = cardSet[currentCard, 0]; }
            else { labelStage.Text = cardSet[currentCard, 1]; }
            
        }

        private void labelStage_MouseClick(object sender, MouseEventArgs e)
        {
            CycleForward();
        }

        private void KeyNavigation(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    CycleForward();
                    break;
                case Keys.Down:
                    CycleBack();
                    break;
                case Keys.Right:
                    if(currentCard >= 0 && currentCard < cardSet.Length) { currentCard++; }
                    else { currentCard = 0; }
                    labelStage.Text = cardSet[currentCard, 0];
                    break;
                case Keys.Left:
                    if (currentCard > 0 && currentCard <= cardSet.Length) { currentCard--; }
                    else { currentCard = cardSet.Length; }
                    labelStage.Text = cardSet[currentCard, 0];
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void CardViewer_KeyUp(object sender, KeyEventArgs e)
        {
            KeyNavigation(e);
        }


        private string GetCardFilePath()
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = myPath;
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 13;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    myPath = ofd.FileName;
                }
            }
            return myPath;
        }

        private string[,] LoadCardSet(string myPath)
        {
            
            string myContents = File.ReadAllText(myPath);
            myContents = myContents.Replace('\n', '\r');
            string[] lines = myContents.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            int myRows = lines.Length;
            int myCols = lines[0].Split('\t').Length;

            string[,] vals = new String[myRows, myCols];
            for (int i = 0; i < myRows; i++)
            {
                string[] line_i = lines[i].Split('\t');
                for (int j = 0; j < myCols; j++)
                {
                    vals[i, j] = line_i[j];
                }
            }
            return vals;
        }


        private void labelCurrentSet_Click(object sender, EventArgs e)
        {
            cardSet = LoadCardSet(GetCardFilePath());
            labelStage.Text = cardSet[currentCard,0];
        }
    }
}
