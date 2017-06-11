using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StressTest {
    public partial class TestPanel : Form {
        private readonly TestController _controller;

        public TestPanel() {
            InitializeComponent();
            _controller = new TestController();
            InitControls();
        }

        private string Url => urlBox.Text;

        private string SectionCity => cityBox.Text;
        private string SectionName => infoNameBox.Text;
        private string SectionLocation => locationBox.Text;
        private string SectionRegId => sectionRegisterBox.Text;

        private string SectionSearch => sectionSearchBox.Text;

        /// <summary>
        ///     Пересматриваем состояние, надписи и прочее для интерактивных контролов.
        /// </summary>
        private void InitControls() {
            autoBtn.Text = _controller.IsAutoTestRunning() ? "Стоп" : "Старт";
        }

        /// <summary>
        ///     Включаем режим автоматической периодической регистрации/перерегистрации для каждой секции и места.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoBtn_Click(object sender, EventArgs e) {
            if (!_controller.IsAutoTestRunning()) {
                var cities = citiesListBox.Items.OfType<string>().ToList();
                var streets = streetsListBox.Items.OfType<string>().ToList();
                var sections = sectionsListBox.Items.OfType<string>().ToList();
                _controller.DoAutoTest(Url, cities, streets, sections);
            }
            else {
                _controller.StopAutoTest();
            }
            InitControls();
        }

        /// <summary>
        ///     Ищем секцию по идентификатору секции. Результат смотрим в поле логирования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findOneBtn_Click(object sender, EventArgs e) {
            ClearLog();
            try {
                Log(_controller.GetSection(Url, SectionSearch)?.ToString());
            }
            catch (Exception ex) {
                Log(ex.ToString());
            }
        }

        /// <summary>
        ///     Ищем все последние когда-либо зарегистрированные секции. Результат смотрим в поле логирования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findAllBtn_Click(object sender, EventArgs e) {
            ClearLog();
            try {
                _controller.GetAll(Url)?.ForEach(conference => { Log(conference.ToString()); });
            }
            catch (Exception ex) {
                Log(ex.ToString());
            }
        }

        /// <summary>
        ///     регистрируем секцию используя данные формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regBtn_Click(object sender, EventArgs e) {
            _controller.RegisterSectionManual(Url, SectionRegId, SectionCity, SectionLocation, SectionName);
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            _controller.Dispose();
        }

        /// <summary>
        ///     Выводим строку на поле логирования.
        /// </summary>
        /// <param name="s"></param>
        private void Log(string s) {
            logBox.AppendText($"\n{s}");
        }

        /// <summary>
        ///     чистим поле логирования
        /// </summary>
        private void ClearLog() {
            logBox.Clear();
        }
    }
}