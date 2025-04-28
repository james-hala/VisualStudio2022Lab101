using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    /*
    靜態變數
    1. 整個程式只有一份, 生命週期是整個程式執行期間, 直到程式結束.
    2. 就算是宣告在函數範圍內, 也不會在函數結束時釋放.
       例如: 在函數中宣告 static int i = 0; // i 會在整個程式執行期間都存在.

    參考型別靜態變數
    1. 整個程式只有一份 Instance, 生命週期是整個程式執行期間, 直到程式結束.
    2. 啟動點是靜態建構子, 會在第一次使用這個類別的時候, 自動執行.
       由於這樣的啟動點不好預期, 甚至有些情況會造成錯誤.
       所以建議在靜態建構子中, 增加一個函數, 在可預期的地方執行, 啟動靜態變數建構子.
       例如: CProject.Run().
    3. 結束點是程式結束, 會自動釋放靜態變數.
    練習: 測試靜態變數 CProject 的啟動點. 
     */


    /// <summary>
    /// CProject 收集本專案的所有靜態變數.
    /// 若 class 前面有 static, 則這個 class 只能有靜態變數, 不能有實體變數.
    /// </summary>
    public static class CProject
    {
        /// <summary>
        /// static constructor
        /// </summary>
        static CProject()
        {
            ID = "專案代號建構子";
            Name = "專案名稱建構子";
        }
        public static string ID = "Lab3";

        static Random _Random = new(DateTime.Now.Millisecond);
        static object _Lock = new();


        public static FormQuery? _FQuery = null;
        public static FormEntry? _FEntry = null;


        public static string _ConnectionString = "Server=localhost;Database=lab101;Uid=user1;Pwd=Test1!@#$";

        /// <summary>
        /// 專案名稱.
        /// 練習: 將所有的 MessageBox.Show() 的 Title 改為這個變數.
        /// </summary>
        public static string Name = "Lab3 專案";

        public static CMySql _MySql = new CMySql(_ConnectionString);

        /// <summary>
        /// 一個專案可能運作多個不同型別資料庫.
        /// 例如: 要將 MySql 的資料, 複製到 SqlServer, 或是 Oracle 等等.
        /// </summary>
        public static CMySql _OtherDatabase = new CMySql(_ConnectionString);

        public static void ShowFormQuery()
        {
            if (_FQuery == null || _FQuery.IsDisposed)
            {
                _FQuery = new FormQuery();
                _FQuery.Show();
            }
            else
            {
                _FQuery.Activate(); // 讓視窗在最上面
            }
        }
        public static void ShowFormEntry()
        {
            if (_FEntry == null || _FEntry.IsDisposed)
            {
                _FEntry = new FormEntry();
                _FEntry.Show();
            }
            else
            {
                _FEntry.Activate(); // 讓視窗在最上面
            }
        }
        public static void ShowFormEntry(int PPk1)
        {
            ShowFormEntry();
            _FEntry?.QueryPK(PPk1);
        }

        /// <summary>
        /// 取得亂數至少 6位數 的正整數。
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
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
        public static int GetRandom1UP()
        {
            lock (_Lock) // 確保在多執行緒環境下不會發生競爭條件。
            {
                return _Random.Next(1, 30);
            }
        }

        public static string GetRandomName()
        {
            const string sChinese = "商品a中b英c文d混1合2數3字4";
            lock (_Lock) // 確保在多執行緒環境下不會發生競爭條件。
            {
                return sChinese.Substring(0, _Random.Next(1, sChinese.Length));
            }
        }

        public static void Run()
        {
            ID = "專案代號";
            Name = "專案名稱";
        }

    }
}
