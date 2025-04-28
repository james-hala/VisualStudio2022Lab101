using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace WinFormsApp1
{
    /// <summary>
    /// MySql 公用函數類別.
    /// </summary>
    public class CMySql
    {
        /// <summary>
        /// Instance constructor
        /// </summary>
        /// <param name="PConnectionString"></param>
        public CMySql(string PConnectionString)
        {
            // Constructor
            _ConnectionString = PConnectionString;
        }

        /// <summary>
        /// 資料庫連線字串.
        /// 測試程式才會在 ConnectionString 存放帳號密碼, 正式程式不可以這樣做! 
        /// 原始程式碼中, 永遠不可以放帳號密碼, 因為一定會被看到! 就算編譯為執行檔, 也一樣會被看到!
        /// </summary>
        public readonly string _ConnectionString = string.Empty;


        /// <summary>
        /// The wait time before terminating the attempt to execute a command and generating an error.
        /// Default is 30 seconds.
        /// </summary>
        public int _CommandTimeout = 30;

        public void TryOpen()
        {
            using (MySqlConnection cnn1 = new MySqlConnection(_ConnectionString))
                cnn1.Open();
        }

        #region Command 四大名句

        /// <summary>
        /// 執行 Commmand, 回傳(處理的筆數), 例如: 新增、修改、刪除作業. 
        /// </summary>
        /// <param name="PCommandText"></param>
        /// <param name="PParameters"></param>
        /// <param name="PTransaction"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string PCommandText, Dictionary<string, object?> PParameters, MySqlTransaction? PTransaction = null)
        {
            using (MySqlConnection cnn1 = new MySqlConnection(_ConnectionString))
            {
                cnn1.Open();
                using (MySqlCommand cmd1 = cnn1.CreateCommand())
                {
                    cmd1.CommandText = PCommandText;
                    cmd1.CommandTimeout = _CommandTimeout;
                    cmd1.Transaction = PTransaction;
                    foreach (var param in PParameters)
                    {
                        var parameter = cmd1.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value ?? DBNull.Value;
                        cmd1.Parameters.Add(parameter);
                    }
                    return cmd1.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 執行 Commmand, 回傳 object?, 例如: 讀取總筆數: select count(*) from table1. 
        /// </summary>
        /// <param name="PCommandText"></param>
        /// <param name="PParameters"></param>
        /// <param name="PTransaction"></param>
        /// <returns></returns>
        public object ExecuteScalar(string PCommandText, Dictionary<string, object?> PParameters, MySqlTransaction? PTransaction = null)
        {
            using (MySqlConnection cnn1 = new MySqlConnection(_ConnectionString))
            {
                cnn1.Open();
                using (MySqlCommand cmd1 = cnn1.CreateCommand())
                {
                    cmd1.CommandText = PCommandText;
                    cmd1.CommandTimeout = _CommandTimeout;
                    cmd1.Transaction = PTransaction;
                    foreach (var param in PParameters)
                    {
                        var parameter = cmd1.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value ?? DBNull.Value;
                        cmd1.Parameters.Add(parameter);
                    }
                    return cmd1.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 執行 Commmand, 回傳 DataReader, 可以逐筆以迴圈讀取大量資料. 
        /// </summary>
        /// <param name="PCommandText"></param>
        /// <param name="PParameters"></param>
        /// <param name="PTransaction"></param>
        /// <returns></returns>
        public MySqlDataReader ExecuteReader(string PCommandText, Dictionary<string, object?> PParameters, MySqlTransaction? PTransaction = null)
        {
            using (MySqlConnection cnn1 = new MySqlConnection(_ConnectionString))
            {
                cnn1.Open();
                using (MySqlCommand cmd1 = cnn1.CreateCommand())
                {
                    cmd1.CommandText = PCommandText;
                    cmd1.CommandTimeout = _CommandTimeout;
                    cmd1.Transaction = PTransaction;
                    foreach (var param in PParameters)
                    {
                        var parameter = cmd1.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value ?? DBNull.Value;
                        cmd1.Parameters.Add(parameter);
                    }
                    return cmd1.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// 查詢 DataSet.
        /// 可一次回傳多個資料表, 例如: select * from Table1; select * from Table2;
        /// 注意傳輸資料量不可太大, 否則會影響效能.
        /// MySql 例: select * from table1 order by field1 asc limit 20 offset 20 可取得第21筆開始共20筆資料.
        /// </summary>
        /// <param name="PCommandText"></param>
        /// <param name="PParameters"></param>
        /// <param name="PTransaction"></param>
        /// <returns></returns>
        public DataSet QueryDataSet(string PCommandText, Dictionary<string, object?> PParameters, MySqlTransaction? PTransaction = null)
        {
            using (MySqlConnection cnn1 = new MySqlConnection(_ConnectionString))
            {
                cnn1.Open();
                using (MySqlCommand cmd1 = cnn1.CreateCommand())
                {
                    cmd1.CommandText = PCommandText;
                    cmd1.CommandTimeout = _CommandTimeout;
                    cmd1.Transaction = PTransaction;
                    foreach (var param in PParameters)
                    {
                        var parameter = cmd1.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value ?? DBNull.Value;
                        cmd1.Parameters.Add(parameter);
                    }
                    using (MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1))
                    {
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        return ds1;
                    }
                }
            }
        }
        #endregion

    }
}
