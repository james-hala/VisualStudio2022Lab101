using Org.BouncyCastle.Math;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormQuery : Form
    {
        /// <summary>
        /// 這是表單的建構子，當表單被建立時會呼叫 InitializeComponent() 方法來初始化元件。
        /// Constructor of the form, called when the form is created to initialize components.
        /// Class 中, 程式撰寫順序建議應為: 1. Constructor, Properties, Methods or Functions.
        /// </summary>
        public FormQuery()
        {
            InitializeComponent();
        }

        #region properties

        Color _OriginalColor = Color.Black;
        #endregion


        /// <summary>
        /// 這是表單的載入事件，當表單載入時會執行這個方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "查詢瀏覽";
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


            listView1.View = View.Details;
            listView1.LabelEdit = false; // Allow the user to edit item text.
            listView1.AllowColumnReorder = false; // Allow the user to rearrange columns.
            listView1.CheckBoxes = false; // Display check boxes.
            listView1.FullRowSelect = true; // Select the item and subitems when selection is made.
            listView1.GridLines = true; // Display grid lines.
            listView1.Sorting = SortOrder.None;
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
            listView1.Columns.Add("編號", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("SKU", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("名稱", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("單價", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("數量", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("金額", 100, HorizontalAlignment.Right);

        }


        /// <summary>
        /// 當 ListView 的選取項目改變時會執行這個方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ListView1_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item == null)
                return;

            //ListViewItem Item1 = e.Item;
            //LblNo.Text = Item1.SubItems[0].Text;
            //txtSKU.Text = Item1.SubItems[1].Text;
            //TxtName.Text = Item1.SubItems[2].Text;
            //TxtPrice.Text = Item1.SubItems[3].Text;
            //TxtQty.Text = Item1.SubItems[4].Text;
            //TxtAmount.Text = Item1.SubItems[5].Text;
            //MyShowLength();
        }



        private void BtnBuildTestData_Click(object sender, EventArgs e)
        {
            //int No1 = GetRandomNumber();
            //txtSKU.Text = $"SKU{No1.ToString().Substring(4, 2)}";
            //TxtName.Text = GetRandomName();
            //TxtPrice.Text = $"{No1.ToString().Substring(2, 2)}.{No1.ToString().Substring(1, 2)}";
            //TxtQty.Text = $"{GetRandom1UP().ToString()}";

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

        /// <summary>
        /// 複合查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                MyShowMsg("查詢中...");
                listView1.Items.Clear();
                Dictionary<string, object?> para1 = new Dictionary<string, object?>();
                StringBuilder sb1 = new StringBuilder();
                if (!string.IsNullOrEmpty(TxtSKU.Text))
                {
                    sb1.Append(" and fsku=@fsku");
                    para1.Add("@fsku", TxtSKU.Text);
                }
                if (!string.IsNullOrEmpty(TxtName.Text))
                {
                    sb1.Append(" and fname like @fname");
                    para1.Add("@fname", TxtName.Text);
                }
                if (!string.IsNullOrEmpty(TxtPriceMin.Text))
                {
                    if (decimal.TryParse(TxtPriceMin.Text, out decimal PriceMin) == false)
                        throw new Exception("請輸入正確單價下限.");

                    sb1.Append(" and fprice>=@fprice_min");
                    para1.Add("@fprice_min", PriceMin);
                }
                if (!string.IsNullOrEmpty(TxtPriceMax.Text))
                {
                    if (decimal.TryParse(TxtPriceMax.Text, out decimal PriceMax) == false)
                        throw new Exception("請輸入正確單價上限.");

                    sb1.Append(" and fprice<=@fprice_max");
                    para1.Add("@fprice_min", PriceMax);
                }
                // 注意傳輸資料量不可太大, 可利用 limit 限制筆數.
                string sCmd;
                if (sb1.Length < 1)
                    sCmd = "select * from tlab3 order by fpk1 limit 100" + sb1.ToString();
                else
                    sCmd = $"select * from tlab3 where 1=1 {sb1.ToString()} order by fpk1 limit 100";

                int iCount = 0;
                DataSet ds1 = CProject._MySql.QueryDataSet(sCmd, para1);
                if (ds1.Tables.Count > 0)
                {
                    DataTable dt1 = ds1.Tables[0];
                    iCount = dt1.Rows.Count;
                    if (iCount < 1)
                        throw new Exception("查詢結果為空.");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        ListViewItem Item1 = new ListViewItem(dr1["fpk1"].ToString());
                        Item1.SubItems.Add(dr1["fsku"].ToString());
                        Item1.SubItems.Add(dr1["fname"].ToString());
                        Item1.SubItems.Add(dr1["fprice"].ToString());
                        Item1.SubItems.Add(dr1["fqty"].ToString());
                        Item1.SubItems.Add(dr1["famount"].ToString());
                        listView1.Items.Add(Item1);
                    }
                }
                LblCount.Text = iCount.ToString();
                MyShowMsg("查詢完畢");
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
                if (Program._FormMain != null)
                    Program._FormMain.ShowOutput(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count < 1)
                {
                    CProject.ShowFormEntry();
                    return;
                }

                if (listView1.SelectedItems.Count < 1)
                    return;
                ListViewItem Item1 = listView1.SelectedItems[0];
                string sPK1 = Item1.SubItems[0].Text;
                int iPK1 = int.Parse(sPK1);
                CProject.ShowFormEntry(iPK1);
            }
            catch (Exception ex)
            {
                MyShowMsgError(ex.Message);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtSKU.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtPriceMin.Text = string.Empty;
            TxtPriceMax.Text = string.Empty;
        }
    }
}
