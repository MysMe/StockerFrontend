using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Other
{
    public class GridDoubleBufferring
    {
        public static void Enable(DataGridView view)
        {
            //Datagridviews support double bufferring (a common visual smoothing technique)
            //While more performance intensive, this vastly improves the visual quality of the table
            //which has a tendency to lag.
            //However, the attribute is normally hidden. As such, we enable it by using reflection
            //to bypass the access restriction.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                view, new object[] { true });
        }
    }
}
