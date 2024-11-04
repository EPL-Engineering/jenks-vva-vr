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
        private ControllerSettings _settings;

        public ScenePropertiesDialog(ControllerSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            dotSizeNumeric.FloatValue = _settings.dotProperties.size_deg;
            dotDensityNumeric.FloatValue = _settings.dotProperties.density_deg2;
            dotVelocityNumeric.FloatValue = _settings.dotProperties.sdVelocity_deg_per_s;

            barWidthNumeric.FloatValue = _settings.wallProperties.barWidth_m;
            barSpacingNumeric.FloatValue = _settings.wallProperties.barSpacing_m;
            wallDistanceNumeric.FloatValue = _settings.wallProperties.wallDistance_m;
            wallHeightNumeric.FloatValue = _settings.wallProperties.wallHeight_m;
            wallOffsetNumeric.FloatValue = _settings.wallProperties.wallOffset_m;

            amplitudeNumeric.FloatValue = _settings.defaultAmplitude_degrees;
            durationNumeric.FloatValue = _settings.defaultBaselineDuration_s;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            _settings.dotProperties.size_deg = dotSizeNumeric.FloatValue;
            _settings.dotProperties.density_deg2 = dotDensityNumeric.FloatValue;
            _settings.dotProperties.sdVelocity_deg_per_s = dotVelocityNumeric.FloatValue;

            _settings.wallProperties.barWidth_m = barWidthNumeric.FloatValue;
            _settings.wallProperties.barSpacing_m = barSpacingNumeric.FloatValue;
            _settings.wallProperties.wallDistance_m = wallDistanceNumeric.FloatValue;
            _settings.wallProperties.wallHeight_m = wallHeightNumeric.FloatValue;
            _settings.wallProperties.wallOffset_m = wallOffsetNumeric.FloatValue;

            _settings.defaultAmplitude_degrees = amplitudeNumeric.FloatValue;
            _settings.defaultBaselineDuration_s = durationNumeric.FloatValue;

            Close();
        }
    }
}
