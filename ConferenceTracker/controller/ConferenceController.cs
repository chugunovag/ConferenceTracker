using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Common;
using Common.data;

namespace ConferenceTracker.controller
{
    /// <summary>
    ///     ���������� ��� ���������� ��������� �����������
    /// </summary>
    [RoutePrefix("conference")]
    public class ConferenceController : ApiController
    {
        public IStorage Storage => Program.GetStorage();

        /// <summary>
        ///     ����� � ������� ������ ���� �����-���� ������������������ �����������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("info")]
        public IHttpActionResult FindAllSections()
        {
            Console.WriteLine($"GET ALL: available: {Storage.Count}");
            var listConferences = Storage.ListConferences();
            return CreateResponse(listConferences);
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
            var conference = Storage.GetConference(section);
            return conference != null ? CreateResponse(conference.Info) : CreateResponse(null, HttpStatusCode.NotFound);
            //������ �����������, �� ��� �� ����� ��������� ����� ������
            //throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// <summary>
        ///     ������������ ����� ������ � ������� � ����� ����������
        /// </summary>
        /// <param name="section">�������� ������</param>
        /// <param name="conferenceInfo">��������� ���������� � �����������</param>
        [HttpPut]
        [Route("{section}/info")]
        public IHttpActionResult RegisterSectionInfo(string section, [FromBody] ConferenceInfo conferenceInfo)
        {
            Console.WriteLine($"PUT: {section} -> {conferenceInfo}");
            var conference = Storage.GetConference(section);
            if (conference == null)
            {
                conference = new Conference { Section = section, Info = conferenceInfo };
            }
            else
            {
                conference.Info = conferenceInfo;
            }
            Storage.AddOrUpdate(conference);
            
            return CreateResponse(null);
        }

        private ResponseMessageResult CreateResponse(object payload, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ResponseMessageResult(Request.CreateResponse(statusCode, payload));
        }

    }
}