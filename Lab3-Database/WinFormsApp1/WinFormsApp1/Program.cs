namespace WinFormsApp1
{
    internal static class Program
    {
        public static FormMain _FormMain = null!; // �o�̪� null! �O���F�קK�sĶ������, �]�� _FormMain �|�b Main() ����l�� 
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // �Ұ��R�A�ܼƫغc�l, �o�̪� Run() �O���F���R�A�ܼƦb�i�w�����a��Ұ�, �Ҧp: Main() ��.
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