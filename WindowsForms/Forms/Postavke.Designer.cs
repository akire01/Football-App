namespace WindowsForms
{
    partial class Postavke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Postavke));
            this.btnOk = new System.Windows.Forms.Button();
            this.rbHrv = new System.Windows.Forms.RadioButton();
            this.gbJezik = new System.Windows.Forms.GroupBox();
            this.rbEng = new System.Windows.Forms.RadioButton();
            this.rbMen = new System.Windows.Forms.RadioButton();
            this.rbWomen = new System.Windows.Forms.RadioButton();
            this.gbPrvenstvo = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbJezik.SuspendLayout();
            this.gbPrvenstvo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rbHrv
            // 
            resources.ApplyResources(this.rbHrv, "rbHrv");
            this.rbHrv.Name = "rbHrv";
            this.rbHrv.TabStop = true;
            this.rbHrv.UseVisualStyleBackColor = true;
            // 
            // gbJezik
            // 
            resources.ApplyResources(this.gbJezik, "gbJezik");
            this.gbJezik.Controls.Add(this.rbEng);
            this.gbJezik.Controls.Add(this.rbHrv);
            this.gbJezik.Name = "gbJezik";
            this.gbJezik.TabStop = false;
            // 
            // rbEng
            // 
            resources.ApplyResources(this.rbEng, "rbEng");
            this.rbEng.Name = "rbEng";
            this.rbEng.TabStop = true;
            this.rbEng.UseVisualStyleBackColor = true;
            // 
            // rbMen
            // 
            resources.ApplyResources(this.rbMen, "rbMen");
            this.rbMen.Name = "rbMen";
            this.rbMen.TabStop = true;
            this.rbMen.UseVisualStyleBackColor = true;
            // 
            // rbWomen
            // 
            resources.ApplyResources(this.rbWomen, "rbWomen");
            this.rbWomen.Name = "rbWomen";
            this.rbWomen.TabStop = true;
            this.rbWomen.UseVisualStyleBackColor = true;
            // 
            // gbPrvenstvo
            // 
            resources.ApplyResources(this.gbPrvenstvo, "gbPrvenstvo");
            this.gbPrvenstvo.Controls.Add(this.rbWomen);
            this.gbPrvenstvo.Controls.Add(this.rbMen);
            this.gbPrvenstvo.Name = "gbPrvenstvo";
            this.gbPrvenstvo.TabStop = false;
            // 
            // Postavke
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPrvenstvo);
            this.Controls.Add(this.gbJezik);
            this.Controls.Add(this.btnOk);
            this.Name = "Postavke";
            this.gbJezik.ResumeLayout(false);
            this.gbJezik.PerformLayout();
            this.gbPrvenstvo.ResumeLayout(false);
            this.gbPrvenstvo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rbHrv;
        private System.Windows.Forms.GroupBox gbJezik;
        private System.Windows.Forms.RadioButton rbEng;
        private System.Windows.Forms.RadioButton rbMen;
        private System.Windows.Forms.RadioButton rbWomen;
        private System.Windows.Forms.GroupBox gbPrvenstvo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}