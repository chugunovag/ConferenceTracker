using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StressTest
{
    public partial class TestPanel : Form
    {
        private readonly TestController _controller;

        private string Url => urlFld.Text;
        
        public TestPanel()
        {
            InitializeComponent();
            _controller = new TestController();
            InitControls();
        }

        private void autoBtn_Click(object sender, EventArgs e)
        {
            if (!_controller.IsAutoTestRunning())
            {
                var cities = citiesListBox.Items.OfType<string>().ToList();
                var streets = streetsListBox.Items.OfType<string>().ToList();
                var sections = sectionsListBox.Items.OfType<string>().ToList();
                _controller.DoAutoTest(Url, cities, streets, sections);
            }
            else
            {
                _controller.StopAutoTest();
            }
            InitControls();
        }

        private void InitControls()
        {
            autoBtn.Text = _controller.IsAutoTestRunning() ? "Стоп" : "Старт";
        }

        private void findOneBtn_Click(object sender, EventArgs e)
        {
            ClearLog();
            try
            {
                Log(_controller.GetSection(Url, sectionTextBox.Text)?.ToString());
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void findAllBtn_Click(object sender, EventArgs e)
        {
            ClearLog();
            try
            {
                _controller.GetAll(Url)?.ForEach(conference =>
                {
                    Log(conference.ToString());
                });
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _controller.Dispose();
        }

        private void Log(string s)
        {
            logBox.AppendText($"\n{s}");
        }

        private void ClearLog()
        {
            logBox.Clear();
        }

    }
}
