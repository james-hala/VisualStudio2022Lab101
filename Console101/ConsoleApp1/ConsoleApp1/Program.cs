namespace ConsoleApp1
{
    internal class Program
    {
        #region 原版
        //// 原版
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //}
        #endregion
        #region 範例1
        //// 範例1
        //// 摘要:
        //// 1. 程式以區塊加註解文字可增加可讀性, 註解文字也可以在程式碼後面添加.
        ///     註解文字可以 // 開始, 也可以 /* 註解文字 */ 方式撰寫.
        ///     註解文字可用上方 Text Editor 工具列 快速開啟或關閉. 
        //// 2. 以 VisualStudio IDE、檔案總管、Console 分別執行測試, 比較不同執行環境的差異結果.
        //// 3. 測試錯誤輸入的狀況: 例如出生年輸入字串.
        ////    不管是程式或是作業系統, 應能成功執行完 Input-Process-Output 3個區塊. 
        ////    就算是無法執行到結束, 也不可以當機或中斷跳出.  
        //static void Main(string[] args)
        //{
        //    // Input
        //    Console.Write("名稱:");
        //    string? sName = Console.ReadLine();

        //    Console.Write("出生年:");
        //    string? sYear = Console.ReadLine();
        //    if (string.IsNullOrEmpty(sYear))
        //        return;

        //    // Process
        //    int iAge = DateTime.Now.Year - int.Parse(sYear);


        //    // Output
        //    string sOutput = $"Hello, {sName} 你今年 {iAge} 歲";
        //    Console.WriteLine(sOutput);

        //    // UI: User Interface handlling.
        //    // 讓使用者看到上方的結果, 確認後再結束.
        //    Console.WriteLine(); // User friendly: 空一行比較易讀美觀.
        //    Console.WriteLine("按 Enter鍵結束");
        //    Console.ReadLine();
        //}
        #endregion

        #region 範例2
        /*
        範例2: 解決錯誤輸入的狀況: 例如出生年輸入字串.
        摘要:
        1. 註解文字也可以頭尾方式撰寫, 不用每一列加 // 註解.
        2. 迴圈介紹.
        3. Try-Catch 錯誤處理專門解決(無法預期的錯誤).
           無法預期的錯誤通常是指會導致(程式或作業系統)無法執行到結束.
         */
        static void Main(string[] args)
        {
            // Input
            Console.Write("名稱:");
            string? sName = Console.ReadLine();

            // Process
            int _Year = 0;
            int iThisYear = DateTime.Now.Year;
            while (true) // 迴圈開始
            {
                Console.Write("出生年:");
                string? sYear = Console.ReadLine();
                if (string.IsNullOrEmpty(sYear))
                    return;

                // Try-Catch 錯誤處理專門解決(無法預期的錯誤).
                try
                {
                    _Year = int.Parse(sYear);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"請輸入數字, 因為發生錯誤={ex.Message}.");
                    Console.WriteLine(); // User friendly: 空一行比較易讀美觀.
                    continue; // 下一個指令從迴圈開始執行.
                }

                // (可以預期的錯誤)是開發人員應處理的範圍.
                if (_Year < 1900 || _Year > iThisYear)
                {
                    Console.WriteLine($"請輸入正確的出生年, 1900~{iThisYear}.");
                    continue; // 下一個指令從迴圈開始執行.
                }

                // 這裡的 iYear 是正確的, 可以用來計算年齡.
                break; // 終止迴圈. 執行迴圈後的下一個指令
            }
            int iAge = DateTime.Now.Year - _Year;


            // Output
            string sOutput = $"Hello, {sName} 你今年 {iAge} 歲";
            Console.WriteLine(sOutput);

            // UI: User Interface handlling.
            // 讓使用者看到上方的結果, 確認後再結束.
            Console.WriteLine(); // User friendly: 空一行比較易讀美觀.
            Console.WriteLine("按 Enter鍵結束");
            Console.ReadLine();
        }
        #endregion

        #region 練習1
        //// 練習1: 將 Input 改為以參數字串陣列 string[] args 輸入.
        ////摘要:
        //// 參數字串陣列 string[] args, 若在 IDE 環境中執行時, 必須在 (Project).Properties.Debug.General.Launch Profiles.Command line Arguments 欄位中輸入. 例如:  林襄 2001
        //static void Main(string[] args)
        //{
        //    // Input
        //    string? sProgramName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; // 取得程式名稱
        //    string sHelp1 = $"請輸入名稱和出生年, 並且以空白間隔. 例如: {sProgramName} '林襄 2001'."; // 共用的資源應盡量整合.
        //    if (args.Length < 2)
        //    {
        //        Console.WriteLine(sHelp1);
        //        return;
        //    }
        //    string sName = args[0];
        //    string sYear = args[1];

        //    // Process
        //    if (int.TryParse(sYear, out int iYear) == false)
        //    {
        //        Console.WriteLine(sHelp1);
        //        return;
        //    }
        //    int iThisYear = DateTime.Now.Year;
        //    if (iYear < 1900 || iYear > iThisYear)
        //    {
        //        Console.WriteLine($"請輸入正確的出生年, 1900~{iThisYear}.");
        //        return;
        //    }
        //    int iAge = DateTime.Now.Year - iYear;

        //    // Output
        //    string sOutput = $"Hello, {sName} 你今年 {iAge} 歲";
        //    Console.WriteLine(sOutput);
        //}
        #endregion

        #region 練習2
        //// 練習2: 將 Input 改為以Environment.CommandLine 輸入.
        ////摘要:
        //// Environment.CommandLine 是唯讀的屬性, 無法輸入, 只能在(非 IDE 執行環境)中輸入.
        //static void Main()
        //{
        //    try
        //    {
        //        // Input
        //        string? sProgramName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; // 取得程式名稱
        //        string sHelp1 = $"請輸入名稱和出生年, 並且以空白間隔. 例如: {sProgramName} '林襄 2001'."; // 共用的資源應盡量整合.
        //        if (Environment.CommandLine.Length < 1)
        //        {
        //            Console.WriteLine(sHelp1);
        //            return;
        //        }
        //        string[] args = Environment.CommandLine.Split(' ');
        //        string sName = args[0];
        //        string sYear = args[1];

        //        // Process
        //        if (int.TryParse(sYear, out int iYear) == false)
        //        {
        //            Console.WriteLine(sHelp1);
        //            return;
        //        }
        //        int iThisYear = DateTime.Now.Year;
        //        if (iYear < 1900 || iYear > iThisYear)
        //        {
        //            Console.WriteLine($"請輸入正確的出生年, 1900~{iThisYear}.");
        //            return;
        //        }
        //        int iAge = DateTime.Now.Year - iYear;

        //        // Output
        //        string sOutput = $"Hello, {sName} 你今年 {iAge} 歲";
        //        Console.WriteLine(sOutput);
        //    }
        //    catch (Exception ex)
        //    {
        //        // 已經交付給使用者使用的程式, 不能當機或中斷跳出.
        //        Console.WriteLine($"發生無法預期的錯誤={ex.Message}.");
        //        return;
        //    }
        //}
        #endregion
    }
}
