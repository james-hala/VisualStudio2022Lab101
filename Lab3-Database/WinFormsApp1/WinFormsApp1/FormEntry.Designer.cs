namespace WinFormsApp1
{
    partial class FormEntry
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TxtName = new TextBox();
            TxtPrice = new TextBox();
            TxtQty = new TextBox();
            TxtAmount = new TextBox();
            label13 = new Label();
            TxtSKU = new TextBox();
            BtnAdd = new Button();
            BtnDelete = new Button();
            BtnUpdate = new Button();
            BtnClear = new Button();
            statusStrip1 = new StatusStrip();
            TxtPK = new TextBox();
            BtnQuery = new Button();
            panelEntry = new Panel();
            LblCreateTime = new Label();
            LblUpdateTime = new Label();
            label5 = new Label();
            linkLabel1 = new LinkLabel();
            panelEntry.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 54);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 0;
            label1.Text = "名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 87);
            label2.Name = "label2";
            label2.Size = new Size(39, 19);
            label2.TabIndex = 1;
            label2.Text = "單價";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 120);
            label3.Name = "label3";
            label3.Size = new Size(39, 19);
            label3.TabIndex = 2;
            label3.Text = "數量";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 153);
            label4.Name = "label4";
            label4.Size = new Size(39, 19);
            label4.TabIndex = 3;
            label4.Text = "金額";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(62, 49);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(120, 27);
            TxtName.TabIndex = 8;
            // 
            // TxtPrice
            // 
            TxtPrice.Location = new Point(62, 82);
            TxtPrice.Name = "TxtPrice";
            TxtPrice.Size = new Size(120, 27);
            TxtPrice.TabIndex = 9;
            // 
            // TxtQty
            // 
            TxtQty.Location = new Point(62, 115);
            TxtQty.Name = "TxtQty";
            TxtQty.Size = new Size(120, 27);
            TxtQty.TabIndex = 10;
            // 
            // TxtAmount
            // 
            TxtAmount.Location = new Point(62, 148);
            TxtAmount.Name = "TxtAmount";
            TxtAmount.Size = new Size(120, 27);
            TxtAmount.TabIndex = 11;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 14);
            label13.Name = "label13";
            label13.Size = new Size(27, 19);
            label13.TabIndex = 16;
            label13.Text = "PK";
            // 
            // TxtSKU
            // 
            TxtSKU.Location = new Point(62, 16);
            TxtSKU.Name = "TxtSKU";
            TxtSKU.Size = new Size(120, 27);
            TxtSKU.TabIndex = 19;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(18, 193);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(94, 29);
            BtnAdd.TabIndex = 22;
            BtnAdd.Text = "新增";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(302, 11);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(94, 29);
            BtnDelete.TabIndex = 23;
            BtnDelete.Text = "刪除";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(118, 193);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(94, 29);
            BtnUpdate.TabIndex = 24;
            BtnUpdate.Text = "修改";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(218, 193);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(94, 29);
            BtnClear.TabIndex = 25;
            BtnClear.Text = "清除";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 339);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(705, 22);
            statusStrip1.TabIndex = 37;
            statusStrip1.Text = "statusStrip1";
            // 
            // TxtPK
            // 
            TxtPK.Location = new Point(76, 11);
            TxtPK.Name = "TxtPK";
            TxtPK.Size = new Size(120, 27);
            TxtPK.TabIndex = 38;
            // 
            // BtnQuery
            // 
            BtnQuery.Location = new Point(202, 11);
            BtnQuery.Name = "BtnQuery";
            BtnQuery.Size = new Size(94, 29);
            BtnQuery.TabIndex = 39;
            BtnQuery.Text = "查詢";
            BtnQuery.UseVisualStyleBackColor = true;
            BtnQuery.Click += BtnQuery_Click;
            // 
            // panelEntry
            // 
            panelEntry.BorderStyle = BorderStyle.Fixed3D;
            panelEntry.Controls.Add(LblCreateTime);
            panelEntry.Controls.Add(LblUpdateTime);
            panelEntry.Controls.Add(label5);
            panelEntry.Controls.Add(TxtSKU);
            panelEntry.Controls.Add(label1);
            panelEntry.Controls.Add(label2);
            panelEntry.Controls.Add(label3);
            panelEntry.Controls.Add(label4);
            panelEntry.Controls.Add(TxtName);
            panelEntry.Controls.Add(TxtPrice);
            panelEntry.Controls.Add(BtnClear);
            panelEntry.Controls.Add(TxtQty);
            panelEntry.Controls.Add(BtnUpdate);
            panelEntry.Controls.Add(TxtAmount);
            panelEntry.Controls.Add(BtnAdd);
            panelEntry.Location = new Point(33, 46);
            panelEntry.Name = "panelEntry";
            panelEntry.Size = new Size(429, 242);
            panelEntry.TabIndex = 41;
            // 
            // LblCreateTime
            // 
            LblCreateTime.AutoSize = true;
            LblCreateTime.Location = new Point(218, 127);
            LblCreateTime.Name = "LblCreateTime";
            LblCreateTime.Size = new Size(88, 19);
            LblCreateTime.TabIndex = 28;
            LblCreateTime.Text = "CreateTime";
            // 
            // LblUpdateTime
            // 
            LblUpdateTime.AutoSize = true;
            LblUpdateTime.Location = new Point(218, 153);
            LblUpdateTime.Name = "LblUpdateTime";
            LblUpdateTime.Size = new Size(94, 19);
            LblUpdateTime.TabIndex = 27;
            LblUpdateTime.Text = "UpdateTime";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 19);
            label5.Name = "label5";
            label5.Size = new Size(38, 19);
            label5.TabIndex = 26;
            label5.Text = "SKU";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(33, 302);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(99, 19);
            linkLabel1.TabIndex = 42;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "切換查詢畫面";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FormEntry
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 361);
            Controls.Add(linkLabel1);
            Controls.Add(panelEntry);
            Controls.Add(BtnQuery);
            Controls.Add(TxtPK);
            Controls.Add(statusStrip1);
            Controls.Add(label13);
            Controls.Add(BtnDelete);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormEntry";
            Text = "Form1";
            Load += Form1_Load;
            panelEntry.ResumeLayout(false);
            panelEntry.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TxtName;
        private TextBox TxtPrice;
        private TextBox TxtQty;
        private TextBox TxtAmount;
        private Label label13;
        private TextBox TxtSKU;
        private Button BtnAdd;
        private Button BtnDelete;
        private Button BtnUpdate;
        private Button BtnClear;
        private StatusStrip statusStrip1;
        private TextBox TxtPK;
        private Button BtnQuery;
        private Panel panelEntry;
        private Label label5;
        private LinkLabel linkLabel1;
        private Label LblCreateTime;
        private Label LblUpdateTime;
    }
}
