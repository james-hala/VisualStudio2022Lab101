namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 這是表單的建構子，當表單被建立時會呼叫 InitializeComponent() 方法來初始化元件。
        /// Constructor of the form, called when the form is created to initialize components.
        /// Class 中, 程式撰寫順序建議應為: 1. Constructor, Properties, Methods or Functions.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #region properties

        // 函數中宣告的變數, 有效範圍只在該函數中, 因此只能在該函數中使用.
        // Class 範圍的變數, 有效範圍是整個 Class, 因此整個 Class 中的函數都可以使用.
        int _SeqNo = 0; // 記錄目前的編號.
        readonly Random _Random = new(DateTime.Now.Millisecond);
        readonly object _Lock = new();
        #endregion

        /// <summary>
        /// 取得亂數至少 6位數 的正整數。
        /// </summary>
        /// <returns></returns>
        int GetRandomNumber()
        {
            lock (_Lock) // 確保在多執行緒環境下不會發生競爭條件。
            {
                return _Random.Next(1000000, int.MaxValue);
            }
        }

        /// <summary>
        /// 取得亂數 1~30 的正整數。
        /// </summary>
        /// <returns></returns>
        int GetRandom1UP()
        {
            lock (_Lock) // 確保在多執行緒環境下不會發生競爭條件。
            {
                return _Random.Next(1, 30);
            }
        }

        string GetRandomName()
        {
            const string sChinese = "商品a中b英c文d混1合2數3字4";
            lock (_Lock) // 確保在多執行緒環境下不會發生競爭條件。
            {
                return sChinese.Substring(0, _Random.Next(1, sChinese.Length));
            }
        }

        /// <summary>
        /// 這是表單的載入事件，當表單載入時會執行這個方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "表單範例";

            // 建議盡量用這種方法建立 Event delegate 函數, 可以集中在同一個地方管理那些事件已被設定要觸發. 
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

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
            listView1.Columns.Add("名稱", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("單價", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("數量", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("金額", 100, HorizontalAlignment.Right);
        }

        /// <summary>
        /// 當 ListBox 的選取項目改變時會執行這個方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            object Item1 = listBox1.SelectedItem;

            // 若 Item1.ToString() == null, 則 Record1 = string.Empty.
            string Record1 = Item1.ToString() ?? string.Empty;

            string[] Array1 = Record1.Split(',');
            LblNo.Text = Array1[0];
            txtSKU.Text = Array1[1];
            TxtName.Text = Array1[2];
            TxtPrice.Text = Array1[3];
            TxtQty.Text = Array1[4];
            TxtAmount.Text = Array1[5];

            MyShowLength();
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

            ListViewItem Item1 = e.Item;
            LblNo.Text = Item1.SubItems[0].Text;
            txtSKU.Text = Item1.SubItems[1].Text;
            TxtName.Text = Item1.SubItems[2].Text;
            TxtPrice.Text = Item1.SubItems[3].Text;
            TxtQty.Text = Item1.SubItems[4].Text;
            TxtAmount.Text = Item1.SubItems[5].Text;
            MyShowLength();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSKU.Text))
                    throw new Exception("請輸入 SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    throw new Exception("請輸入名稱.");
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("請輸入正確單價.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("請輸入正確數量.");
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("確認新增嗎?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _SeqNo++;

                // 傳統的寫法:
                //string[] SubItems1 = new string[6];
                //SubItems1[0] = iNo.ToString();
                //SubItems1[1] = txtSKU.Text;
                //SubItems1[2] = TxtName.Text;
                //SubItems1[3] = Price1.ToString("0.00");
                //SubItems1[4] = Qty1.ToString("0");
                //SubItems1[5] = Amount1.ToString("0.00");

                // 改用 C# 6.0 的字串插值法:
                //   C# 6.0 是程式語法的版本, 不是 .NET 的版本.
                string[] SubItems1 =
                [
                    _SeqNo.ToString(),
                    txtSKU.Text,
                    TxtName.Text,
                    Price1.ToString("0.00"),
                    Qty1.ToString("0"),
                    Amount1.ToString("0.00"),
                ];

                // ListBox 的 Item 型別為 object.
                string Record1 = $"{SubItems1[0]},{SubItems1[1]},{SubItems1[2]},{SubItems1[3]},{SubItems1[4]},{SubItems1[5]}";
                listBox1.Items.Add(Record1);

                // ListView 的 Item 型別為 ListViewItem.
                ListViewItem Item1 = new ListViewItem(SubItems1);
                listView1.Items.Add(Item1);

                MyClearEntry();

                LblMsg.Text = "已新增";
                MySummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MyClearEntry()
        {
            LblNo.Text = string.Empty;
            txtSKU.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtQty.Text = string.Empty;
            TxtAmount.Text = string.Empty;
        }

        private void MySummary()
        {
            decimal TotalAmt = 0;
            int TotalQty = 0;
            foreach (ListViewItem Item1 in listView1.Items)
            {
                if (int.TryParse(Item1.SubItems[4].Text, out int Qty1))
                    TotalQty += Qty1;
                if (decimal.TryParse(Item1.SubItems[5].Text, out decimal Amount1))
                    TotalAmt += Amount1;
            }
            decimal Avg1 = 0;
            if (TotalQty != 0)
                Avg1 = TotalAmt / TotalQty;

            LblTotalQty.Text = TotalQty.ToString();
            LblTotalAmt.Text = TotalAmt.ToString("0.00");
            LblAvg.Text = Avg1.ToString("0.00");
            LblCount.Text = listView1.Items.Count.ToString();

        }

        // 成立函數的原則:
        // 當重複撰寫相同的程式碼時, 就要考慮將這些程式碼抽取成為函數.
        // 要是沒有這樣做的話, 當要修改這些程式碼時, 就必須在每一個地方都修改, 這樣就會增加錯誤的機率.
        /// <summary>
        /// 顯示字串長度和位元組長度.
        /// </summary>
        void MyShowLength()
        {
            LblLengthOfName.Text = TxtName.Text.Length.ToString();
            LblLengthOfBytes.Text = System.Text.Encoding.UTF8.GetByteCount(TxtName.Text).ToString();
        }

        private void BtnBuildTestData_Click(object sender, EventArgs e)
        {
            int No1 = GetRandomNumber();
            txtSKU.Text = $"SKU{No1.ToString().Substring(4, 2)}";
            TxtName.Text = GetRandomName();
            TxtPrice.Text = $"{No1.ToString().Substring(2, 2)}.{No1.ToString().Substring(1, 2)}";
            TxtQty.Text = $"{GetRandom1UP().ToString()}";

        }

        private void ChkProductionEnv_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkProductionEnv.Checked)
                groupBoxTest.Visible = false;
            else
                groupBoxTest.Visible = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("請在 ListView 中選擇要刪除的項目.");
                    return;
                }
                int iIndex = listView1.SelectedIndices[0];
                if (MessageBox.Show("確認刪除嗎?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                listView1.Items.RemoveAt(iIndex);
                listBox1.Items.RemoveAt(iIndex);

                LblMsg.Text = "已刪除";

                MyClearEntry();
                MySummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSKU.Text))
                    throw new Exception("請輸入 SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    throw new Exception("請輸入名稱.");
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("請輸入正確單價.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("請輸入正確數量.");
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (listView1.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("請在 ListView 中選擇要修改的項目.");
                    return;
                }
                int iIndex = listView1.SelectedIndices[0];
                if (MessageBox.Show("確認修改嗎?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                string[] SubItems1 =
                [
                    LblNo.Text,
                    txtSKU.Text,
                    TxtName.Text,
                    Price1.ToString("0.00"),
                    Qty1.ToString("0"),
                    Amount1.ToString("0.00"),
                ];

                // ListBox 的 Item 型別為 object.
                string Record1 = $"{SubItems1[0]},{SubItems1[1]},{SubItems1[2]},{SubItems1[3]},{SubItems1[4]},{SubItems1[5]}";
                listBox1.Items[iIndex] = Record1;

                // ListView 的 Item 型別為 ListViewItem.
                ListViewItem Item1 = listView1.Items[iIndex];
                for (int i = 0; i < Item1.SubItems.Count; i++)
                    Item1.SubItems[i].Text = SubItems1[i];

                LblMsg.Text = "已修改";

                MyClearEntry();
                MySummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
