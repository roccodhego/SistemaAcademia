namespace SistemaAcademia
{
    internal static class Program
    {
        /// <sum�rio>
        ///  The main entry point for the application.
        /// </sum�rio>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}