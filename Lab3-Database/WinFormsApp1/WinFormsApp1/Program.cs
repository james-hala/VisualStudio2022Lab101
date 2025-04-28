namespace WinFormsApp1
{
    internal static class Program
    {
        public static FormMain _FormMain = null!; // 這裡的 null! 是為了避免編譯器報錯, 因為 _FormMain 會在 Main() 中初始化 
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // 啟動靜態變數建構子, 這裡的 Run() 是為了讓靜態變數在可預期的地方啟動, 例如: Main() 中.
            CProject.Run(); 

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new FormMain());
            _FormMain = new FormMain();
            Application.Run(_FormMain);
        }
    }
}