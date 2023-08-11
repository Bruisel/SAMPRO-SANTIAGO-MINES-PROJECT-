using SAMPRO__SANTIAGO_MINES_PROJECT_;
using SAMPRO__SANTIAGO_MINES_PROJECT_.MENU_INICIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SAMPRO__SANTIAGO_MINES_PROJECT_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SEPTIMAHOJA());
            //Application.Run(new MAPA());
            Application.Run(new Test());

        }

    }
}