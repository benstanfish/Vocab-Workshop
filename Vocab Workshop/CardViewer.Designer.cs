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
            this.progressBar1SetProgress = new System.Windows.Forms.ProgressBar();
            this.labelSetProgress = new System.Windows.Forms.Label();
            this.labelCurrentSet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStage
            // 
            this.labelStage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStage.Font = new System.Drawing.Font("Meiryo UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStage.Location = new System.Drawing.Point(12, 44);
            this.labelStage.Name = "labelStage";
            this.labelStage.Size = new System.Drawing.Size(776, 234);
            this.labelStage.TabIndex = 0;
            this.labelStage.Text = "label1";
            this.labelStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelStage_MouseClick);
            // 
            // progressBar1SetProgress
            // 
            this.progressBar1SetProgress.Location = new System.Drawing.Point(529, 10);
            this.progressBar1SetProgress.Name = "progressBar1SetProgress";
            this.progressBar1SetProgress.Size = new System.Drawing.Size(259, 23);
            this.progressBar1SetProgress.TabIndex = 1;
            // 
            // labelSetProgress
            // 
            this.labelSetProgress.AutoSize = true;
            this.labelSetProgress.Location = new System.Drawing.Point(458, 16);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // CardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCurrentSet);
            this.Controls.Add(this.labelSetProgress);
            this.Controls.Add(this.progressBar1SetProgress);
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
        private System.Windows.Forms.ProgressBar progressBar1SetProgress;
        private System.Windows.Forms.Label labelSetProgress;
        private System.Windows.Forms.Label labelCurrentSet;
        private System.Windows.Forms.Label label1;
    }
}

