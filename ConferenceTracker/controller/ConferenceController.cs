using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConferenceTracker.data;

namespace ConferenceTracker.controller
{
    /// <summary>
    ///     ���������� ��� ���������� ��������� �����������
    /// </summary>
    [RoutePrefix("conference")]
    public class ConferenceController : ApiController
    {
        public static Dictionary<string, Conference> Storage { get; } = new Dictionary<string, Conference>();

        /// <summary>
        ///     ����� � ������� ������ ���� �����-���� ������������������ �����������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("info")]
        public List<Conference> FindAllSections()
        {
            Console.WriteLine($"GET ALL: available: {Storage.Count}");
            return Storage.Values.ToList();
        }

        /// <summary>
        ///     ����� ����������� �� ������.
        /// </summary>
        /// <param name="section">������������� ������</param>
        /// <returns>�����������, ���� �����, ���� ����������� �� ������ ������ �� ���� ����������������</returns>
        [HttpGet]
        [Route("{section}/info")]
        public IHttpActionResult GetSection(string section)
        {
            Console.WriteLine($"GET ONE: {section}");
            Conference conference;
            if (Storage.TryGetValue(section, out conference))
            {
                var body = Request.CreateResponse(HttpStatusCode.OK, conference.Info);
                return new System.Web.Http.Results.ResponseMessageResult(body);
            }

            var err = Request.CreateResponse(HttpStatusCode.NotFound, "");

            return new System.Web.Http.Results.ResponseMessageResult(err);
//            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// <summary>
        ///     ������������ ����� �����������
        /// </summary>
        /// <param name="section">�������� ������</param>
        /// <param name="conferenceInfo">��������� ���������� � �����������</param>
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