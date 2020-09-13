using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocab_Workshop
{
    public partial class Startup : Form
    {
        private int iProgressBarValue = 0;
        public Startup()
        {
            InitializeComponent();
   
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = "Vocabulary Workshop";
            
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = System.String.Format(
                "Version {0}.{1:00}", version.Major, version.Minor);

            labelCopyright.Text = GetCopyrightInfo();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
            progressBar1.Value = 0;

            timer1.Enabled = true;
            timer1.Interval = 300;
            timer1.Start();
        }

        private string GetCopyrightInfo()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Object[] obj = asm.GetCustomAttributes(false);

            foreach (object ob in obj)
            {
                if (ob.GetType() == typeof(System.Reflection.AssemblyCopyrightAttribute))
                {
                    System.Reflection.AssemblyCopyrightAttribute aca = (System.Reflection.AssemblyCopyrightAttribute)ob;
                    return aca.Copyright ;
                }
            }
            return string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iProgressBarValue++;
            switch (iProgressBarValue)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    progressBar1.Value = (iProgressBarValue * 100);
                    break;
                case 2:
                case 4:
                case 6:
                case 8:
                case 10:
                    progressBar1.Value = (iProgressBarValue * 100);
                    break;
                case 13:
                    timer1.Stop();
                    timer1.Enabled = false;

                    this.Hide();
                    break;
                default:
                    break;
            }
        }
    }
}
