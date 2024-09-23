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
    public partial class HeadsetDialog : Form
    {
        private IPEndPoint _ipEndPoint;

        public HeadsetDialog(IPEndPoint ipEndPoint)
        {
            _ipEndPoint = ipEndPoint;

            InitializeComponent();
        }

        private async void HeadsetDialog_Shown(object sender, EventArgs e)
        {
            await GetHeadsetInformation();
        }

        private async Task GetHeadsetInformation()
        {
            infoTextBox.Text = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetHeadsetInformation");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            KTcpClient.SendMessage(_ipEndPoint, "DoEyeCalibration");
        }

    }
}
