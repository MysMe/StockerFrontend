using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives.LanCon
{
    public class TCPSender
    {
        private IntPtr obj = IntPtr.Zero;

        [DllImport("LanCon.dll")]
        private static extern IntPtr TCPSender_new();

        [DllImport("LanCon.dll")]
        private static extern void TCPSender_delete(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern bool TCPSender_connect(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string IP, ushort port, ushort timeoutMS);

        [DllImport("LanCon.dll")]
        private static extern bool TCPSender_connected(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern void TCPSender_disconnect(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern void TCPSender_send(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string message);


        public TCPSender()
        {
            obj = TCPSender_new();
        }

        ~TCPSender()
        {
            TCPSender_delete(obj);
        }

        public bool Connect(string IP, ushort port, ushort timeoutMS)
        {
            return TCPSender_connect(obj, IP, port, timeoutMS);
        }
        public bool Connected()
        {
            return TCPSender_connected(obj);
        }

        public void Disconnect()
        {
            TCPSender_disconnect(obj);
        }

        public void Send(string message)
        {
            TCPSender_send(obj, message);
        }
    }
}
