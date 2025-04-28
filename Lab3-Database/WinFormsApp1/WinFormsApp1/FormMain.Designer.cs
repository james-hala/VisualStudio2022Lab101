namespace WinFormsApp1
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            Menu1 = new ToolStripMenuItem();
            Menu11 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            Menu2 = new ToolStripMenuItem();
            Menu21 = new ToolStripMenuItem();
            Menu22 = new ToolStripMenuItem();
            Menu23 = new ToolStripMenuItem();
            Menu3 = new ToolStripMenuItem();
            MenuTools = new ToolStripMenuItem();
            MenuHelp = new ToolStripMenuItem();
            MenuHA = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            txtOuput = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu1, toolStripMenuItem1, Menu2, Menu3, MenuTools, MenuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu1
            // 
            Menu1.DropDownItems.AddRange(new ToolStripItem[] { Menu11 });
            Menu1.Name = "Menu1";
            Menu1.Size = new Size(66, 23);
            Menu1.Text = "&1 功能";
            // 
            // Menu11
            // 
            Menu11.Name = "Menu11";
            Menu11.Size = new Size(151, 26);
            Menu11.Text = "&1 Form1";
            Menu11.Click += Menu11_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 23);
            // 
            // Menu2
            // 
            Menu2.DropDownItems.AddRange(new ToolStripItem[] { Menu21, Menu22, Menu23 });
            Menu2.Name = "Menu2";
            Menu2.Size = new Size(66, 23);
            Menu2.Text = "&2 功能";
            // 
            // Menu21
            // 
            Menu21.Name = "Menu21";
            Menu21.Size = new Size(195, 26);
            Menu21.Text = "&1 查詢瀏覽";
            Menu21.Click += Menu21_Click;
            // 
            // Menu22
            // 
            Menu22.Name = "Menu22";
            Menu22.Size = new Size(195, 26);
            Menu22.Text = "&2 維護資料";
            Menu22.Click += Menu22_Click;
            // 
            // Menu23
            // 
            Menu23.Name = "Menu23";
            Menu23.Size = new Size(195, 26);
            Menu23.Text = "&3 測試連線字串";
            Menu23.Click += Menu23_Click;
            // 
            // Menu3
            // 
            Menu3.Name = "Menu3";
            Menu3.Size = new Size(66, 23);
            Menu3.Text = "3 功能";
            // 
            // MenuTools
            // 
            MenuTools.Name = "MenuTools";
            MenuTools.Size = new Size(60, 23);
            MenuTools.Text = "&Tools";
            // 
            // MenuHelp
            // 
            MenuHelp.DropDownItems.AddRange(new ToolStripItem[] { MenuHA });
            MenuHelp.Name = "MenuHelp";
            MenuHelp.Size = new Size(55, 23);
            MenuHelp.Text = "&Help";
            // 
            // MenuHA
            // 
            MenuHA.Name = "MenuHA";
            MenuHA.Size = new Size(134, 26);
            MenuHA.Text = "&About";
            MenuHA.Click += MenuHA_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // txtOuput
            // 
            txtOuput.Location = new Point(12, 39);
            txtOuput.Multiline = true;
            txtOuput.Name = "txtOuput";
            txtOuput.ScrollBars = ScrollBars.Both;
            txtOuput.Size = new Size(750, 293);
            txtOuput.TabIndex = 2;
            txtOuput.WordWrap = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtOuput);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem Menu2;
        private ToolStripMenuItem Menu3;
        private ToolStripMenuItem MenuTools;
        private ToolStripMenuItem MenuHelp;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem Menu11;
        private ToolStripMenuItem Menu21;
        private ToolStripMenuItem Menu22;
        private ToolStripMenuItem MenuHA;
        private ToolStripMenuItem Menu23;
        private TextBox txtOuput;
    }
}