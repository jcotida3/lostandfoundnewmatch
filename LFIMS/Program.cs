using LFsystem.Views.Main;
using LFsystem.Views.Login;
using System;
using System.Windows.Forms;

namespace LFIMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Start with LoginForm
            Application.Run(new LoginForm());
        }
    }
}
