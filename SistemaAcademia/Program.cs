namespace SistemaAcademia
{
    internal static class Program
    {
        /// <sumário>
        ///  The main entry point for the application.
        /// </sumário>
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