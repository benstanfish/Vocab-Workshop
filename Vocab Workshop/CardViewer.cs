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
        string front = "Front";
        string middle = "middle";
        string back = "back";
        int currentSide = 0;
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
            labelStage.Text = front;
        }
        private void GotoBack()
        {
            labelStage.Text = back;
        }
        private void GotoMiddle()
        {
            labelStage.Text = middle;
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
            }
        }

        private void CardViewer_KeyUp(object sender, KeyEventArgs e)
        {
            KeyNavigation(e);
        }
    }
}
