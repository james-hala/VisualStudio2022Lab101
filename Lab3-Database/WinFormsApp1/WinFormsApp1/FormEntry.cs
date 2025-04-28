using System.Globalization;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class FormEntry : Form
    {
        /// <summary>
        /// 這是表單的建構子，當表單被建立時會呼叫 InitializeComponent() 方法來初始化元件。
        /// Constructor of the form, called when the form is created to initialize components.
        /// Class 中, 程式撰寫順序建議應為: 1. Constructor, Properties, Methods or Functions.
        /// </summary>
        public FormEntry()
        {
            InitializeComponent();
        }

        #region properties

        Color _OriginalColor = Color.Black;

        DateTime _CreateTime = DateTime.MinValue;
        DateTime _UpdateTime = DateTime.MinValue;

        #endregion


        /// <summary>
        /// 這是表單的載入事件，當表單載入時會執行這個方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "單筆資料維護";
            ControlBox = false; // 隱藏關閉按鈕

            ToolStripStatusLabel Label1 = new ToolStripStatusLabel();
            ToolStripStatusLabel Label2 = new ToolStripStatusLabel();
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(Label1);
            statusStrip1.Items.Add(Label2);
            Label1.Spring = true; // 讓 Label1 自動調整大小, 佔滿剩餘空間
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            Label2.Width = 160;
            Label2.TextAlign = ContentAlignment.MiddleRight;

            _OriginalColor = Label1.ForeColor; // 儲存原始顏色
        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string? Name_AllowNull = TxtName.Text;
                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("請輸入 PK.");
                if (string.IsNullOrEmpty(TxtSKU.Text))
                    throw new Exception("請輸入 SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    Name_AllowNull = null;
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("請輸入正確單價.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("請輸入正確數量.");

                int PK1 = int.Parse(TxtPK.Text);
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("確認新增嗎?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                CRecord Record1 = new()
                {
                    PK1 = PK1,
                    SKU = TxtSKU.Text,
                    Name = Name_AllowNull,
                    Price = Price1,
                    Qty = Qty1,
                    Amount = Amount1,
                    CreateTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now
                };
                if (Record1.Insert() != 1)
                    throw new Exception("新增失敗");

                MyClearEntry();
                MyShowMsg($"已新增, PK={PK1}.");
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
            }
        }

        private void MyClearEntry()
        {
            TxtPK.Text = string.Empty;
            TxtSKU.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtQty.Text = string.Empty;
            TxtAmount.Text = string.Empty;

            _CreateTime = DateTime.MinValue;
            _UpdateTime = DateTime.MinValue;
            LblCreateTime.Text = string.Empty;
            LblCreateTime.Text = string.Empty;
        }



        private void BtnBuildTestData_Click(object sender, EventArgs e)
        {
            int No1 = CProject.GetRandomNumber();
            TxtSKU.Text = $"SKU{No1.ToString().Substring(4, 2)}";
            TxtName.Text = CProject.GetRandomName();
            TxtPrice.Text = $"{No1.ToString().Substring(2, 2)}.{No1.ToString().Substring(1, 2)}";
            TxtQty.Text = $"{CProject.GetRandom1UP().ToString()}";

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("請輸入 PK.");

                int PK1 = int.Parse(TxtPK.Text);
                if (!DateTime.TryParseExact(LblUpdateTime.Text, "yyyy.MM.dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime LastUpdateTime1))
                    throw new Exception("請查詢出最新資料再刪除.");

                if (MessageBox.Show("確認刪除嗎?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                CRecord Record1 = new();
                if (Record1.Delete(PK1, LastUpdateTime1) != 1)
                    throw new Exception("刪除失敗. 資料可能已被異動過.");


                MyClearEntry();
                MyShowMsg($"已刪除, PK={PK1}.");
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
            }
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("請輸入 PK.");

                int PK1 = int.Parse(TxtPK.Text);
                CRecord Record1 = new();
                if (!Record1.QueryPK(PK1))
                    throw new Exception($"查詢失敗, 找不到 PK={PK1}");

                TxtPK.Text = Record1.PK1.ToString();
                TxtSKU.Text = Record1.SKU;
                TxtName.Text = Record1.Name;
                TxtPrice.Text = Record1.Price.ToString("0.00");
                TxtQty.Text = Record1.Qty.ToString();
                TxtAmount.Text = Record1.Amount.ToString("0.00");

                _CreateTime = Record1.CreateTime;
                _UpdateTime = Record1.LastUpdateTime;
                LblCreateTime.Text = _CreateTime.ToString("yyyy.MM.dd HH:mm:ss.fff");
                LblUpdateTime.Text = _UpdateTime.ToString("yyyy.MM.dd HH:mm:ss.fff");

                MyShowMsg("查詢成功");
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
            }
        }
        public void QueryPK(int PK1)
        {
            TxtPK.Text = PK1.ToString();
            BtnQuery_Click(TxtPK, EventArgs.Empty);
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string? Name_AllowNull = TxtName.Text;

                if (!DateTime.TryParseExact(LblUpdateTime.Text, "yyyy.MM.dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime LastUpdateTime1))
                    throw new Exception("請查詢出最新資料再修改.");

                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("請輸入 PK.");
                if (string.IsNullOrEmpty(TxtSKU.Text))
                    throw new Exception("請輸入 SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    Name_AllowNull = null;
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("請輸入正確單價.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("請輸入正確數量.");

                int PK1 = int.Parse(TxtPK.Text);
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("確認修改嗎?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                CRecord Record1 = new();
                if (Record1.Update(PK1, LastUpdateTime1) != 1)
                    throw new Exception("修改失敗. 資料可能已被異動過.");


                MyClearEntry();
                MyShowMsg($"已修改, PK={PK1}.");
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CProject.ShowFormQuery();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtSKU.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtQty.Text = string.Empty;
            TxtAmount.Text = string.Empty;
            LblCreateTime.Text = string.Empty;
            LblUpdateTime.Text = string.Empty;
        }
    }
}
