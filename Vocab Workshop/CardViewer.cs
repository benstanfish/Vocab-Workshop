using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace Vocab_Workshop
{
    public partial class CardViewer : Form
    {
        CardRing cardRing = new CardRing();
        CardRing needsWork = new CardRing();

        int currentCard = 0;
        int totalCards = 0;
        int startFace = 0;
        int currentFace = 0;
        
        public CardViewer()
        {
            InitializeComponent();

            labelStage.Text = "Please load a card ring.";
            

            progressBar1.Minimum = 0;
            progressBar1.Maximum = totalCards;
        }


        private void UpdateStage(string performer)
        {
            if(!String.IsNullOrEmpty(performer))
                labelStage.Text = performer;
        }

        private void NextCard()
        {
            if (currentCard == totalCards - 1) { currentCard = 0; }
            else { currentCard++; }

            TestImageAndUpdateStage(cardRing.cards[currentCard].Faces[currentFace]);

            //UpdateStage(cardRing.cards[currentCard].Faces[startFace]);
        }
        private void PreviousCard()
        {
            if (currentCard == 0) { currentCard = totalCards - 1; }
            else { currentCard--; }

            TestImageAndUpdateStage(cardRing.cards[currentCard].Faces[currentFace]);

            //UpdateStage(cardRing.cards[currentCard].Faces[startFace]);
        }

        private void NextFace()
        {
            if (currentFace == cardRing.cards[currentCard].Faces.Count - 1) { currentFace = 0; }
            else { currentFace++; }

            TestImageAndUpdateStage(cardRing.cards[currentCard].Faces[currentFace]);

            //UpdateStage(cardRing.cards[currentCard].Faces[currentFace]);
        }
        private void PreviousFace()
        {
            if (currentFace == 0) { currentFace = cardRing.cards[currentCard].Faces.Count - 1; }
            else { currentFace--; }

            TestImageAndUpdateStage(cardRing.cards[currentCard].Faces[currentFace]);

            //UpdateStage(cardRing.cards[currentCard].Faces[currentFace]);
        }

        private void UpdateProgressBar()
        {
            //progressBar1.Value = currentCard;
            //string temp = (currentCard + 1).ToString();
            //labelSetProgress.Text = "Progress: " + temp + " of " + totalCards.ToString();
        }

        private void AddToNeedsWord(Card needsWorkWord)
        {
            if (!needsWork.cards.Contains(needsWorkWord))
                needsWork.cards.Add(needsWorkWord);
            //listBoxNeedsWork.BeginUpdate();

            listBoxNeedsWork.DataSource = needsWork.cards.ToList();
            //listBoxNeedsWork.ClearSelected();

            //listBoxNeedsWork.EndUpdate();
        }



        private void KeyNavigation(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    AddToNeedsWord(cardRing.cards[currentCard]);
                    break;
                case Keys.Delete:
                    break;
                case Keys.Up:
                    NextFace();
                    break;
                case Keys.Down:
                    PreviousFace();
                    break;
                case Keys.Right:
                    NextCard();
                    break;
                case Keys.Left:
                    PreviousCard();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
            
            UpdateProgressBar();
        }

        private void CardViewer_KeyUp(object sender, KeyEventArgs e)
        {
            KeyNavigation(e);
            listBoxNeedsWork.ClearSelected();
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            Double ratio = Math.Min(ratioX, ratioY);
            ratio = ratio * 0.9;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void TestImageAndUpdateStage(string possiblePath)
        {
            if (File.Exists(possiblePath))
            {
                Image img = Image.FromFile(possiblePath);   
                Image newImg = ScaleImage(img, labelStage.Width, labelStage.Height);
                labelStage.Text = "";
                labelStage.Image = newImg;
            }
            else
            {
                labelStage.Image = null;
                UpdateStage(possiblePath);
            }
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


        private CardRing LoadCardSet(string myPath)
        {
            string myContents = File.ReadAllText(myPath);
            myContents = myContents.Replace('\n', '\r');
            string[] lines = myContents.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] thisLine = lines[i].Split('\t');
                Card card = new Card();
                for (int j = 0; j < thisLine.Length; j++)
                {
                    if (!string.IsNullOrWhiteSpace(thisLine[j].ToString()))
                        card.Faces.Add(thisLine[j].ToString());
                }
                cardRing.cards.Add(card);
            }

            totalCards = cardRing.cards.Count();
            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = totalCards - 1;
            return cardRing;
        }
        private void labelCurrentSet_Click(object sender, EventArgs e)
        {
            cardRing = LoadCardSet(GetCardFilePath());
            labelStage.Text = cardRing.cards[0].Faces[0];
        }

        private void listBoxNeedsWork_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(listBoxNeedsWork.SelectedIndex.ToString());
        }
    }
}
