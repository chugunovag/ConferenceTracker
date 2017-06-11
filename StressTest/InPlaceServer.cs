using System;
using Common.data;
using Common.helper;

namespace StressTest {
    /// <summary>
    ///     Сервер на месте проведения конкретной секции конференции (периферийный).
    ///     Осуществляет регистрацию на центральном сервере.
    /// </summary>
    internal class InPlaceServer {
        public InPlaceServer(Conference conference, string url) {
            Conference = conference;
            CentralUrl = url.EndsWith(@"/") ? url : url + "/";
        }

        /// <summary>
        ///     данные о секции конференции
        /// </summary>
        public Conference Conference { get; set; }

        public string CentralUrl { get; set; }

        /// <summary>
        ///     Первичная региcтрация секции (т.н. advertise запрос) Exception safe.
        /// </summary>
        [Obsolete("Возможно, использование этого метода не актуально  надо уточнить задание.")]
        public void RegisterSection() {
            try {
                Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", null);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        ///     Регистрация данных о секции (адрес и прочее). Exception safe.
        /// </summary>
        public void RegisterSectionData() {
            try {
                Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", Conference.Info);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}