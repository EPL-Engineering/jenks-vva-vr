using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using KLib.Controls;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class TestTable : KUserControl
    {
        private int _selectedRow = -1;

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

        public void FillTable(List<TestSpecification> tests, int nextTest)
        {
            _ignoreEvents = true;

            dgv.Rows.Clear();
            foreach (var t in tests)
            {
                int rowIndex = dgv.Rows.Add();
                var cells = dgv.Rows[rowIndex].Cells;

                dgv.Rows[rowIndex].HeaderCell.Value = (rowIndex + 1).ToString();

                dgv.Rows[rowIndex].DefaultCellStyle.ForeColor = (rowIndex < nextTest) ? Color.LightGray : Color.Black;

                cells["BaselineScene"].Value = t.baselineScene;
                cells["BaselineDuration"].Value = t.baselineDuration_s;
                cells["Source"].Value = t.motionSource;
                cells["Direction"].Value = t.motionDirection;
                cells["Amplitude"].Value = t.amplitude_degrees;
                cells["Frequency"].Value = t.frequency_Hz;
                cells["Gain"].Value = t.gain;
                cells["Duration"].Value = t.duration_s;
            }

            if (nextTest < tests.Count)
            {
                _selectedRow = nextTest;
                dgv.CurrentCell = dgv.Rows[nextTest].Cells[0];
                dgv.Rows[nextTest].Selected = true;
            }
            else
            {
                _selectedRow = -1;
                dgv.CurrentCell = null;
            }

            dgv.Refresh();

            _ignoreEvents = false;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            if (_selectedRow >= 0)
            {
                dgv.CurrentCell = dgv.Rows[_selectedRow].Cells[0];
                dgv.Rows[_selectedRow].Selected = true;
            }
            else
            {
                dgv.CurrentCell = null;
            }
        }

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
