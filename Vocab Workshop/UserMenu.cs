using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocab_Workshop.Properties
{
    public partial class UserMenu : Form
    {
        private int starCount = 0;
        private int lifetimeCards = 1000;
        Image emptyStar = Resources.baseline_star_border_black_18dp;
        Image halfStar = Resources.baseline_star_half_black_18dp;
        Image solidStar = Resources.baseline_star_black_18dp;
        Image prettyStar = Resources.baseline_stars_black_18dp;
        Image medal = Resources.baseline_military_tech_black_18dp;
        private string userPath = ProjectFolders.ConfigFolder("Users.xml");
        public UserGroup CurrentUsers;
        BindingSource binding = new BindingSource();

        public UserMenu()
        {
            InitializeComponent();
            LoadUsers();
            UpdateStars(starCount);
            labelLifetimeCards.Text = lifetimeCards.ToString();
        }

        public void LoadUsers()
        {
            try
            {
                CurrentUsers = UserGroup.ReadXml(userPath);
                if (CurrentUsers != null && CurrentUsers.Users.Count != 0)
                {
                    binding.DataSource = CurrentUsers.Users;
                    listBoxUserProfiles.DataSource = binding;
                }
               
            }
            catch (Exception e)
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
            }

        }

        private void OpenProfiles_Click(object sender, EventArgs e)
        {

        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            var newUserForm = new AddNewUser();
            newUserForm.ShowDialog();
            if (newUserForm.newUser != null && newUserForm.newUser.UserName != string.Empty)
            {
                CurrentUsers.Users.Add(newUserForm.newUser);
                listBoxUserProfiles.SelectedIndex = 1;
            };
            

        }

        private void RemoveUser_Click(object sender, EventArgs e)
        {
            if (listBoxUserProfiles.SelectedIndex > -1)
            {
                CurrentUsers.Users.RemoveAt(listBoxUserProfiles.SelectedIndex);
                binding.ResetBindings(false);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            CurrentUsers.WriteXml(userPath);
            this.Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
