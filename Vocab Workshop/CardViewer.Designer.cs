﻿namespace Vocab_Workshop
{
    partial class CardViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardViewer));
            this.labelStage = new System.Windows.Forms.Label();
            this.labelCurrentSet = new System.Windows.Forms.Label();
            this.labelIncorrect = new System.Windows.Forms.Label();
            this.labelCorrect = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStage
            // 
            this.labelStage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStage.Font = new System.Drawing.Font("Meiryo UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStage.Location = new System.Drawing.Point(60, 94);
            this.labelStage.Name = "labelStage";
            this.labelStage.Size = new System.Drawing.Size(925, 492);
            this.labelStage.TabIndex = 0;
            this.labelStage.Text = "Stage";
            this.labelStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentSet
            // 
            this.labelCurrentSet.AutoSize = true;
            this.labelCurrentSet.Location = new System.Drawing.Point(15, 11);
            this.labelCurrentSet.Name = "labelCurrentSet";
            this.labelCurrentSet.Size = new System.Drawing.Size(135, 17);
            this.labelCurrentSet.TabIndex = 3;
            this.labelCurrentSet.Text = "Current Set: \"Name\"";
            this.labelCurrentSet.Click += new System.EventHandler(this.labelCurrentSet_Click);
            // 
            // labelIncorrect
            // 
            this.labelIncorrect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncorrect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIncorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelIncorrect.Location = new System.Drawing.Point(991, 94);
            this.labelIncorrect.Name = "labelIncorrect";
            this.labelIncorrect.Size = new System.Drawing.Size(39, 492);
            this.labelIncorrect.TabIndex = 5;
            this.labelIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCorrect
            // 
            this.labelCorrect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCorrect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.labelCorrect.Location = new System.Drawing.Point(15, 94);
            this.labelCorrect.Name = "labelCorrect";
            this.labelCorrect.Size = new System.Drawing.Size(39, 492);
            this.labelCorrect.TabIndex = 6;
            this.labelCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vocab_Workshop.Properties.Resources.ic_casino_black_48dp;
            this.pictureBox1.Location = new System.Drawing.Point(687, 612);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCurrentSet);
            this.Controls.Add(this.labelCorrect);
            this.Controls.Add(this.labelIncorrect);
            this.Controls.Add(this.labelStage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CardViewer";
            this.Text = "CardViewer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardViewer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStage;
        private System.Windows.Forms.Label labelCurrentSet;
        private System.Windows.Forms.Label labelIncorrect;
        private System.Windows.Forms.Label labelCorrect;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

