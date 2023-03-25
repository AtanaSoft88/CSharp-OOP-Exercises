using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Mocking
{
    //Implement externally to pop up a dialog box with message
    public class MessageBoxWriter : IWriter
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public void Write(string message)
        {
            MessageBox(new IntPtr(0),message, message, 0);
        }
    }
}
