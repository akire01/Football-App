namespace WindowsForms
{
    partial class IgracController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgracController));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblBroj = new System.Windows.Forms.Label();
            this.lblPozicija = new System.Windows.Forms.Label();
            this.lblKapetan = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediSlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblValueAdd = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.pbZvjezdica = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZvjezdica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Name = "label1";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Name = "label2";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Name = "label3";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Name = "label4";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // lblIme
            // 
            resources.ApplyResources(this.lblIme, "lblIme");
            this.lblIme.Name = "lblIme";
            this.lblIme.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // lblBroj
            // 
            resources.ApplyResources(this.lblBroj, "lblBroj");
            this.lblBroj.Name = "lblBroj";
            this.lblBroj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // lblPozicija
            // 
            resources.ApplyResources(this.lblPozicija, "lblPozicija");
            this.lblPozicija.Name = "lblPozicija";
            this.lblPozicija.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // lblKapetan
            // 
            resources.ApplyResources(this.lblKapetan, "lblKapetan");
            this.lblKapetan.Name = "lblKapetan";
            this.lblKapetan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hejToolStripMenuItem,
            this.youToolStripMenuItem,
            this.urediSlikuToolStripMenuItem});
            this.cms.Name = "cms";
            resources.ApplyResources(this.cms, "cms");
            // 
            // hejToolStripMenuItem
            // 
            this.hejToolStripMenuItem.Name = "hejToolStripMenuItem";
            resources.ApplyResources(this.hejToolStripMenuItem, "hejToolStripMenuItem");
            this.hejToolStripMenuItem.Click += new System.EventHandler(this.OnSelected);
            // 
            // youToolStripMenuItem
            // 
            this.youToolStripMenuItem.Name = "youToolStripMenuItem";
            resources.ApplyResources(this.youToolStripMenuItem, "youToolStripMenuItem");
            this.youToolStripMenuItem.Click += new System.EventHandler(this.OnUnselected);
            // 
            // urediSlikuToolStripMenuItem
            // 
            this.urediSlikuToolStripMenuItem.Name = "urediSlikuToolStripMenuItem";
            resources.ApplyResources(this.urediSlikuToolStripMenuItem, "urediSlikuToolStripMenuItem");
            this.urediSlikuToolStripMenuItem.Click += new System.EventHandler(this.OnUrediSliku);
            // 
            // lblValueAdd
            // 
            resources.ApplyResources(this.lblValueAdd, "lblValueAdd");
            this.lblValueAdd.Name = "lblValueAdd";
            // 
            // lblAdd
            // 
            resources.ApplyResources(this.lblAdd, "lblAdd");
            this.lblAdd.BackColor = System.Drawing.Color.White;
            this.lblAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdd.Name = "lblAdd";
            // 
            // lblPlus
            // 
            resources.ApplyResources(this.lblPlus, "lblPlus");
            this.lblPlus.BackColor = System.Drawing.Color.Transparent;
            this.lblPlus.ForeColor = System.Drawing.Color.Navy;
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // pbZvjezdica
            // 
            this.pbZvjezdica.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbZvjezdica, "pbZvjezdica");
            this.pbZvjezdica.Name = "pbZvjezdica";
            this.pbZvjezdica.TabStop = false;
            this.pbZvjezdica.Tag = "pb";
            this.pbZvjezdica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            this.pbPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // IgracController
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.lblPlus);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblValueAdd);
            this.Controls.Add(this.lblKapetan);
            this.Controls.Add(this.lblPozicija);
            this.Controls.Add(this.lblBroj);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.pbZvjezdica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPlayer);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "IgracController";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbZvjezdica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbZvjezdica;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblBroj;
        private System.Windows.Forms.Label lblPozicija;
        private System.Windows.Forms.Label lblKapetan;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem hejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediSlikuToolStripMenuItem;
        private System.Windows.Forms.Label lblValueAdd;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblPlus;
    }
}
