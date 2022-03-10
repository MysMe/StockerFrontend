using StockerFrontend.Natives.LanCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Modals.Global
{
    public partial class MessageReceive : Form
    {
        private UDPReceiver UDP;
        private UDPMessage target;
        private TCPReceiver TCP;
        private BackgroundWorker worker = new BackgroundWorker();
        public string? output = null;

        public MessageReceive(UDPReceiver udp, UDPMessage host, ushort port)
        {
            UDP = udp;
            TCP = new TCPReceiver(port);
            target = host;
            InitializeComponent();
            InitialiseBackgroundWorker();
            worker.RunWorkerAsync();
        }


        private void InitialiseBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(Listen);
            worker.ProgressChanged += new ProgressChangedEventHandler(WorkerProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        private void Listen(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker? worker = sender as BackgroundWorker;
            if (worker == null)
                return;

            while (!worker.CancellationPending && TCP.AwaitAccept(300) == null)
            {
                UDP.Respond(target, UDPRequest.acceptLink);
            }

            worker.ReportProgress(0);

            while (worker.CancellationPending == false)
            {
                var message = TCP.AwaitMessage(300);
                worker.ReportProgress((int)(TCP.GetMessagePercentage()));
                if (message != null)
                {
                    output = message.ToString();
                    worker.ReportProgress(100);
                    worker.CancelAsync();
                }
            }
        }


        // This event handler updates the progress bar.
        private void WorkerProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Progress Completed: " + e.ProgressPercentage.ToString();

            if (e.ProgressPercentage == 100)
                button1.Text = "Done";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (worker.WorkerSupportsCancellation == true)
            {
                worker.CancelAsync();
            }
            Close();
        }
    }
}
