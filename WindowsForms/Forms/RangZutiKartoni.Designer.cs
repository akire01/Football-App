namespace WindowsForms.Forms
{
    partial class RangZutiKartoni
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
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.flp.Location = new System.Drawing.Point(5, 1);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(540, 656);
            this.flp.TabIndex = 0;
            // 
            // RangZutiKartoni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 648);
            this.Controls.Add(this.flp);
            this.Name = "RangZutiKartoni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rang igrača po broju žutih kartona";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp;
    }
}