using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Packet_Monitor
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmbProcess_MouseDown(object sender, MouseEventArgs e)
        {
            cmbProcess.Items.Clear();

            foreach (Process process in Process.GetProcessesByName("Wow"))
            {
                cmbProcess.Items.Add(process.Id);
            }
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid = int.Parse(cmbProcess.Text);

            Globals.Process = Process.GetProcessById(pid);
            Globals.Magic.OpenProcessAndThread(pid);

            Offsets.Initialize();

            btnStart.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            NetClient.Send2.Hook();
            NetClient.ProcessMessage.Hook();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            tmrRefresh.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            NetClient.Send2.Unhook();
            NetClient.ProcessMessage.Unhook();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tmrRefresh.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataPackets.Rows.Clear();
        }
        
        private void dataPackets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 1) return;

            Clipboard.SetDataObject(dataPackets.Rows[e.RowIndex].Cells[1].Value);
            toolTip.Show("Copied packet data to clipboard!", this, MousePosition.X - this.Left + 12, MousePosition.Y - this.Top, 2000);
        }
        
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            byte[] packet = NetClient.Send2.Read();

            if (packet != null)
            {
                dataPackets.Rows.Add(BitConverter.ToInt32(packet, 0).ToString("X"),
                                     packet.Aggregate("", (current, b) => current + (b.ToString("X2") + " ")),
                                     DateTime.Now.ToString("HH:mm:ss.fff"),"CMSG");
            }

            byte[] outpacket = NetClient.ProcessMessage.Read();

            if (outpacket != null)
            {
                dataPackets.Rows.Add(BitConverter.ToInt32(outpacket, 0).ToString("X"),
                                     outpacket.Aggregate("", (current, b) => current + (b.ToString("X2") + " ")),
                                     DateTime.Now.ToString("HH:mm:ss.fff"),"SMSG");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetClient.Send2.Unhook();
            NetClient.ProcessMessage.Unhook();
        }

    }
}
