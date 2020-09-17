namespace Vocab_Workshop
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelSetProgress = new System.Windows.Forms.Label();
            this.labelCurrentSet = new System.Windows.Forms.Label();
            this.listBoxNeedsWork = new System.Windows.Forms.ListBox();
            this.labelNeedsWork = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStage
            // 
            this.labelStage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStage.Font = new System.Drawing.Font("Meiryo UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStage.Location = new System.Drawing.Point(12, 36);
            this.labelStage.Name = "labelStage";
            this.labelStage.Size = new System.Drawing.Size(776, 234);
            this.labelStage.TabIndex = 0;
            this.labelStage.Text = "label1";
            this.labelStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(529, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // labelSetProgress
            // 
            this.labelSetProgress.AutoSize = true;
            this.labelSetProgress.Location = new System.Drawing.Point(381, 16);
            this.labelSetProgress.Name = "labelSetProgress";
            this.labelSetProgress.Size = new System.Drawing.Size(65, 17);
            this.labelSetProgress.TabIndex = 2;
            this.labelSetProgress.Text = "Progress";
            // 
            // labelCurrentSet
            // 
            this.labelCurrentSet.AutoSize = true;
            this.labelCurrentSet.Location = new System.Drawing.Point(12, 16);
            this.labelCurrentSet.Name = "labelCurrentSet";
            this.labelCurrentSet.Size = new System.Drawing.Size(135, 17);
            this.labelCurrentSet.TabIndex = 3;
            this.labelCurrentSet.Text = "Current Set: \"Name\"";
            this.labelCurrentSet.Click += new System.EventHandler(this.labelCurrentSet_Click);
            // 
            // listBoxNeedsWork
            // 
            this.listBoxNeedsWork.FormattingEnabled = true;
            this.listBoxNeedsWork.ItemHeight = 16;
            this.listBoxNeedsWork.Location = new System.Drawing.Point(12, 322);
            this.listBoxNeedsWork.Name = "listBoxNeedsWork";
            this.listBoxNeedsWork.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxNeedsWork.Size = new System.Drawing.Size(241, 212);
            this.listBoxNeedsWork.TabIndex = 0;
            this.listBoxNeedsWork.TabStop = false;
            this.listBoxNeedsWork.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardViewer_KeyUp);
            // 
            // labelNeedsWork
            // 
            this.labelNeedsWork.AutoSize = true;
            this.labelNeedsWork.Location = new System.Drawing.Point(9, 302);
            this.labelNeedsWork.Name = "labelNeedsWork";
            this.labelNeedsWork.Size = new System.Drawing.Size(90, 17);
            this.labelNeedsWork.TabIndex = 5;
            this.labelNeedsWork.Text = "Needs Work:";
            // 
            // CardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.labelNeedsWork);
            this.Controls.Add(this.listBoxNeedsWork);
            this.Controls.Add(this.labelCurrentSet);
            this.Controls.Add(this.labelSetProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelStage);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CardViewer";
            this.Text = "CardViewer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardViewer_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelSetProgress;
        private System.Windows.Forms.Label labelCurrentSet;
        private System.Windows.Forms.ListBox listBoxNeedsWork;
        private System.Windows.Forms.Label labelNeedsWork;
    }
}

