using System;
using ConferenceTracker.data;

namespace ConferenceTracker.test
{
    public class Helpers
    {
        public static Conference CreateTestConference(string section)
        {
            return new Conference
            {
                Section = section,
                Info = new ConferenceInfo
                {
                    Name = "Простая #" + Guid.NewGuid(),
                    Location = "Rabochaya st, " + new Random().Next(1000),
                    City = "Tomsk"
                }
            };
        }
    }
}
