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
using VanillaSniffer.Proxy;

namespace VanillaSniffer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            ProxyManager proxy = new ProxyManager();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
