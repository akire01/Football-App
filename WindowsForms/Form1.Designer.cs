namespace WindowsForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbHr = new System.Windows.Forms.RadioButton();
            this.rbEn = new System.Windows.Forms.RadioButton();
            this.gbJezik = new System.Windows.Forms.GroupBox();
            this.gbJezik.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OldLace;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OldLace;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Name = "label3";
            // 
            // rbHr
            // 
            resources.ApplyResources(this.rbHr, "rbHr");
            this.rbHr.BackColor = System.Drawing.Color.Transparent;
            this.rbHr.Name = "rbHr";
            this.rbHr.TabStop = true;
            this.rbHr.UseVisualStyleBackColor = false;
            // 
            // rbEn
            // 
            resources.ApplyResources(this.rbEn, "rbEn");
            this.rbEn.BackColor = System.Drawing.Color.Transparent;
            this.rbEn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbEn.Name = "rbEn";
            this.rbEn.TabStop = true;
            this.rbEn.UseVisualStyleBackColor = false;
            // 
            // gbJezik
            // 
            this.gbJezik.BackColor = System.Drawing.Color.Transparent;
            this.gbJezik.Controls.Add(this.rbHr);
            this.gbJezik.Controls.Add(this.rbEn);
            resources.ApplyResources(this.gbJezik, "gbJezik");
            this.gbJezik.Name = "gbJezik";
            this.gbJezik.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsForms.Properties.Resources.Campo_5;
            this.Controls.Add(this.gbJezik);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.gbJezik.ResumeLayout(false);
            this.gbJezik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbHr;
        private System.Windows.Forms.RadioButton rbEn;
        private System.Windows.Forms.GroupBox gbJezik;
    }
}

