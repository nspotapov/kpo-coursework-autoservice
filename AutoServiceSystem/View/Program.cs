using Data;

namespace View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();

            var authForm = new FormAuth();
            
            if (authForm.ShowDialog() == DialogResult.OK && CurrentUser.IsAuthenticated)
            {
                // Открываем главную форму с разграничением прав
                Application.Run(new FormMainAdmin());
            }
        }
    }
}
