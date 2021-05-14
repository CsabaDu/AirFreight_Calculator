
namespace AirFreight_Calculator
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
            this.L_Form1Head = new System.Windows.Forms.Label();
            this.Bn_GenUser = new System.Windows.Forms.Button();
            this.MS_Main = new System.Windows.Forms.MenuStrip();
            this.TSMI_CargoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AirCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.uC_AirCargo1 = new AirFreight_Calculator.UC_AirCargo();
            this.uC_CargoItem1 = new AirFreight_Calculator.UC_CargoItem();
            this.MS_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_Form1Head
            // 
            this.L_Form1Head.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L_Form1Head.Location = new System.Drawing.Point(16, 34);
            this.L_Form1Head.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Form1Head.Name = "L_Form1Head";
            this.L_Form1Head.Size = new System.Drawing.Size(1035, 42);
            this.L_Form1Head.TabIndex = 0;
            this.L_Form1Head.Text = "Légi fuvardíj kalkulátor";
            this.L_Form1Head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bn_GenUser
            // 
            this.Bn_GenUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Bn_GenUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bn_GenUser.Location = new System.Drawing.Point(16, 470);
            this.Bn_GenUser.Margin = new System.Windows.Forms.Padding(4);
            this.Bn_GenUser.Name = "Bn_GenUser";
            this.Bn_GenUser.Size = new System.Drawing.Size(1032, 74);
            this.Bn_GenUser.TabIndex = 2;
            this.Bn_GenUser.Text = "Árajánlatot kérek!";
            this.Bn_GenUser.UseVisualStyleBackColor = false;
            this.Bn_GenUser.Click += new System.EventHandler(this.Bn_GenUser_Click);
            // 
            // MS_Main
            // 
            this.MS_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_CargoItem,
            this.TSMI_AirCargo,
            this.TSMI_Quit});
            this.MS_Main.Location = new System.Drawing.Point(0, 0);
            this.MS_Main.Name = "MS_Main";
            this.MS_Main.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MS_Main.Size = new System.Drawing.Size(1064, 28);
            this.MS_Main.TabIndex = 5;
            this.MS_Main.Text = "menuStrip1";
            // 
            // TSMI_CargoItem
            // 
            this.TSMI_CargoItem.Name = "TSMI_CargoItem";
            this.TSMI_CargoItem.Size = new System.Drawing.Size(282, 24);
            this.TSMI_CargoItem.Text = "Szállítmány méretei, súlya, darabszáma";
            this.TSMI_CargoItem.Click += new System.EventHandler(this.TSMI_CargoItem_Click);
            // 
            // TSMI_AirCargo
            // 
            this.TSMI_AirCargo.Name = "TSMI_AirCargo";
            this.TSMI_AirCargo.Size = new System.Drawing.Size(377, 24);
            this.TSMI_AirCargo.Text = "Adatok összesítése, desztináció kiválasztása, árajánlat";
            this.TSMI_AirCargo.Click += new System.EventHandler(this.TSMI_AirCargo_Click);
            // 
            // TSMI_Quit
            // 
            this.TSMI_Quit.Name = "TSMI_Quit";
            this.TSMI_Quit.Size = new System.Drawing.Size(71, 24);
            this.TSMI_Quit.Text = "Kilépés";
            this.TSMI_Quit.Click += new System.EventHandler(this.TSMI_Quit_Click);
            // 
            // uC_AirCargo1
            // 
            this.uC_AirCargo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uC_AirCargo1.Location = new System.Drawing.Point(0, 0);
            this.uC_AirCargo1.Margin = new System.Windows.Forms.Padding(5);
            this.uC_AirCargo1.Name = "uC_AirCargo1";
            this.uC_AirCargo1.Size = new System.Drawing.Size(1064, 559);
            this.uC_AirCargo1.TabIndex = 4;
            // 
            // uC_CargoItem1
            // 
            this.uC_CargoItem1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uC_CargoItem1.Location = new System.Drawing.Point(0, 0);
            this.uC_CargoItem1.Margin = new System.Windows.Forms.Padding(5);
            this.uC_CargoItem1.Name = "uC_CargoItem1";
            this.uC_CargoItem1.Size = new System.Drawing.Size(1064, 559);
            this.uC_CargoItem1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1064, 559);
            this.Controls.Add(this.MS_Main);
            this.Controls.Add(this.L_Form1Head);
            this.Controls.Add(this.Bn_GenUser);
            this.Controls.Add(this.uC_AirCargo1);
            this.Controls.Add(this.uC_CargoItem1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(200, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Légi fuvardíj kalkulátor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MS_Main.ResumeLayout(false);
            this.MS_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Form1Head;
        private System.Windows.Forms.Button Bn_GenUser;
        private UC_CargoItem uC_CargoItem1;
        private UC_AirCargo uC_AirCargo1;
        private System.Windows.Forms.MenuStrip MS_Main;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CargoItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AirCargo;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Quit;
    }
}

