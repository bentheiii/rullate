using System;
using System.Windows.Forms;
using FormStone;
using WhetStone.Looping;

namespace Rulatte
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            switch (argv.Length)
            {
                case 0:
                    break;
                case 1:
                    mainForm.Load += (a,b)=>mainForm.LoadPath(argv[0]);
                    break;
                default:
                    throw new Exception("bad number of arguments for program");
            }
            mainForm.Maintain(Properties.Settings.Default, "mainFormLocation");
            Application.Run(mainForm);
        }
    }
}
