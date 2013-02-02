using System.Runtime.InteropServices;
using System.Windows.Forms;
using VanillaSniffer.Database;
using VanillaSniffer.Proxy;

namespace VanillaSniffer
{
    public partial class Form1 : Form
    {
        public DatabaseManager DatabaseManager;
        public ProxyManager ProxyManager;

        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            ProxyManager = new ProxyManager();
            DatabaseManager = new DatabaseManager();
            
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
