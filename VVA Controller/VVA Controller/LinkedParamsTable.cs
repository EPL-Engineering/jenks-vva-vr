using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using KLib.Controls;
using Jenks.VVA;

namespace VVA_Controller
{
    public partial class LinkedParamsTable : KUserControl
    {
        private List<LinkedParams> _value;
        public List<LinkedParams> Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ShowValue();
            }
        }

        public LinkedParamsTable()
        {
            InitializeComponent();
        }

        private void ShowValue()
        {
            if (_value == null) return;

            _ignoreEvents = true;

            dgv.Rows.Clear();
            foreach (var p in _value)
            {
                int rowIndex = dgv.Rows.Add();
                var cells = dgv.Rows[rowIndex].Cells;

                cells["Active"].Value = p.isActive;
                cells["Frequency"].Value = p.frequency_Hz;
                cells["Gain"].Value = p.gain.ToString();
                cells["Duration"].Value = p.duration_s;
            }

            dgv.CurrentCell = null;
            dgv.Refresh();

            _ignoreEvents = false;
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_ignoreEvents && e.RowIndex > -1)
            {
                var cells = dgv.Rows[e.RowIndex].Cells;
                if (e.ColumnIndex == 0)
                {
                    Value[e.RowIndex].isActive = (bool) cells["Active"].Value;
                }
                else if (e.ColumnIndex == 1)
                {
                    Value[e.RowIndex].frequency_Hz = float.Parse(cells["Frequency"].Value.ToString());
                }
                else if (e.ColumnIndex == 2)
                {
                    Value[e.RowIndex].gain = float.Parse(cells["Gain"].Value.ToString());
                }
                else if (e.ColumnIndex == 3)
                {
                    Value[e.RowIndex].duration_s = float.Parse(cells["Duration"].Value.ToString());
                }

                dgv.CurrentCell = null;

                OnValueChanged();
            }
        }

        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents && dgv.CurrentCell.ColumnIndex == 0)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private IDesignerHost designerHost;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                var designer = (ControlDesigner)designerHost?.GetDesigner(this);
                designer?.Verbs?.Add(new DesignerVerb("Preview with dummy data", (o, a) =>
                {
                    //Some logic to add dummy rows, just for example
                    dgv.Rows.Clear();
                    if (dgv.Columns.Count > 0)
                    {
                        var values = dgv.Columns.Cast<DataGridViewColumn>()
                            .Select(x => GetDummyData(x)).ToArray();
                        for (int i = 0; i < 3; i++)
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
            if (column.Name == "Active") return true;
            return "Sample";
        }


    }
}
