using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace Vocab_Workshop
{


    public partial class CardViewer : Form
    {
        CardSet cardSet = new CardSet();
        CardSet needsWork = new CardSet();

        int currentCard = 0;
        int totalCards = 0;
        int startFace = 0;
        int currentFace = 0;
        
        public CardViewer()
        {
            InitializeComponent();
            labelStage.Text = "Please load a card ring.";
        }

        private void WriteXml()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text.xml";
            var xml = new DataContractSerializer(typeof(CardSet));
            using (var writer = new FileStream(filePath, FileMode.Create))
            {
                xml.WriteObject(writer, cardSet);
                MessageBox.Show(filePath + " done!");
            }

        }

        private void ReadXml(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(CardSet));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                cardSet = (CardSet)serializer.ReadObject(reader);
            }
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
                case Keys.Space:
                    PreviousCard();
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
                    FlashIncorrect();
                    NextCard();
                    break;
                case Keys.Left:
                    FlashCorrect();
                    NextCard();
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

        //private string TestWebImage(string possibleUrl)
        //{
        //    string tempPath = "";
        //    if (possibleUrl.Contains("http"))
        //    {
                
        //        string tempFolder = Path.GetTempPath();
        //        tempPath = tempFolder + @"\tempImage.jpeg";
                
        //        using (WebClient webClient = new WebClient())
        //        {
        //            byte[] data = webClient.DownloadData(possibleUrl);

        //            using (MemoryStream mem = new MemoryStream(data))
        //            {
        //                using (Image yourImage = Image.FromStream(mem))
        //                {
        //                    // If you want it as Png
        //                    //yourImage.Save(tempPath, ImageFormat.Png);

        //                    // If you want it as Jpeg
        //                    yourImage.Save(tempPath, ImageFormat.Jpeg);
        //                }
        //            }

        //        }
        //        return tempPath;
        //    }
        //    else
        //    {
        //        return possibleUrl;
        //    }
            
        //}


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


        private CardSet LoadCardSet(string myPath)
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
                        card.Sides.Add(thisLine[j].ToString());
                }
                cardSet.Cards.Add(card);
            }

            totalCards = cardSet.Cards.Count();

            // cardSet.Cards.Shuffle();
            return cardSet;
        }
        private void labelCurrentSet_Click(object sender, EventArgs e)
        {
            cardSet = LoadCardSet(GetCardFilePath());
            labelStage.Text = cardSet.Cards[0].Sides[0];
        }

        private void listBoxNeedsWork_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(listBoxNeedsWork.SelectedIndex.ToString());
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

        private void DrawAGreenRect()
        {
            //SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics;
            var myRect = new Rectangle(0, 0, 25, 600);
            LinearGradientBrush linGreenBrush = new LinearGradientBrush(
               myRect,
               Color.FromArgb(255, 60, 179, 113),   // Medium Sea Green
               Color.FromArgb(0, 60, 179, 113),      
               0f);  
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(linGreenBrush, myRect);
            linGreenBrush.Dispose();
            formGraphics.Dispose();
           
        }
        private void DrawARedRect()
        {
            //SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics;
            var myRect = new Rectangle(560, 0, 30, 600);
            LinearGradientBrush linGreenBrush = new LinearGradientBrush(
               myRect,
               Color.FromArgb(0, 255, 99, 71),   // Tomato
               Color.FromArgb(255, 255, 99, 71),      
               0f);  
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(linGreenBrush, myRect);
            linGreenBrush.Dispose();
            formGraphics.Dispose();
        }

        public void ResetLabelColor(Object source, System.Timers.ElapsedEventArgs e)
        {
            labelIncorrect.BackColor = Control.DefaultBackColor;
            labelCorrect.BackColor = Control.DefaultBackColor;
        }

        private void FlashIncorrect()
        {
            ColorLabel(labelIncorrect, Color.Tomato);
        }
        private void FlashCorrect()
        {
            ColorLabel(labelCorrect, Color.DodgerBlue);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WriteXml();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ReadXml(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text2.xml");
            totalCards = cardSet.Cards.Count - 1;
            TestImageAndUpdateStage(cardSet.Cards[currentCard].Sides[startFace]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var editor = new CardSetEditor(cardSet);
            editor.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
