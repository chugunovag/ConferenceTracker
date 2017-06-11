using System;
using System.Windows.Forms;
using Common;
using ConferenceTracker.core;
using Ninject;

namespace ConferenceTracker {
    public static class Program {
        public static IKernel DiKernel = new StandardKernel();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            try {
                DiKernel.Bind<IStorage>().ToConstant(new SqliteStorage());
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ControlPanel());
            }
            finally {
                Close();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Зарегистрированную в данном контексте реализацию хранилища.</returns>
        public static IStorage GetStorage() {
            return DiKernel.Get<IStorage>();
        }

        private static void Close() {
            Server.Instance.Stop();
            GetStorage().Close();
            DiKernel.Dispose();
        }
    }
}