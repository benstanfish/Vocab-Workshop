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
            this.SuspendLayout();
            // 
            // labelStage
            // 
            this.labelStage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStage.Font = new System.Drawing.Font("Meiryo UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStage.Location = new System.Drawing.Point(12, 9);
            this.labelStage.Name = "labelStage";
            this.labelStage.Size = new System.Drawing.Size(776, 214);
            this.labelStage.TabIndex = 0;
            this.labelStage.Text = "label1";
            this.labelStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelStage_MouseClick);
            // 
            // CardViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStage);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CardViewer";
            this.Text = "CardViewer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardViewer_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelStage;
    }
}

