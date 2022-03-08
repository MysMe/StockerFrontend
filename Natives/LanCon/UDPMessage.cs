using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives.LanCon
{

    public enum UDPRequest
    {
        undefined      = 0,
        requestAddress = 1,
        respondAddress = 2,
        requestLink    = 3,
        acceptLink     = 4,
        denyLink       = 5,
    }

    public class UDPAddress
    {
        private IntPtr str = IntPtr.Zero;

        [DllImport("LanCon.dll")]
        private static extern void UDPMessage_address_delete(IntPtr arr);

        public UDPAddress(IntPtr arr)
        {
            str = arr;
        }

        ~UDPAddress()
        {
            UDPMessage_address_delete(str);
        }

        public string Value()
        {
            string? val = Marshal.PtrToStringAnsi(str);
            if (val == null)
                return "";
            return val;
        }
        public override string ToString()
        {
            return Value();
        }
    }
    public class UDPMessage
    {
        private IntPtr obj = IntPtr.Zero;

        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPMessage_delete(IntPtr obj);


        [DllImport("LanCon.dll")]
        private static extern IntPtr UDPMessage_address_new(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern byte UDPMessage_request(IntPtr obj);

        [DllImport("LanCon.dll")]
        private static extern ushort UDPMessage_additional(IntPtr obj);

        public UDPMessage(IntPtr obj)
        {
            this.obj = obj;
        }

        ~UDPMessage()
        {
            UDPMessage_delete(obj);
        }

        public UDPRequest GetRequest()
        {
            return (UDPRequest)UDPMessage_request(obj);
        }

        public ushort GetAdditional()
        {
            return UDPMessage_additional(obj);
        }
        
        public UDPAddress GetAddress()
        {
            return new UDPAddress(UDPMessage_address_new(obj));
        }

        public IntPtr Ptr()
        {
            return obj;
        }
    }
}
