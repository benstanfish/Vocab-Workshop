﻿namespace Vocab_Workshop
{
    partial class CardSetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardSetEditor));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Side1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxNewSetTitle = new System.Windows.Forms.TextBox();
            this.labelSetTitle = new System.Windows.Forms.Label();
            this.labelCardList = new System.Windows.Forms.Label();
            this.textBoxCardSetDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Side1,
            this.Side2,
            this.Side3,
            this.Side4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(945, 516);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellContentClick);
            
            // 
            // Side1
            // 
            this.Side1.HeaderText = "Entry";
            this.Side1.MinimumWidth = 6;
            this.Side1.Name = "Side1";
            // 
            // Side2
            // 
            this.Side2.HeaderText = "Reading";
            this.Side2.MinimumWidth = 6;
            this.Side2.Name = "Side2";
            // 
            // Side3
            // 
            this.Side3.HeaderText = "Meaning";
            this.Side3.MinimumWidth = 6;
            this.Side3.Name = "Side3";
            // 
            // Side4
            // 
            this.Side4.HeaderText = "Image Path (Optional)";
            this.Side4.MinimumWidth = 6;
            this.Side4.Name = "Side4";
            // 
            // textBoxNewSetTitle
            // 
            this.textBoxNewSetTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNewSetTitle.Location = new System.Drawing.Point(15, 33);
            this.textBoxNewSetTitle.Name = "textBoxNewSetTitle";
            this.textBoxNewSetTitle.Size = new System.Drawing.Size(409, 22);
            this.textBoxNewSetTitle.TabIndex = 1;
            this.textBoxNewSetTitle.Validated += new System.EventHandler(this.textBoxNewSetTitle_Validated);
            // 
            // labelSetTitle
            // 
            this.labelSetTitle.AutoSize = true;
            this.labelSetTitle.Location = new System.Drawing.Point(9, 13);
            this.labelSetTitle.Name = "labelSetTitle";
            this.labelSetTitle.Size = new System.Drawing.Size(60, 17);
            this.labelSetTitle.TabIndex = 2;
            this.labelSetTitle.Text = "Set Title";
            // 
            // labelCardList
            // 
            this.labelCardList.AutoSize = true;
            this.labelCardList.Location = new System.Drawing.Point(12, 204);
            this.labelCardList.Name = "labelCardList";
            this.labelCardList.Size = new System.Drawing.Size(64, 17);
            this.labelCardList.TabIndex = 5;
            this.labelCardList.Text = "Card List";
            // 
            // textBoxCardSetDescription
            // 
            this.textBoxCardSetDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCardSetDescription.Location = new System.Drawing.Point(12, 89);
            this.textBoxCardSetDescription.Multiline = true;
            this.textBoxCardSetDescription.Name = "textBoxCardSetDescription";
            this.textBoxCardSetDescription.Size = new System.Drawing.Size(409, 102);
            this.textBoxCardSetDescription.TabIndex = 6;
            this.textBoxCardSetDescription.Validated += new System.EventHandler(this.textBoxCardSetDescription_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Description (Optional)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(882, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CardSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 752);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCardSetDescription);
            this.Controls.Add(this.labelCardList);
            this.Controls.Add(this.labelSetTitle);
            this.Controls.Add(this.textBoxNewSetTitle);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CardSetEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Set Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxNewSetTitle;
        private System.Windows.Forms.Label labelSetTitle;
        private System.Windows.Forms.Label labelCardList;
        private System.Windows.Forms.TextBox textBoxCardSetDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side4;
        private System.Windows.Forms.Button button1;
    }
}