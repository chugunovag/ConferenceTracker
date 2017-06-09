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
    ///     Контроллер для управления запросами конференций
    /// </summary>
    [RoutePrefix("conference")]
    public class ConferenceController : ApiController
    {
        public static Dictionary<string, Conference> Storage { get; } = new Dictionary<string, Conference>();

        /// <summary>
        ///     Найти и вернуть список всех когда-либо зарегистрированных конференций
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
        ///     Найти конференцию по секции.
        /// </summary>
        /// <param name="section">Идентификатор секции</param>
        /// <returns>Конференция, либо пусто, если конференций по данной секции не было зарегистрировано</returns>
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
        ///     Регистрирует новую конференцию
        /// </summary>
        /// <param name="section">Название секции</param>
        /// <param name="conferenceInfo">подробная информация о конференции</param>
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