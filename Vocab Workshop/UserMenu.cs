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
        

        public UserMenu()
        {
            InitializeComponent();
            UpdateStars(starCount);
            labelLifetimeCards.Text = lifetimeCards.ToString();
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

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateStars(hScrollBar1.Value);
        }
    }
}
