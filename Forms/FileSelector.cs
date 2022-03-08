using StockerFrontend.Forms;
using StockerFrontend.Modals.Global;
using StockerFrontend.Natives;
using StockerFrontend.Natives.LanCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend
{
    public partial class FileSelector : Form
    {
        UnifiedTable unified = new UnifiedTable();
        StockCountTable count = new StockCountTable();

        public FileSelector(UnifiedTable unified, StockCountTable count)
        {
            this.unified = unified;
            this.count = count;
            InitializeComponent();

            UDPListen form = new UDPListen();
            form.Show();
        }

        private static void LanConTest()
        {
            UDPReceiver UDP = new UDPReceiver(40404);
            UDPMessage? UDPM = null;
            while (true)
            {
                UDPM = UDP.AwaitMessage(500);
                if (UDPM != null)
                {
                    if (UDPM.GetRequest() == UDPRequest.requestAddress)
                    {
                        Console.Write("!");
                    }
                    else if (UDPM.GetRequest() == UDPRequest.requestLink)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("?");
                    }
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine("");
            Console.WriteLine(UDPM.GetAddress().ToString() + " would like to open a link, accept? [Y/N]");
            char key = '\0';
            do
            {
                key = (char)Console.Read();
            } while (key != 'Y' && key != 'N');
            if (key == 'N')
            {
                UDP.Respond(UDPM, UDPRequest.denyLink);
                Console.WriteLine("Connection denied.");
                return;
            }

            Console.WriteLine("Accepted link, awaiting connection.");

            TCPReceiver TCP = new TCPReceiver(UDPM.GetAdditional());

            TCPReceiverContent? content = null;


            UDP.Respond(UDPM, UDPRequest.acceptLink);
            while ((content = TCP.AwaitAccept(1000)) == null)
            {
                Console.Write(".");
                UDP.Respond(UDPM, UDPRequest.acceptLink);
            }

            Console.WriteLine("");
            Console.WriteLine(content.ToString() + " connected.");

            content = null;
            while ((content = TCP.AwaitMessage(1000)) == null)
            {
                Console.Write(".");
            }

            Console.WriteLine("");
            Console.WriteLine("Received: ");
            Console.WriteLine(content.ToString());
            return;
        }

        private static string? getFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private void SelectCountButton_Click(object sender, EventArgs e)
        {
            string? file = getFile();
            if (file != null)
            {
                if (count.Load(file) == 0)
                {
                    SelectStockFile.Enabled = true;
                    SelectCountButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Unable to parse count file.");
                }
            }
        }

        private void SelectStockFile_Click(object sender, EventArgs e)
        {
            string? file = getFile();
            if (file != null)
            {
                int res = unified.load(file, count);
                if (res == 1)
                {
                    //All translations present
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (res == -1)
                {
                    //Error
                    MessageBox.Show("Unable to parse input XLS file.");
                }
                else
                {
                    //Translations required
                    TranslationManager form = new TranslationManager(unified, count);
                    this.Hide();
                    form.ShowDialog();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
