using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives.LanCon
{
    public class UDPReceiver
    {
        private IntPtr obj = IntPtr.Zero;


        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPReceiver_new(ushort port);

        [DllImport("LanCon.dll")]
        private static extern void UDPReceiver_delete(IntPtr obj);


        [DllImport("LanCon.dll")]
        private static extern void UDPReceiver_respond(IntPtr obj, IntPtr target, byte request);


        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPReceiver_await_message_new(IntPtr obj, ushort timeoutMS);


        public UDPReceiver(ushort port)
        {
            obj = UDPReceiver_new(port);
        }

        ~UDPReceiver()
        {
            UDPReceiver_delete(obj);
        }

        public void Respond(UDPMessage respondTo, UDPRequest response)
        {
            UDPReceiver_respond(obj, respondTo.Ptr(), (byte)response);
        }

        public UDPMessage? AwaitMessage(ushort timeoutMS)
        {
            IntPtr v = UDPReceiver_await_message_new(obj, timeoutMS);
            if (v == IntPtr.Zero)
                return null;
            return new UDPMessage(v);
        }

        public void Destruct()
        {
            UDPReceiver_delete(obj);
            obj = IntPtr.Zero;
        }
    }
}
