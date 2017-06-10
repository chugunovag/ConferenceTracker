using System;
using Common.data;
using Common.helper;

namespace StressTest
{
    /// <summary>
    /// Сервер на месте проведения конкретной секции конференции
    /// Осуществляет регистрацию на центральном сервере.
    /// </summary>
    class InPlaceServer
    {
        /// <summary>
        /// данные о секции конференции
        /// </summary>
        public Conference Conference { get; set; }

        public string CentralUrl { get; set; }

        public InPlaceServer(Conference conference, string url)
        {
            Conference = conference;
            CentralUrl = url.EndsWith(@"/") ? url : url + "/";
        }

        /// <summary>
        /// Первичная региcтрация секции (т.н. advertise)
        /// </summary>
        public void RegisterSection()
        {
            Console.WriteLine($"Register: {Conference}");
            Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", null);
        }

        /// <summary>
        /// Регистрация данных о секции (адрес и прочее)
        /// </summary>
        public void RegisterSectionData()
        {
            Console.WriteLine($"Register: {Conference}");
            Helpers.Put<Conference>($"{CentralUrl}conference/{Conference.Section}/info", Conference.Info);
        }

    }

}
