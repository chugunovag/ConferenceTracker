using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ConferenceTracker.data;

namespace ConferenceTracker.controller
{
    [RoutePrefix("conference")]
    public class ConferenceController : ApiController
    {
        public static Dictionary<string, Conference> Storage { get; } = new Dictionary<string, Conference>();

        [HttpGet]
        [Route("info")]
        public List<Conference> FindAllSections()
        {
            Console.WriteLine($"GET ALL: available: {Storage.Count}");
            return Storage.Values.ToList();
        }

        [HttpGet]
        [Route("{section}/info")]
        public ConferenceInfo GetSection(string section)
        {
            Console.WriteLine($"GET ONE: {section}");
            Conference conference;
            return Storage.TryGetValue(section, out conference) ? conference.Info : null;
        }

        [HttpPut]
        [Route("{section}/info")]
        public void RegisterSection(string section, [FromBody] ConferenceInfo conferenceInfo)
        {
            Console.WriteLine($"PUT: {section} -> {conferenceInfo}");
            var conference = new Conference {Section = section, Info = conferenceInfo};
            Storage[section] = conference;
        }
    }
}