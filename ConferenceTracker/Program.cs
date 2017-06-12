using System;
using System.Windows.Forms;
using Common;
using ConferenceTracker.core;
using log4net;
using Ninject;

namespace ConferenceTracker {
    public static class Program {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

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
            catch (Exception e) {
                Log.Error(e);
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