using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives.LanCon
{
    //Represents an optional string as is returned from some TCPReceiver functions
    public class TCPReceiverContent
    {
        private IntPtr contents = IntPtr.Zero;


        [DllImport("LanCon.dll")]
        private static extern IntPtr TCPReceiver_string_delete(IntPtr ptr);


        public TCPReceiverContent(IntPtr str)
        {
            contents = str;
        }

        ~TCPReceiverContent()
        {
            TCPReceiver_string_delete(contents);
        }

        public string Contents()
        {
            string? ret = Marshal.PtrToStringAnsi(contents);
            if (ret == null)
                return "";
            return ret;
        }

        public override string ToString()
        {
            return Contents();
        }
    }
    public class TCPReceiver
    {
        IntPtr obj = IntPtr.Zero;

        [DllImport("LanCon.dll")]
        private static extern IntPtr TCPReceiver_new(ushort port);

        [DllImport("LanCon.dll")]
        private static extern void TCPReceiver_delete(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern IntPtr TCPReceiver_await_accept_new(IntPtr obj, ushort timeoutMS);

        [DllImport("LanCon.dll")]
        private static extern IntPtr TCPReceiver_await_message_new(IntPtr obj, ushort timeoutMS);

        [DllImport("LanCon.dll")]
        private static extern void TCPReceiver_clear_message(IntPtr obj);


        [DllImport("LanCon.dll")]
        private static extern double TCPReceiver_get_message_percentage(IntPtr obj);

        public TCPReceiver(ushort port)
        {
            obj = TCPReceiver_new(port);
        }

        ~TCPReceiver()
        {
            TCPReceiver_delete(obj);
        }

        //Returns either null or a string wrapper containing the address of the accepted endpoint
        public TCPReceiverContent? AwaitAccept(ushort timeoutMS)
        {
            return new TCPReceiverContent(TCPReceiver_await_accept_new(obj, timeoutMS));
        }

        public TCPReceiverContent? AwaitMessage(ushort timeoutMS)
        {
            IntPtr v = TCPReceiver_await_message_new(obj, timeoutMS);
            if (v == IntPtr.Zero)
                return null;
            return new TCPReceiverContent(v);
        }

        public void ClearMessage()
        {
            TCPReceiver_clear_message(obj);
        }

        public double GetMessagePercentage()
        {
            return TCPReceiver_get_message_percentage(obj);
        }
    }
}
