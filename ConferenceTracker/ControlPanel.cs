using System;
using System.Windows.Forms;
using ConferenceTracker.core;

namespace ConferenceTracker
{
    public partial class ControlPanel : Form
    {
        private string Address => addressTextFld.Text;


        public ControlPanel()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            startBtn.Text = Server.Instance.Running ? "Стоп" : "Старт";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (Server.Instance.Running)
            {
                Server.Instance.Stop();
            }
            else
            {
                Server.Instance.Start(Address);
            }
            
            InitControls();
        }

    }

}