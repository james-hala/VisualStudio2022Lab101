namespace WinFormsApp1
{
    partial class FormQuery
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
            TxtName = new TextBox();
            TxtPriceMin = new TextBox();
            TxtSKU = new TextBox();
            LblSkuNo = new Label();
            listView1 = new ListView();
            BtnBuildTestData = new Button();
            LblCount = new Label();
            label14 = new Label();
            label3 = new Label();
            TxtPriceMax = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            BtnQuery = new Button();
            statusStrip1 = new StatusStrip();
            linkLabel1 = new LinkLabel();
            BtnClear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 52);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 0;
            label1.Text = "名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 85);
            label2.Name = "label2";
            label2.Size = new Size(39, 19);
            label2.TabIndex = 1;
            label2.Text = "單價";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(163, 49);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(120, 27);
            TxtName.TabIndex = 8;
            // 
            // TxtPriceMin
            // 
            TxtPriceMin.Location = new Point(163, 82);
            TxtPriceMin.Name = "TxtPriceMin";
            TxtPriceMin.Size = new Size(120, 27);
            TxtPriceMin.TabIndex = 9;
            // 
            // TxtSKU
            // 
            TxtSKU.Location = new Point(163, 16);
            TxtSKU.Name = "TxtSKU";
            TxtSKU.Size = new Size(120, 27);
            TxtSKU.TabIndex = 19;
            // 
            // LblSkuNo
            // 
            LblSkuNo.AutoSize = true;
            LblSkuNo.Location = new Point(79, 19);
            LblSkuNo.Name = "LblSkuNo";
            LblSkuNo.Size = new Size(38, 19);
            LblSkuNo.TabIndex = 18;
            LblSkuNo.Text = "SKU";
            // 
            // listView1
            // 
            listView1.Location = new Point(22, 159);
            listView1.Name = "listView1";
            listView1.Size = new Size(626, 159);
            listView1.TabIndex = 21;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BtnBuildTestData
            // 
            BtnBuildTestData.Location = new Point(554, 323);
            BtnBuildTestData.Name = "BtnBuildTestData";
            BtnBuildTestData.Size = new Size(94, 29);
            BtnBuildTestData.TabIndex = 26;
            BtnBuildTestData.Text = "測試資料";
            BtnBuildTestData.UseVisualStyleBackColor = true;
            BtnBuildTestData.Click += BtnBuildTestData_Click;
            // 
            // LblCount
            // 
            LblCount.AutoSize = true;
            LblCount.Location = new Point(69, 321);
            LblCount.Name = "LblCount";
            LblCount.Size = new Size(60, 19);
            LblCount.TabIndex = 35;
            LblCount.Text = "label12";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(25, 323);
            label14.Name = "label14";
            label14.Size = new Size(39, 19);
            label14.TabIndex = 34;
            label14.Text = "筆數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 52);
            label3.Name = "label3";
            label3.Size = new Size(150, 19);
            label3.TabIndex = 28;
            label3.Text = "(可用 '%' 或 '_' ) 查詢";
            // 
            // TxtPriceMax
            // 
            TxtPriceMax.Location = new Point(364, 82);
            TxtPriceMax.Name = "TxtPriceMax";
            TxtPriceMax.Size = new Size(120, 27);
            TxtPriceMax.TabIndex = 27;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(289, 85);
            label11.Name = "label11";
            label11.Size = new Size(36, 19);
            label11.TabIndex = 26;
            label11.Text = "and";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 83);
            label10.Name = "label10";
            label10.Size = new Size(36, 19);
            label10.TabIndex = 25;
            label10.Text = "and";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 52);
            label9.Name = "label9";
            label9.Size = new Size(36, 19);
            label9.TabIndex = 24;
            label9.Text = "and";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(327, 85);
            label8.Name = "label8";
            label8.Size = new Size(31, 19);
            label8.TabIndex = 23;
            label8.Text = "<=";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(126, 85);
            label7.Name = "label7";
            label7.Size = new Size(31, 19);
            label7.TabIndex = 22;
            label7.Text = ">=";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(124, 52);
            label6.Name = "label6";
            label6.Size = new Size(33, 19);
            label6.TabIndex = 21;
            label6.Text = "like";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 19);
            label5.Name = "label5";
            label5.Size = new Size(20, 19);
            label5.TabIndex = 20;
            label5.Text = "=";
            // 
            // BtnQuery
            // 
            BtnQuery.Location = new Point(23, 124);
            BtnQuery.Name = "BtnQuery";
            BtnQuery.Size = new Size(94, 29);
            BtnQuery.TabIndex = 37;
            BtnQuery.Text = "查詢";
            BtnQuery.UseVisualStyleBackColor = true;
            BtnQuery.Click += BtnQuery_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 362);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(670, 22);
            statusStrip1.TabIndex = 38;
            statusStrip1.Text = "statusStrip1";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(549, 129);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(99, 19);
            linkLabel1.TabIndex = 43;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "切換查詢畫面";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(124, 124);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(94, 29);
            BtnClear.TabIndex = 44;
            BtnClear.Text = "清除";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // FormQuery
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 384);
            Controls.Add(BtnClear);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(TxtPriceMax);
            Controls.Add(statusStrip1);
            Controls.Add(label11);
            Controls.Add(BtnQuery);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(BtnBuildTestData);
            Controls.Add(label8);
            Controls.Add(LblCount);
            Controls.Add(label7);
            Controls.Add(label14);
            Controls.Add(label6);
            Controls.Add(listView1);
            Controls.Add(label5);
            Controls.Add(LblSkuNo);
            Controls.Add(label2);
            Controls.Add(TxtPriceMin);
            Controls.Add(TxtName);
            Controls.Add(TxtSKU);
            Controls.Add(label1);
            Name = "FormQuery";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxtName;
        private TextBox TxtPriceMin;
        private TextBox TxtSKU;
        private Label LblSkuNo;
        private ListView listView1;
        private Button BtnBuildTestData;
        private Label LblCount;
        private Label label14;
        private Button BtnQuery;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox TxtPriceMax;
        private StatusStrip statusStrip1;
        private LinkLabel linkLabel1;
        private Label label3;
        private Button BtnClear;
    }
}
