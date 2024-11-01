using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using KLib.Controls;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class TestTable : KUserControl
    {
        public List<TestSpecification> Value { set; get; } = null;
        public List<int> Completed { set; get; } = null;

        public TestTable()
        {
            InitializeComponent();
        }

        public void ClearTable()
        {
            dgv.Rows.Clear();
            for (int k = 0; k < 8; k++ )
            {
                int rowIndex = dgv.Rows.Add();
                var cells = dgv.Rows[rowIndex].Cells;
            }

            dgv.CurrentCell = null;
            dgv.Refresh();
        }

        public void FillTable()
        {
            _ignoreEvents = true;

            dgv.Rows.Clear();
            foreach (var t in Value)
            {
                int rowIndex = dgv.Rows.Add();
                var cells = dgv.Rows[rowIndex].Cells;

                cells["BaselineScene"].Value = t.baselineScene;
                cells["BaselineDuration"].Value = t.baselineDuration_s;
                cells["Source"].Value = t.motionSource;
                cells["Direction"].Value = t.motionDirection;
                cells["Amplitude"].Value = t.amplitude_degrees;
                cells["Frequency"].Value = t.frequency_Hz;
                cells["Gain"].Value = t.gain;
                cells["Duration"].Value = t.duration_s;
            }

            dgv.CurrentCell = null;
            dgv.Refresh();

            _ignoreEvents = false;
        }

        //private void SetGainCellProperties(DataGridViewCell c, MotionDirection motionDirection, float gain)
        //{
        //    if (motionDirection == MotionDirection.RollTilt)
        //    {
        //        c.Value = 1;
        //        c.Style.BackColor = Color.FromArgb(216, 216, 216);
        //        c.ReadOnly = true;
        //    }
        //    if (motionDirection == MotionDirection.Translation)
        //    {
        //        c.Value = gain;
        //        c.Style.BackColor = Color.White;
        //        c.ReadOnly = false;
        //    }
        //}
        private IDesignerHost designerHost;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                var designer = (ControlDesigner) designerHost?.GetDesigner(this);
                designer?.Verbs?.Add(new DesignerVerb("Preview with dummy data", (o, a) =>
                {
                    //Some logic to add dummy rows, just for example
                    dgv.Rows.Clear();
                    if (dgv.Columns.Count > 0)
                    {
                        var values = dgv.Columns.Cast<DataGridViewColumn>()
                            .Select(x => GetDummyData(x)).ToArray();
                        for (int i = 0; i < 8; i++)
                            dgv.Rows.Add(values);
                    }
                }));
                designer?.Verbs?.Add(new DesignerVerb("Clear data", (o, a) =>
                {
                    dgv.Rows.Clear();
                }));
            }
        }
        private object GetDummyData(DataGridViewColumn column)
        {
            //You can put some logic to generate dummy data based on column type, etc.
            return "Sample";
        }
    }
}
