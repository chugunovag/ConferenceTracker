using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using ConferenceTracker.data;

namespace ConferenceTracker
{
    public partial class ControlPanel : Form
    {

        public ControlPanel()
        {
            InitializeComponent();
            RegisterManyFakeConfs();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterFakeConf(GenerateGisName());
        }

        private void getSectionBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = client.GetAsync(Program.BaseAddress + "conference/GIS/info").Result;
            var conferenceInfo = response.Content.ReadAsAsync<ConferenceInfo>().Result;
            Console.WriteLine(conferenceInfo);
        }

        private void findAllBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = client.GetAsync(Program.BaseAddress + "conference/info").Result;
            var conferences = response.Content.ReadAsAsync<List<Conference>>().Result;
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
                while (true)
                {
                    RegisterFakeConf(GenerateGisName());
                    Thread.Sleep(200);
                }
            }).Start();
        }

        private static string GenerateGisName()
        {
            return "GIS" + Guid.NewGuid();
        }

        private static void RegisterFakeConf(string sectionName)
        {
            var client = new HttpClient();
            var response = client.PutAsJsonAsync($"{Program.BaseAddress}conference/{sectionName}/info",
                CreateTestInfo())
                .Result;
            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsAsync<Conference>().Result);
        }

        private static ConferenceInfo CreateTestInfo()
        {
            return new ConferenceInfo
            {
                Name = "Простая конференция",
                Location = "Rabochaya st, 56",
                City = "Tomsk"
            };
        }

        #endregion

    }
}