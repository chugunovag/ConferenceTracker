using System;
using ConferenceTracker.config;
using Microsoft.Owin.Hosting;

namespace ConferenceTracker.core
{
    public class Server
    {
        public static Server Instance { get; } = new Server();

        public string BaseAddress { get; private set; }

        public bool Running => _app != null;

        private IDisposable _app;

        private Server()
        {
        }

        public bool Start(string listenAdress)
        {
            try
            {
                BaseAddress = listenAdress;
                _app = WebApp.Start<Startup>(BaseAddress);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                _app?.Dispose();
                _app = null;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
    }
}
