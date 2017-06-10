using System.Windows.Forms;

namespace StressTest
{
    public partial class TestPanel : Form
    {

        //        private static readonly ManualResetEvent StopEvent = new ManualResetEvent(false);


        public TestPanel()
        {
            InitializeComponent();
        }

        private void autoBtn_Click(object sender, System.EventArgs e)
        {

        }

        private void findOneBtn_Click(object sender, System.EventArgs e)
        {

        }

        private void findAllBtn_Click(object sender, System.EventArgs e)
        {

        }

        /*  private void registerBtn_Click(object sender, EventArgs e)
                {
                    new Thread(o =>
                    {
                        while (!StopEvent.WaitOne(0))
                        {
                            var uniqueSection = "GIS" + Guid.NewGuid();
                            var result = Helpers.Put<Conference>($"{Program.BaseAddress}conference/{uniqueSection}/info",
                                Helpers.CreateTestConference(uniqueSection).Info);
                            Console.WriteLine(result);
                            Thread.Sleep(20);
                        }
                    }).Start();
                }

                private void getSectionBtn_Click(object sender, EventArgs e)
                {
                    Console.WriteLine(Helpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/GIS/info"));
                }

                private void findAllBtn_Click(object sender, EventArgs e)
                {
                    var conferences = Helpers.Get<List<Conference>>(Program.BaseAddress + "conference/info");
                    if (conferences == null)
                    {
                        Console.WriteLine($"Conferences not found");
                        return;
                    }
                    Console.WriteLine($"Conferences found: {conferences.Count}");
                    foreach (var conference in conferences)
                    {
                        Console.WriteLine($"{conference}");
                    }
                }

                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                    base.OnFormClosing(e);
                  StopEvent.Set();
                }
                */
    }
}
