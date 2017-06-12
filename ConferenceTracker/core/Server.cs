using System;
using ConferenceTracker.config;
using log4net;
using Microsoft.Owin.Hosting;

namespace ConferenceTracker.core {
    internal class Server {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Server));

        private IDisposable _app;

        private Server() {
        }

        public static Server Instance { get; } = new Server();

        public string BaseAddress { get; private set; }

        public bool Running => _app != null;

        public bool Start(string listenAdress) {
            try {
                Log.Debug("Starting server at point: " + listenAdress);
                BaseAddress = listenAdress;
                _app = WebApp.Start<Startup>(BaseAddress);
                return true;
            }
            catch (Exception e) {
                Log.Error("Can't start server", e);
                return false;
            }
        }

        public bool Stop() {
            try {
                Log.Debug("Stopping server: " + _app);
                _app?.Dispose();
                _app = null;
                return true;
            }
            catch (Exception e) {
                Log.Error("Can't stop server", e);
                return false;
            }
        }
    }
}