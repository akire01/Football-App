namespace WindowsForms.Forms
{
    partial class Ekran1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ekran1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbDrzave = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblReprezentacijeInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flp2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOmiljen = new System.Windows.Forms.Label();
            this.flp1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnZutiKartoni = new System.Windows.Forms.Button();
            this.btnGolovi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grv = new System.Windows.Forms.DataGridView();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.player4 = new WindowsForms.IgracController();
            this.player3 = new WindowsForms.IgracController();
            this.player2 = new WindowsForms.IgracController();
            this.player1 = new WindowsForms.IgracController();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flp2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDrzave
            // 
            this.cbDrzave.DropDownHeight = 150;
            this.cbDrzave.FormattingEnabled = true;
            resources.ApplyResources(this.cbDrzave, "cbDrzave");
            this.cbDrzave.Name = "cbDrzave";
            this.cbDrzave.Sorted = true;
            this.cbDrzave.SelectedValueChanged += new System.EventHandler(this.OdabranaReprezentacija);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoLbl});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // infoLbl
            // 
            this.infoLbl.Name = "infoLbl";
            resources.ApplyResources(this.infoLbl, "infoLbl");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Name = "lblInfo";
            // 
            // lblReprezentacijeInfo
            // 
            resources.ApplyResources(this.lblReprezentacijeInfo, "lblReprezentacijeInfo");
            this.lblReprezentacijeInfo.ForeColor = System.Drawing.Color.Red;
            this.lblReprezentacijeInfo.Name = "lblReprezentacijeInfo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.flp2);
            this.tabPage1.Controls.Add(this.flp1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // flp2
            // 
            resources.ApplyResources(this.flp2, "flp2");
            this.flp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flp2.Controls.Add(this.lblOmiljen);
            this.flp2.Name = "flp2";
            // 
            // lblOmiljen
            // 
            resources.ApplyResources(this.lblOmiljen, "lblOmiljen");
            this.lblOmiljen.Name = "lblOmiljen";
            // 
            // flp1
            // 
            resources.ApplyResources(this.flp1, "flp1");
            this.flp1.BackColor = System.Drawing.Color.Silver;
            this.flp1.Name = "flp1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnZutiKartoni);
            this.tabPage2.Controls.Add(this.btnGolovi);
            this.tabPage2.Controls.Add(this.label3);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnZutiKartoni
            // 
            this.btnZutiKartoni.BackColor = System.Drawing.Color.Yellow;
            this.btnZutiKartoni.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnZutiKartoni, "btnZutiKartoni");
            this.btnZutiKartoni.ForeColor = System.Drawing.Color.Black;
            this.btnZutiKartoni.Name = "btnZutiKartoni";
            this.btnZutiKartoni.UseVisualStyleBackColor = false;
            this.btnZutiKartoni.Click += new System.EventHandler(this.btnZutiKartoni_Click);
            // 
            // btnGolovi
            // 
            this.btnGolovi.BackColor = System.Drawing.Color.Black;
            this.btnGolovi.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnGolovi, "btnGolovi");
            this.btnGolovi.ForeColor = System.Drawing.Color.White;
            this.btnGolovi.Name = "btnGolovi";
            this.btnGolovi.UseVisualStyleBackColor = false;
            this.btnGolovi.Click += new System.EventHandler(this.btnGolovi_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnPrint);
            this.tabPage3.Controls.Add(this.grv);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grv
            // 
            this.grv.AllowUserToAddRows = false;
            this.grv.AllowUserToDeleteRows = false;
            this.grv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.grv, "grv");
            this.grv.Name = "grv";
            this.grv.ReadOnly = true;
            this.grv.RowTemplate.Height = 24;
            // 
            // btnPostavke
            // 
            resources.ApplyResources(this.btnPostavke, "btnPostavke");
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // player4
            // 
            this.player4.BackColor = System.Drawing.Color.White;
            this.player4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.player4, "player4");
            this.player4.Name = "player4";
            // 
            // player3
            // 
            this.player3.BackColor = System.Drawing.Color.White;
            this.player3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.player3, "player3");
            this.player3.Name = "player3";
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.White;
            this.player2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.player2, "player2");
            this.player2.Name = "player2";
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.White;
            this.player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.player1, "player1");
            this.player1.Name = "player1";
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // Ekran1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReprezentacijeInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbDrzave);
            this.Name = "Ekran1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flp2.ResumeLayout(false);
            this.flp2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbDrzave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel infoLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblReprezentacijeInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private IgracController player1;
        private IgracController player2;
        private IgracController player4;
        private IgracController player3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnZutiKartoni;
        private System.Windows.Forms.Button btnGolovi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOmiljen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grv;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}