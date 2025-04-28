using System.Globalization;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class FormEntry : Form
    {
        /// <summary>
        /// �o�O��檺�غc�l�A����Q�إ߮ɷ|�I�s InitializeComponent() ��k�Ӫ�l�Ƥ���C
        /// Constructor of the form, called when the form is created to initialize components.
        /// Class ��, �{�����g���ǫ�ĳ����: 1. Constructor, Properties, Methods or Functions.
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
        /// �o�O��檺���J�ƥ�A������J�ɷ|����o�Ӥ�k�C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "�浧��ƺ��@";
            ControlBox = false; // �����������s

            ToolStripStatusLabel Label1 = new ToolStripStatusLabel();
            ToolStripStatusLabel Label2 = new ToolStripStatusLabel();
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(Label1);
            statusStrip1.Items.Add(Label2);
            Label1.Spring = true; // �� Label1 �۰ʽվ�j�p, �����Ѿl�Ŷ�
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            Label2.Width = 160;
            Label2.TextAlign = ContentAlignment.MiddleRight;

            _OriginalColor = Label1.ForeColor; // �x�s��l�C��
        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string? Name_AllowNull = TxtName.Text;
                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("�п�J PK.");
                if (string.IsNullOrEmpty(TxtSKU.Text))
                    throw new Exception("�п�J SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    Name_AllowNull = null;
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("�п�J���T���.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("�п�J���T�ƶq.");

                int PK1 = int.Parse(TxtPK.Text);
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("�T�{�s�W��?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
                    throw new Exception("�s�W����");

                MyClearEntry();
                MyShowMsg($"�w�s�W, PK={PK1}.");
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
                    throw new Exception("�п�J PK.");

                int PK1 = int.Parse(TxtPK.Text);
                if (!DateTime.TryParseExact(LblUpdateTime.Text, "yyyy.MM.dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime LastUpdateTime1))
                    throw new Exception("�Ьd�ߥX�̷s��ƦA�R��.");

                if (MessageBox.Show("�T�{�R����?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                CRecord Record1 = new();
                if (Record1.Delete(PK1, LastUpdateTime1) != 1)
                    throw new Exception("�R������. ��ƥi��w�Q���ʹL.");


                MyClearEntry();
                MyShowMsg($"�w�R��, PK={PK1}.");
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
                    throw new Exception("�п�J PK.");

                int PK1 = int.Parse(TxtPK.Text);
                CRecord Record1 = new();
                if (!Record1.QueryPK(PK1))
                    throw new Exception($"�d�ߥ���, �䤣�� PK={PK1}");

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

                MyShowMsg("�d�ߦ��\");
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
                    throw new Exception("�Ьd�ߥX�̷s��ƦA�ק�.");

                if (string.IsNullOrEmpty(TxtPK.Text))
                    throw new Exception("�п�J PK.");
                if (string.IsNullOrEmpty(TxtSKU.Text))
                    throw new Exception("�п�J SKU.");
                if (string.IsNullOrEmpty(TxtName.Text))
                    Name_AllowNull = null;
                if (decimal.TryParse(TxtPrice.Text, out decimal Price1) == false)
                    throw new Exception("�п�J���T���.");
                if (int.TryParse(TxtQty.Text, out int Qty1) == false)
                    throw new Exception("�п�J���T�ƶq.");

                int PK1 = int.Parse(TxtPK.Text);
                decimal Amount1 = Price1 * Qty1;
                TxtAmount.Text = Amount1.ToString("0.00");

                if (MessageBox.Show("�T�{�ק��?", CProject.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                CRecord Record1 = new();
                if (Record1.Update(PK1, LastUpdateTime1) != 1)
                    throw new Exception("�ק異��. ��ƥi��w�Q���ʹL.");


                MyClearEntry();
                MyShowMsg($"�w�ק�, PK={PK1}.");
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

            // �ഫ���O����ؤ覡:
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

            // �ഫ���O����ؤ覡:
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
