using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ConferenceTracker.core;
using ConferenceTracker.data;
using ConferenceTracker.test;

namespace ConferenceTracker
{
    public partial class ControlPanel : Form
    {

        private static readonly ManualResetEvent StopEvent = new ManualResetEvent(false);

        public ControlPanel()
        {
            InitializeComponent();
            RegisterManyFakeConfs();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterFakeConf();
        }

        private void getSectionBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/GIS/info"));
        }

        private void findAllBtn_Click(object sender, EventArgs e)
        {
            var conferences = RequestHelpers.Get<List<Conference>>(Program.BaseAddress + "conference/info");
            Console.WriteLine($"Conferences found: {conferences.Count}");
            foreach (var conference in conferences)
            {
                Console.WriteLine($"{conference}");
            }
        }

        #region "TEST PURPOSE"

        private static void RegisterManyFakeConfs()
        {
            new Thread(o =>
            {
                while (!StopEvent.WaitOne(0))
                {
                    RegisterFakeConf();
                    Thread.Sleep(200);
                }
            }).Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopEvent.Set();
        }

        private static void RegisterFakeConf()
        {
            var uniqueSection = "GIS" + Guid.NewGuid();
            var result = RequestHelpers.Put<Conference>($"{Program.BaseAddress}conference/{uniqueSection}/info", 
                Helpers.CreateTestConference(uniqueSection).Info);
            Console.WriteLine(result);
        }

     
        #endregion

    }
}