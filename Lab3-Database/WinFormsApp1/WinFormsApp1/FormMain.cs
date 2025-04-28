using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMain : Form
    {
        Color _OriginalColor = Color.Black;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 工具軟體可以設定或操作的動作, 大部分都可以改為程式或 Scripts 設定.
            string? sVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString(); // 參考 AboutBox1.cs 如何取得.
            ToolStripStatusLabel Label1 = new ToolStripStatusLabel("歡迎光臨");
            ToolStripStatusLabel Label2 = new ToolStripStatusLabel(sVersion, null, MenuHA_Click);
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(Label1);
            statusStrip1.Items.Add(Label2);
            Label1.Spring = true; // 讓 Label1 自動調整大小, 佔滿剩餘空間
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            Label2.Width = 160;
            Label2.TextAlign = ContentAlignment.MiddleRight;

            _OriginalColor = Label1.ForeColor; // 儲存原始顏色
            txtOuput.Text = "歡迎使用本系統";
        }


        private void Menu11_Click(object sender, EventArgs e)
        {
            // 變數名稱應避免跟(保留字、型別)重複, 以免混淆, 或產生潛在可能的錯誤
            //Form1 Form1 = new Form1();
            //Form1.Show();
            FormQuery Form1_Instance = new FormQuery();
            Form1_Instance.Show();
        }

        private void Menu21_Click(object sender, EventArgs e)
        {
            CProject.ShowFormQuery();
        }

        private void Menu22_Click(object sender, EventArgs e)
        {
            CProject.ShowFormEntry();
        }

        private void MenuHA_Click(object? sender, EventArgs e)
        {
            // Instance 跟變數一樣有範圍, 但是範圍結束不會自動清除.
            AboutBox1 Form1 = new AboutBox1();
            Form1.Show();
        }

        void MyShowMsgError(string PMsg)
        {
            if (statusStrip1.Items.Count < 1)
                return;

            // 轉換型別有兩種方式:
            ToolStripStatusLabel? Label1Sample = (ToolStripStatusLabel)statusStrip1.Items[0];
            ToolStripStatusLabel? Label1 = statusStrip1.Items[0] as ToolStripStatusLabel;
            if (Label1 == null)
                return;
            Label1.Text = PMsg;
            Label1.ForeColor = Color.Red;
        }
        void MyShowMsg(string PMsg)
        {
            if (statusStrip1.Items.Count < 1)
                return;

            // 轉換型別有兩種方式:
            ToolStripStatusLabel? Label1Sample = (ToolStripStatusLabel)statusStrip1.Items[0];
            ToolStripStatusLabel? Label1 = statusStrip1.Items[0] as ToolStripStatusLabel;
            if (Label1 == null)
                return;
            Label1.Text = PMsg;
            Label1.ForeColor = _OriginalColor;
        }

        private void Menu23_Click(object sender, EventArgs e)
        {
            try
            {
                CProject._MySql.TryOpen();
                MyShowMsg("資料庫連線成功");
            }
            catch (Exception ex1)
            {
                // 注意安全: 不應該把 ConnectionString 顯示到畫面給使用者看到! 
                txtOuput.Text = $"資料庫連線失敗:{Environment.NewLine}{CProject._ConnectionString}{Environment.NewLine}{ex1.StackTrace}";
            }
        }

        public void ShowOutput(string PMsg)
        {
            txtOuput.Text = PMsg;
        }
    }
}
