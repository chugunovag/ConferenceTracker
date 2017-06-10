using System;
using System.Collections.Generic;
using System.Threading;
using Common.data;
using Common.helper;

namespace StressTest
{
    public class TestController : IDisposable
    {
        private static readonly ManualResetEvent StopEvent = new ManualResetEvent(true);

        private static readonly Random Random = new Random();
        
        public void DoAutoTest(string url, List<string> cities, List<string> streets, List<string> sections)
        {
            StopEvent.Reset();
            sections.ForEach(s =>
            {
                new Thread(o =>
                {
                    Console.WriteLine(@"Start: " + s);
                    var conference = new Conference
                    {
                        Section = s,
                        Info = new ConferenceInfo
                        {
                            Name = s,
                            City = GetRandom(cities),
                            Location = GetRandom(streets)
                        }
                    };

                    var inPlaceServer = new InPlaceServer(conference, url);
                    while (!StopEvent.WaitOne(1000))
                    {
                        inPlaceServer.RegisterSectionData();
                        inPlaceServer.Conference.Info.City = GetRandom(cities);
                        inPlaceServer.Conference.Info.Location = GetRandom(streets);
                    }
                    Console.WriteLine(@"Stop: " + s);
                }).Start();
            });
        }

        public bool IsAutoTestRunning()
        {
            return !StopEvent.WaitOne(0);
        }

        public void StopAutoTest()
        {
            StopEvent.Set();
        }

        public void RegisterSectionManual(string url, string section)
        {
            
        }

        public void RegisterSectionManual(string url, string section, string city, string location, string name)
        {
            
        }

        public List<Conference> GetAll(string url)
        {
            var conferences = Helpers.Get<List<Conference>>(url + "conference/info");
            Console.WriteLine($"Conferences found: {conferences?.Count}");
            //conferences?.ForEach(c=> Console.WriteLine($"{c}"));
            return conferences;
        }

        public ConferenceInfo GetSection(string url, string section)
        {
            return Helpers.Get<ConferenceInfo>(url + "conference/GIS/info");
        }

        public void Dispose()
        {
            StopEvent.Set();
        }

        private static string GetRandom(IReadOnlyList<string> list)
        {
            return list?[Random.Next(list.Count)];
        }

    }
}
