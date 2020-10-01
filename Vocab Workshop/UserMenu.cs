using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocab_Workshop.Properties
{
    public partial class UserMenu : Form
    {
        private int starCount = 0;
        private int lifetimeCards = 0;
        Image emptyStar = Resources.baseline_star_border_black_18dp;
        Image halfStar = Resources.baseline_star_half_black_18dp;
        Image solidStar = Resources.baseline_star_black_18dp;
        Image prettyStar = Resources.baseline_stars_black_18dp;
        Image medal = Resources.baseline_military_tech_black_18dp;
        private string _userPath;
        private string _defaultUserPath = ProjectFolders.ConfigFolder("Users.xml");
        public UserGroup CurrentUsers = new UserGroup();
        BindingSource binding = new BindingSource();
        private bool updatesSaved;
        private bool updatesMade;

        public UserMenu()
        {
            InitializeComponent();
            _userPath = _defaultUserPath;
            LoadUsers();
            UpdateStars(starCount);
            labelLifetimeCards.Text = lifetimeCards.ToString();
            updatesMade = false;
        }

        public void ResetUserPath()
        {
            _userPath = _defaultUserPath;
        }

        private void TestUserFileExists()
        {
            if (!File.Exists(_userPath))
            {
                CurrentUsers.Users.Add(new UserProfile(){UserName = "Please add a username."});
                CurrentUsers.WriteXml(_userPath);
            }
        }

        public void LoadUsers()
        {
            try
            {
                TestUserFileExists();
                CurrentUsers = UserGroup.ReadXml(_userPath);
                if (CurrentUsers != null && CurrentUsers.Users.Count != 0)
                {
                    binding.DataSource = CurrentUsers.Users;
                    listBoxUserProfiles.DataSource = binding;
                }
               
            }
            catch (Exception)
            {
                listBoxUserProfiles.Items.Add("Error reading file. Check XML syntax.");
                listBoxUserProfiles.Enabled = false;
            }

        }

        public void UpdateStars(int stars)
        {
            switch (stars)
            {
                case 1:
                    star1.Image = halfStar;
                    star2.Image = emptyStar;
                    star3.Image = emptyStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 2:
                    star1.Image = solidStar;
                    star2.Image = emptyStar;
                    star3.Image = emptyStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 3:
                    star1.Image = solidStar;
                    star2.Image = halfStar;
                    star3.Image = emptyStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 4:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = emptyStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 5:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = halfStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 6:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 7:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = halfStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 8:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = solidStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 9:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = solidStar;
                    star5.Image = halfStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 10:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = solidStar;
                    star5.Image = solidStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;
                case 11:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = solidStar;
                    star5.Image = solidStar;
                    otherRating.Image = prettyStar;
                    otherAward.Image = null;
                    break;
                case 12:
                    star1.Image = solidStar;
                    star2.Image = solidStar;
                    star3.Image = solidStar;
                    star4.Image = solidStar;
                    star5.Image = solidStar;
                    otherRating.Image = prettyStar;
                    otherAward.Image = medal;
                    break;
                default:
                    star1.Image = emptyStar;
                    star2.Image = emptyStar;
                    star3.Image = emptyStar;
                    star4.Image = emptyStar;
                    star5.Image = emptyStar;
                    otherRating.Image = null;
                    otherAward.Image = null;
                    break;

            }
        }

        private void listBoxUserProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listBoxUserProfiles.SelectedIndex;
            if (selected > -1)
            {
                textBoxUserName.Text = CurrentUsers.Users[selected].UserName;
                textBoxUserId.Text = CurrentUsers.Users[selected].Id;
                listBoxUsageHistory.DataSource = CurrentUsers.Users[selected].SignIns;
                labelLifetimeCards.Text = CurrentUsers.Users[selected].LifetimeCards.ToString();
            }
            
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            int selected = listBoxUserProfiles.SelectedIndex;
            if (selected > -1)
            {
                CurrentUsers.Users[selected].UserName = textBoxUserName.Text;
                binding.ResetBindings(false);
                updatesMade = true;
            }
            
        }

        private string GetFilePath()
        {
            var filePath = string.Empty;
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = _userPath;
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }
            return filePath;
        }

        private void OpenProfiles_Click(object sender, EventArgs e)
        {
            var temp = GetFilePath();
            if (temp != string.Empty && File.Exists(temp))
            {
                _userPath = temp;
            }
            LoadUsers();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            var newUserForm = new AddNewUser();
            newUserForm.ShowDialog();
            if (newUserForm.newUser != null && newUserForm.newUser.UserName != string.Empty)
            {
                CurrentUsers.Users.Add(newUserForm.newUser);
                listBoxUserProfiles.SelectedIndex = -1;
                updatesMade = true;
            };
        }

        private void RemoveUser_Click(object sender, EventArgs e)
        {
            if (listBoxUserProfiles.SelectedIndex > -1)
            {
                CurrentUsers.Users.RemoveAt(listBoxUserProfiles.SelectedIndex);
                binding.ResetBindings(false);
                updatesMade = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            CurrentUsers.WriteXml(_userPath);
            updatesSaved = true;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            if (updatesMade == true && updatesSaved == false)
            {
                var dialogResult = MessageBox.Show("Do you want to save changes?","Unsaved Changes",MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    CurrentUsers.WriteXml(_userPath);
                    updatesSaved = true;
                    this.Close();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void DefaultUserPath_Click(object sender, EventArgs e)
        {
            ResetUserPath();
            LoadUsers();
        }
    }
}
