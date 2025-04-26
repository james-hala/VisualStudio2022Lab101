namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// �o�O��檺�غc�l�A����Q�إ߮ɷ|�I�s InitializeComponent() ��k�Ӫ�l�Ƥ���C
        /// Constructor of the form, called when the form is created to initialize components.
        /// Class ��, �{�����g���ǫ�ĳ����: 1. Constructor, Properties, Methods or Functions.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #region properties

        // ��Ƥ��ŧi���ܼ�, ���Ľd��u�b�Ө�Ƥ�, �]���u��b�Ө�Ƥ��ϥ�.
        // Class �d���ܼ�, ���Ľd��O��� Class, �]����� Class ������Ƴ��i�H�ϥ�.
        int _SeqNo = 0; // �O���ثe���s��.
        readonly Random _Random = new(DateTime.Now.Millisecond);
        readonly object _Lock = new();
        #endregion

        /// <summary>
        /// ���o�üƦܤ� 6��� ������ơC
        /// </summary>
        /// <returns></returns>
        int GetRandomNumber()
        {
            lock (_Lock) // �T�O�b�h��������ҤU���|�o���v������C
            {
                return _Random.Next(1000000, int.MaxValue);
            }
        }

        /// <summary>
        /// ���o�ü� 1~30 ������ơC
        /// </summary>
        /// <returns></returns>
        int GetRandom1UP()
        {
            lock (_Lock) // �T�O�b�h��������ҤU���|�o���v������C
            {
                return _Random.Next(1, 30);
            }
        }

        string GetRandomName()
        {
            const string sChinese = "�ӫ~a��b�^c��d�V1�X2��3�r4";
            lock (_Lock) // �T�O�b�h��������ҤU���|�o���v������C
            {
                return sChinese.Substring(0, _Random.Next(1, sChinese.Length));
            }
        }

        /// <summary>
        /// �o�O��檺���J�ƥ�A������J�ɷ|����o�Ӥ�k�C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "���d��";

            // ��ĳ�ɶq�γo�ؤ�k�إ� Event delegate ���, �i�H�����b�P�@�Ӧa��޲z���Ǩƥ�w�Q�]�w�nĲ�o. 
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            listView1.View = View.Details;
            listView1.LabelEdit = false; // Allow the user to edit item text.
            listView1.AllowColumnReorder = false; // Allow the user to rearrange columns.
            listView1.CheckBoxes = false; // Display check boxes.
            listView1.FullRowSelect = true; // Select the item and subitems when selection is made.
            listView1.GridLines = true; // Display grid lines.
            listView1.Sorting = SortOrder.None;
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
            listView1.Columns.Add("�s��", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("SKU", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("�W��", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("���", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("�ƶq", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("���B", 100, HorizontalAlignment.Right);
        }

        /// <summary>
        /// �� ListBox ��������ا��ܮɷ|����o�Ӥ�k�C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            object Item1 = listBox1.SelectedItem;

            // �Y Item1.ToString() == null, �h Record1 = string.Empty.
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
        /// �� ListView ��������ا��ܮɷ|����o�Ӥ�k�C
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
                    throw new Exception("�п�J SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    throw new Exception("�п�J�W��.");
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("�п�J���T���.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("�п�J���T�ƶq.");
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("�T�{�s�W��?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _SeqNo++;

                // �ǲΪ��g�k:
                //string[] SubItems1 = new string[6];
                //SubItems1[0] = iNo.ToString();
                //SubItems1[1] = txtSKU.Text;
                //SubItems1[2] = TxtName.Text;
                //SubItems1[3] = Price1.ToString("0.00");
                //SubItems1[4] = Qty1.ToString("0");
                //SubItems1[5] = Amount1.ToString("0.00");

                // ��� C# 6.0 ���r�괡�Ȫk:
                //   C# 6.0 �O�{���y�k������, ���O .NET ������.
                string[] SubItems1 =
                [
                    _SeqNo.ToString(),
                    txtSKU.Text,
                    TxtName.Text,
                    Price1.ToString("0.00"),
                    Qty1.ToString("0"),
                    Amount1.ToString("0.00"),
                ];

                // ListBox �� Item ���O�� object.
                string Record1 = $"{SubItems1[0]},{SubItems1[1]},{SubItems1[2]},{SubItems1[3]},{SubItems1[4]},{SubItems1[5]}";
                listBox1.Items.Add(Record1);

                // ListView �� Item ���O�� ListViewItem.
                ListViewItem Item1 = new ListViewItem(SubItems1);
                listView1.Items.Add(Item1);

                MyClearEntry();

                LblMsg.Text = "�w�s�W";
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

        // ���ߨ�ƪ���h:
        // ���Ƽ��g�ۦP���{���X��, �N�n�Ҽ{�N�o�ǵ{���X����������.
        // �n�O�S���o�˰�����, ��n�ק�o�ǵ{���X��, �N�����b�C�@�Ӧa�賣�ק�, �o�˴N�|�W�[���~�����v.
        /// <summary>
        /// ��ܦr����שM�줸�ժ���.
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
                    MessageBox.Show("�Цb ListView ����ܭn�R��������.");
                    return;
                }
                int iIndex = listView1.SelectedIndices[0];
                if (MessageBox.Show("�T�{�R����?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                listView1.Items.RemoveAt(iIndex);
                listBox1.Items.RemoveAt(iIndex);

                LblMsg.Text = "�w�R��";

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
                    throw new Exception("�п�J SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    throw new Exception("�п�J�W��.");
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("�п�J���T���.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("�п�J���T�ƶq.");
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (listView1.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("�Цb ListView ����ܭn�ק諸����.");
                    return;
                }
                int iIndex = listView1.SelectedIndices[0];
                if (MessageBox.Show("�T�{�ק��?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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

                // ListBox �� Item ���O�� object.
                string Record1 = $"{SubItems1[0]},{SubItems1[1]},{SubItems1[2]},{SubItems1[3]},{SubItems1[4]},{SubItems1[5]}";
                listBox1.Items[iIndex] = Record1;

                // ListView �� Item ���O�� ListViewItem.
                ListViewItem Item1 = listView1.Items[iIndex];
                for (int i = 0; i < Item1.SubItems.Count; i++)
                    Item1.SubItems[i].Text = SubItems1[i];

                LblMsg.Text = "�w�ק�";

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
