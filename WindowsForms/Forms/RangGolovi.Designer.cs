namespace WindowsForms.Forms
{
    partial class RangGolovi
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
            this.flp.Location = new System.Drawing.Point(0, 12);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(549, 613);
            this.flp.TabIndex = 0;
            // 
            // RangGolovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 648);
            this.Controls.Add(this.flp);
            this.Name = "RangGolovi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rang igrača po broju golova";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp;
    }
}