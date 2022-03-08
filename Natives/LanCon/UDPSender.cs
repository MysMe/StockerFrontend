using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives.LanCon
{
    public class UDPSender
    {
        IntPtr obj = IntPtr.Zero;


        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPSender_new(ushort port);

        [DllImport("LanCon.dll")]
        private static extern void UDPSender_delete(IntPtr obj);


        [DllImport("LanCon.dll")]
        private static extern void UDPSender_request_addresses(IntPtr obj);


        [DllImport("LanCon.dll")]
        private static extern void UDPSender_request_link(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string IP, ushort port);


        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPSender_await_response_new(IntPtr obj, ushort timeoutMS);


        public UDPSender(ushort port)
        {
            obj = UDPSender_new(port);
        }

        ~UDPSender()
        {
            UDPSender_delete(obj);
        }

        public void RequestAddresses()
        {
            UDPSender_request_addresses(obj);
        }

        public void RequestLink(string IP, ushort linkPort)
        {
            UDPSender_request_link(obj, IP, linkPort);
        }

        public UDPMessage? AwaitResponse(ushort timeoutMS)
        {
            IntPtr v = UDPSender_await_response_new(obj, timeoutMS);
            if (v == IntPtr.Zero)
                return null;
            return new UDPMessage(v);
        }
    }
}
