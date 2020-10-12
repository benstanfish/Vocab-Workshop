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
        int franticMax = 10;
        int franticAlert = 5;
        //readonly System.Timers.Timer franticTimer = new System.Timers.Timer(1000);

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

            franticTime = franticMax;
            ResetFranticTime();
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
                case 1:
                    return "Hint";
                case 2:
                    return "Back";
                case 3:
                    return "Image";
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


        private void TestImageAndUpdateStage(string possiblePath)
        {
            if (File.Exists(possiblePath))
            {
                try
                {
                    Image img = Image.FromFile(possiblePath);
                    Image newImg = Utilities.ScaleImage(img, labelStage.Width, labelStage.Height);
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
            if (currentSize > 60F)
                currentSize = 60F;
            labelStage.Font = new Font(labelStage.Font.Name, currentSize,
                labelStage.Font.Style, labelStage.Font.Unit);
        }
        private void FontDecrease()
        {
            var currentSize = labelStage.Font.Size;
            currentSize -= 2.0F;
            if (currentSize < 12F)
                currentSize = 12F;
            labelStage.Font = new Font(labelStage.Font.Name, currentSize,
                labelStage.Font.Style, labelStage.Font.Unit);
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void LoadSet_Click(object sender, EventArgs e)
        {
            var path = Utilities.LoadCardSetFile();
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

        private void ColorLabel(Control control, Color color)
        {
            control.BackColor = color;
            var timer = new System.Timers.Timer();
            timer.Interval = 250;   // length of time the label is colored
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

        private void ResetFranticTime()
        {
            timerFrantic.Stop();
            labelFrantic.ForeColor = Color.Black;
            labelStage.BackColor = Color.White;
            franticTime = franticMax;
            timerFrantic.Start();
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

        private void timerFrantic_Tick(object sender, EventArgs e)
        {
            if (franticTime >= 0)
            {
                if (franticTime < franticAlert)
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
