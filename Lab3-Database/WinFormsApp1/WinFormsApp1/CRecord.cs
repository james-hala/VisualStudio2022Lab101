using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{

    /// <summary>
    /// Class 中的順序習慣是: 1. Constructor, 2. Properties, 3. Methods.
    /// </summary>
    public class CRecord
    {
        public CRecord()
        {
            // 初始值可以在 Constructor 中設定, 也可以在宣告時設定.
        }

        public int PK1  = 0;

        /// <summary>
        /// 商品編號.
        /// 注意: 商品名稱可以存入 null, 跟商品編號的處理方式不同處.
        /// </summary>
        public string SKU = string.Empty;

        /// <summary>
        /// 商品名稱.
        /// 注意: 商品名稱可以存入 null, 跟商品編號的處理方式不同處.
        /// </summary>
        public string? Name = null;

        public decimal Price = 0;
        public int Qty = 0;
        public decimal Amount = 0;

        public DateTime CreateTime = DateTime.MinValue;
        public DateTime LastUpdateTime = DateTime.MinValue;

        public int Insert()
        {
            /*
            CreateTime 和 LastUpdateTime 兩個欄位由資料庫維護, 因此不用傳給資料庫.
            在 Insert 時, 資料庫會自動填入目前的時間.             
             */
            Dictionary<string, object?> para1 = new Dictionary<string, object?>();
            string sCmd = "insert into tlab3(fpk1, fsku, fname, fprice, fqty, famount) values(@fpk1, @fsku, @fname, @fprice, @fqty, @famount);";
            para1.Add("@fpk1", PK1);
            para1.Add("@fsku", SKU);
            para1.Add("@fname", Name);
            para1.Add("@fprice", Price);
            para1.Add("@fqty", Qty);
            para1.Add("@famount", Amount);
            return CProject._MySql.ExecuteNonQuery(sCmd, para1);
        }
        public int Update(int PPK1, DateTime PLastUpdateTime)
        {

            /*
            CreateTime 和 LastUpdateTime 兩個欄位由資料庫維護, 因此不用傳給資料庫.
            在 Update 時, 資料庫會維持 CreateTime 不變, LastUpdateTime 則填入最新修改時間.

            注意: 在 Update 時, 需要傳入 LastUpdateTime, 以便資料庫確認是否為最新的資料.
             */

            Dictionary<string, object?> para1 = new Dictionary<string, object?>();
            string sCmd = "update tlab3 fsku=@fsku, fname=@fname, fprice=@fprice, fqty=fqty, famount=@famount) where fpk1=@fpk1 and fupdate_time=@fupdate_time;";
            para1.Add("@fsku", SKU);
            para1.Add("@fname", Name);
            para1.Add("@fprice", Price);
            para1.Add("@fqty", Qty);
            para1.Add("@famount", Amount);
            para1.Add("@fpk1", PPK1);
            para1.Add("@fupdate_time", PLastUpdateTime);
            return CProject._MySql.ExecuteNonQuery(sCmd, para1);
        }
        public int Delete(int PPK1, DateTime PLastUpdateTime)
        {
            /*
            CreateTime 和 LastUpdateTime 兩個欄位由資料庫維護, 因此不用傳給資料庫.
            在 Update 時, 資料庫會維持 CreateTime 不變, LastUpdateTime 則填入最新修改時間.

            注意: 在 delete 時, 需要傳入 LastUpdateTime, 以便資料庫確認是否為最新的資料.
             */

            Dictionary<string, object?> para1 = new Dictionary<string, object?>();
            string sCmd = "delete from tlab3 where fpk1=@fpk1 and fupdate_time=@fupdate_time;";
            para1.Add("@fpk1", PPK1);
            para1.Add("@fupdate_time", PLastUpdateTime);
            return CProject._MySql.ExecuteNonQuery(sCmd, para1);
        }

        public bool QueryPK(int PPK1)
        {
            Dictionary<string, object?> para1 = new Dictionary<string, object?>();
            string sCmd = "select * from tlab3 where fpk1=@fpk1";
            para1.Add("@fpk1", PPK1);
            DataSet ds1 =  CProject._MySql.QueryDataSet(sCmd, para1);
            if (ds1.Tables.Count > 0)
            {
                DataTable dt1 = ds1.Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    DataRow dr1 = dt1.Rows[0];
                    PK1 = Convert.ToInt32(dr1["fpk1"]);
                    SKU = dr1["fsku"].ToString() ?? string.Empty;
                    Name = dr1["fname"].ToString();
                    Price = Convert.ToDecimal(dr1["fprice"]);
                    Qty = Convert.ToInt32(dr1["fqty"]);
                    Amount = Convert.ToDecimal(dr1["famount"]);
                    CreateTime = Convert.ToDateTime(dr1["fcreate_time"]);
                    LastUpdateTime = Convert.ToDateTime(dr1["fupdate_time"]);
                    return true;
                }
            }
            return false;
        }

    }
}
