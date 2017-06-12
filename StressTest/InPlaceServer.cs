using System;
using Common.data;
using Common.helper;
using log4net;

namespace StressTest {
    /// <summary>
    ///     Сервер на месте проведения конкретной секции конференции (периферийный).
    ///     Осуществляет регистрацию на центральном сервере.
    /// </summary>
    internal class InPlaceServer {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InPlaceServer));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conference">конференция для данного сервера. Из нее будет использован идентификатор секции.</param>
        /// <param name="url">правильный адрес уентральногосервера (со слэшем в конце)</param>
        public InPlaceServer(Conference conference, string url) {
            Conference = conference;
            CentralUrl = url;
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
                Log.Debug($"Try register section {Conference}");
                Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", null);
            }
            catch (Exception e) {
                Log.Error("Can't register section",  e);
            }
        }

        /// <summary>
        ///     Регистрация данных о секции (адрес и прочее). Exception safe.
        /// </summary>
        public void RegisterSectionData() {
            try {
                Log.Debug($"Try register section {Conference}");
                Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", Conference.Info);
            }
            catch (Exception e) {
                Log.Error("Can't register section", e);
            }
        }
    }
}