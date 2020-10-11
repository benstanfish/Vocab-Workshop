using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;
using Timer = System.Timers.Timer;
using System.Reflection;


namespace Vocab_Workshop
{
    public partial class CardViewer : Form
    {
        
        CardSet cardSet = new CardSet();

        int currentCard = 0;
        int totalCards = 0;
        int startFace = 0;
        int currentFace = 0;
        int totalFaces = 0;
        int wrong = 0;
        int skipped = 0;
        int correct = 0;
        float defaultFontSize = 24;
        bool franticOn = false;
        int franticTime;
        int franticMax = 12;

        readonly System.Timers.Timer franticTimer = new System.Timers.Timer(1000);

        public CardViewer()
        {
            InitializeComponent();
            FontDefault();
            RefreshLabels();
            labelFrantic.Text = franticMax.ToString();
            labelStage.Text = "Please load a card set.";
        }

        private void UpdateStage(string performer)
        {
            if(!String.IsNullOrEmpty(performer))
                labelStage.Text = performer;
            totalFaces = cardSet.Cards[currentCard].Sides.Count;
            RefreshLabels();
        }

        private void NextCard()
        {
            if (currentCard == totalCards - 1) { currentCard = 0; }
            else { currentCard++; }

            totalFaces = cardSet.Cards[currentCard].Sides.Count;
            TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[startFace]);
        }
        private void PreviousCard()
        {
            if (currentCard == 0) { currentCard = totalCards -1; }
            else { currentCard--; }
            
            TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[startFace]);
        }

        private void NextFace()
        {
            if (currentFace == cardSet.Cards[currentCard].Sides.Count - 1) { currentFace = 0; }
            else { currentFace++; }

            TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[currentFace]);
        }
        private void PreviousFace()
        {
            if (currentFace == 0) { currentFace = cardSet.Cards[currentCard].Sides.Count - 1; }
            else { currentFace--; }

            TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[currentFace]);
        }

        private void KeyNavigation(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Delete:
                    PreviousCard();
                    break;
                case Keys.Space:
                    skipped++;
                    NextCard();
                    break;
                case Keys.Up:
                    NextFace();
                    break;
                case Keys.Down:
                    PreviousFace();
                    break;
                case Keys.Right:
                    wrong++;
                    FlashIncorrect();
                    NextCard();
                    break;
                case Keys.Left:
                    correct++;
                    FlashCorrect();
                    NextCard();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
            RefreshLabels();
            
        }


        private string SideType(int side)
        {
            switch (side)
            {
                case 0:
                    return "Front";
                    break;
                case 1:
                    return "Hint";
                    break;
                case 2:
                    return "Back";
                    break;
                case 3:
                    return "Image";
                    break;
                default:
                    return string.Empty;
            }
        }

        private void RefreshLabels()
        {
            labelForgot.Text = wrong.ToString();
            labelCleared.Text = correct.ToString();
            labelSkipped.Text = skipped.ToString();
            labelTotal.Text = totalCards.ToString();
            labelCard.Text = currentCard.ToString();
            labelSide.Text = SideType(currentFace); 
        }

        private void CardViewer_KeyUp(object sender, KeyEventArgs e)
        {
            KeyNavigation(e);
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
                try
                {
                    Image img = Image.FromFile(possiblePath);
                    Image newImg = ScaleImage(img, labelStage.Width, labelStage.Height);
                    labelStage.Text = "";
                    labelStage.Image = newImg;
                }
                catch (Exception)
                {
                } 
            }
            else
            {
                labelStage.Image = null;
                UpdateStage(possiblePath);
            }
        }

        private void FontDefault()
        {
           labelStage.Font = new Font(labelStage.Font.Name, defaultFontSize,
                labelStage.Font.Style, labelStage.Font.Unit);
        }
        private void FontIncrease()
        {
            var currentSize = labelStage.Font.Size;
            currentSize += 2.0F;
            labelStage.Font = new Font(labelStage.Font.Name, currentSize,
                labelStage.Font.Style, labelStage.Font.Unit);
        }

        private void FontDecrease()
        {
            var currentSize = labelStage.Font.Size;
            currentSize -= 2.0F;
            labelStage.Font = new Font(labelStage.Font.Name, currentSize,
                labelStage.Font.Style, labelStage.Font.Unit);
        }


        private string GetCardFilePath()
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Utilities.CardSetsFolder();
                //ofd.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    myPath = ofd.FileName;
                }
            }
            return myPath;
        }


        private CardSet LoadCardSet(string myPath)
        {
            //string myContents = File.ReadAllText(myPath);
            //myContents = myContents.Replace('\n', '\r');
            //string[] lines = myContents.Split(new char[] { '\r' },
            //    StringSplitOptions.RemoveEmptyEntries);

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] thisLine = lines[i].Split('\t');
            //    Card card = new Card();
            //    for (int j = 0; j < thisLine.Length; j++)
            //    {
            //        if (!string.IsNullOrWhiteSpace(thisLine[j].ToString()))
            //            card.Sides.Add(thisLine[j].ToString());
            //    }
            //    cardSet.Cards.Add(card);
            //}

            var cardSet = CardSet.Read(myPath);

            totalCards = cardSet.Cards.Count();
            return cardSet;
        }


        private void labelCurrentSet_Click(object sender, EventArgs e)
        {
            cardSet = LoadCardSet(GetCardFilePath());
            labelStage.Text = cardSet.Cards[0].Sides[0];
        }


        private void ColorLabel(Control control, Color color)
        {
            control.BackColor = color;

            var timer = new System.Timers.Timer();
            timer.Interval = 250;
            timer.Elapsed += ResetLabelColor;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        public void ResetLabelColor(Object source, System.Timers.ElapsedEventArgs e)
        {
            labelIncorrect.BackColor = Color.White;
            labelCorrect.BackColor = Color.White;
        }

        private void FlashIncorrect()
        {
            ColorLabel(labelIncorrect, Color.Tomato);
        }
        private void FlashCorrect()
        {
            ColorLabel(labelCorrect, Color.MediumAquamarine);
        }

        private void Home_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todo: Go to Main menu.");
        }

        private void LoadSet_Click(object sender, EventArgs e)
        {
            var path = GetCardFilePath();
            if (path != null)
            {
                cardSet = CardSet.Read(path);
                
            }
            if (cardSet != null && cardSet.Cards.Count > 0)
            {
                totalCards = cardSet.Cards.Count - 1;
                TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[startFace]);
            }
            
        }

        private void Shuffle_Click(object sender, EventArgs e)
        {
            cardSet.Cards.Shuffle();
        }

        private void Reverse_Click(object sender, EventArgs e)
        { 
            cardSet.Cards.Reverse();
        }

        private void FontIncrease_Click(object sender, EventArgs e)
        {
            FontIncrease();
        }

        private void FontDecrease_Click(object sender, EventArgs e)
        {
            FontDecrease();
        }

        private void FontDefault_Click(object sender, EventArgs e)
        {
            FontDefault();
        }

        private void FranticMode_Click(object sender, EventArgs e)
        {
            franticOn = !franticOn;
            if (franticOn)
            {
                pictureBoxFrantic.BackColor = Color.Aquamarine;
                franticTime = franticMax;
                timerFrantic.Enabled = true;
            }
            else
            {
                timerFrantic.Enabled = false;
                franticTime = franticMax;
                pictureBoxFrantic.BackColor = Color.White;
                labelFrantic.Text = franticTime.ToString();
                labelFrantic.ForeColor = Color.Black;
                labelStage.BackColor = Color.White;
            }
        }

        private void timerFrantic_Tick_1(object sender, EventArgs e)
        {
            if (franticTime >= 0)
            {
                if (franticTime < 11)
                {
                    labelFrantic.ForeColor = Color.Tomato;
                    labelStage.BackColor = Color.LightPink;
                }
                labelFrantic.Text = (franticTime--).ToString();
            }
            else
            {
                labelFrantic.ForeColor = Color.Black;
                labelStage.BackColor = Color.White;
                franticTime = franticMax;
            }

        }
    }
}
