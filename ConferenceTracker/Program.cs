using System;
using System.Windows.Forms;
using ConferenceTracker.core;
using Microsoft.Owin.Hosting;

namespace ConferenceTracker
{
    public static class Program
    {
        public const string BaseAddress = @"http://localhost:9000/";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WebApp.Start<Startup2>(BaseAddress);
            Application.Run(new ControlPanel());
        }
    }
}
