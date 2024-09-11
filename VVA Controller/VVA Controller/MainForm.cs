using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Net;

namespace VVA_Controller
{
    public partial class MainForm : Form
    {
        private IPEndPoint _ipEndPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ipEndPoint = Discovery.Discover("VVA VR");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KTcpClient.SendCommand(_ipEndPoint.Address.ToString(), _ipEndPoint.Port, "Ping");
        }
    }
}
