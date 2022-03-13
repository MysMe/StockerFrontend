using StockerFrontend.Natives.LanCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Modals.Global
{
    public partial class UDPListen : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        public UDPReceiver? receiver = null;
        public UDPMessage? message = null;

        private ushort UDPPort = 40404;

        public string? output = null;

        List<string> addresses = new List<string>();

        public UDPListen()
        {
            InitializeComponent();
            InitialiseBackgroundWorker();
            FormClosing += new FormClosingEventHandler(UDPListen_FormClosing);
            worker.RunWorkerAsync();
            label1.Text += UDPPort.ToString();
        }

        ~UDPListen()
        {
            worker.CancelAsync();
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

            receiver = new UDPReceiver(UDPPort);
            message = null;

            while (worker.CancellationPending == false)
            {
                message = receiver.AwaitMessage(300);
                if (message != null)
                {
                    if (message.GetRequest() == UDPRequest.requestAddress)
                    {
                        receiver.Respond(message, UDPRequest.respondAddress);
                        if (!addresses.Contains(message.GetAddress().ToString()))
                        {
                            addresses.Add(message.GetAddress().ToString());
                            worker.ReportProgress(0);
                        }
                    }
                    else if (message.GetRequest() == UDPRequest.requestLink)
                    {
                        DialogResult result = MessageBox.Show(message.GetAddress().ToString() + " would like to send a file.", "Accept connection?", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            //Use a report to swap back to the calling thread
                            worker.ReportProgress(100);
                            return;
                        }
                        else
                        {
                            receiver.Respond(message, UDPRequest.denyLink);
                        }
                    }
                }
            }
        }

        private void UDPListen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.WorkerSupportsCancellation == true)
            {
                worker.CancelAsync();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Close();
        }

        // This event handler updates the progress bar.
        private void WorkerProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                Close();
            }
        }
    }
}
