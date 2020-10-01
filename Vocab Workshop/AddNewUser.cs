using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vocab_Workshop.Properties;

namespace Vocab_Workshop
{
    public partial class AddNewUser : Form
    {
        public UserProfile newUser = new UserProfile();
        private bool _valid;

        public AddNewUser()
        {
            InitializeComponent();
        }

        public AddNewUser(UserProfile temp) : this()
        {
            newUser = temp;
        }

        public UserProfile GetUser()
        {
            return newUser;
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            newUser = null;
            this.Close();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != string.Empty)
            {
                _valid = true;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != string.Empty)
            {
                newUser.UserName = textBoxUsername.Text;
                this.Close();
            }
        }
    }
}
