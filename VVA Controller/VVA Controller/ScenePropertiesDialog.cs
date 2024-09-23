using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class ScenePropertiesDialog : Form
    {
        public DotProperties DotProperties { set; get; }
        public GratingProperties GratingProperties { set; get; }

        public ScenePropertiesDialog()
        {
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            dotSizeNumeric.FloatValue = DotProperties.size_deg;
            dotDensityNumeric.FloatValue = DotProperties.density_deg2;
            dotVelocityNumeric.FloatValue = DotProperties.sdVelocity_deg_per_s;

            barWidthNumeric.FloatValue = GratingProperties.size_deg;
            barDensityNumeric.FloatValue = GratingProperties.density_deg;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            DotProperties.size_deg = dotSizeNumeric.FloatValue;
            DotProperties.density_deg2 = dotDensityNumeric.FloatValue;
            DotProperties.sdVelocity_deg_per_s = dotVelocityNumeric.FloatValue;

            GratingProperties.size_deg = barWidthNumeric.FloatValue;
            GratingProperties.density_deg = barDensityNumeric.FloatValue;

            Close();
        }
    }
}
