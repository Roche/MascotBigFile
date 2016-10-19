/*--
 *  Author: michel.petrovic@roche.com
 *
 *  Copyright 2016 by F. Hoffmann-La Roche Ltd
 *
*/
using System;
using System.Windows.Forms;

namespace MascotBigFile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Submit());
        }
    }
}
