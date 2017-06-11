using System.Net;
using System.Net.Http;
using Common.data;
using Newtonsoft.Json;

namespace Common.helper {
    public class Helpers {
        public static T Get<T>(string url) where T : class {
            HttpStatusCode code;
            return Get<T>(url, out code);
        }

        public static T Get<T>(string url, out HttpStatusCode responseCode) where T : class {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;
            responseCode = response.StatusCode;
            if (HttpStatusCode.OK != response.StatusCode) {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T Put<T>(string url, ConferenceInfo conferenceInfo) {
            HttpStatusCode responseCode;
            return Put<T>(url, conferenceInfo, out responseCode);
        }

        public static T Put<T>(string url, ConferenceInfo conferenceInfo, out HttpStatusCode responseCode) {
            var client = new HttpClient();
            var response = client.PutAsJsonAsync(url, conferenceInfo).Result;
            responseCode = response.StatusCode;
            return response.Content.ReadAsAsync<T>().Result;
        }
    }
}