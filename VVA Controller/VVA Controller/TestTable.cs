using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class TestTable : KUserControl
    {
        public MotionSource Type { set; get; }
        public List<TestSpecification> Value { set; get; } = null;

        public int SelectedRow { private set; get; }
        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
            {
                SelectionChanged(this, null);
            }
        }

        private const int _maxRows = 3;

        public TestTable()
        {
            InitializeComponent();

            var col = dgv.Columns["Scene"] as DataGridViewComboBoxColumn;
            col.DataSource = Enum.GetValues(typeof(Scene));
            col.ValueType = typeof(Scene);

            col = dgv.Columns["Motion"] as DataGridViewComboBoxColumn;
            col.DataSource = Enum.GetValues(typeof(MotionDirection));
            col.ValueType = typeof(MotionDirection);
        }

        public void ClearSelection()
        {
            _ignoreEvents = true;
            dgv.ClearSelection();
            _ignoreEvents = false;
        }

        public void FillTable(MotionSource type, List<TestSpecification> test)
        {
            _ignoreEvents = true;

            Type = type;
            Value = test;

            CustomizeDisplayForType();

            dgv.Rows.Clear();
            for (int k=0; k<_maxRows; k++)
            {
                var testIndex = Math.Min(k, Value.Count - 1);
                Value[testIndex].motionSource = Type;

                if (Type == MotionSource.Internal)
                {
                    Value[testIndex].gain = 1;
                }


                AddRow(Value[testIndex]);
            }

            dgv.Refresh();
            for (int kc = 3; kc < dgv.Columns.Count; kc++)
            {
                dgv.Columns[kc].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            SelectedRow = -1;
            dgv.ClearSelection();

            _ignoreEvents = false;

        }

        private void AddRow(TestSpecification test)
        {
            int rowIndex = dgv.Rows.Add();
            var cells = dgv.Rows[rowIndex].Cells;

            cells["BaselineScene"].Value = test.baselineScene;
            cells["Source"].Value = test.motionSource.ToString();
            cells["Duration"].Value = test.duration_s.ToString();

            cells["Motion"].Value = test.motionDirection;
            SetGainCellProperties(cells["Gain"], test.motionDirection, test.gain);

            if (test.motionSource == MotionSource.Internal)
            {
                cells["Amplitude"].Value = test.amplitude_degrees.ToString();
                cells["Frequency"].Value = test.frequency_Hz;
            }
        }

        private void SetGainCellProperties(DataGridViewCell c, MotionDirection motionDirection, float gain)
        {
            if (motionDirection == MotionDirection.RollTilt)
            {
                c.Value = 1;
                c.Style.BackColor = Color.FromArgb(216, 216, 216);
                c.ReadOnly = true;
            }
            if (motionDirection == MotionDirection.Translation)
            {
                c.Value = gain;
                c.Style.BackColor = Color.White;
                c.ReadOnly = false;
            }
        }

        private void CustomizeDisplayForType()
        {
            if (Type == MotionSource.Internal)
            {
                //DisableColumn("Gain");
            }
            else if (Type == MotionSource.UDP)
            {
                DisableColumn("Amplitude");
                DisableColumn("Frequency");
            }
        }

        private void DisableColumn(string name, bool showName = true)
        {
            var col = dgv.Columns[name];
            var index = col.Index;
            var headerText = col.HeaderText;
            var width = col.Width;
            dgv.Columns.RemoveAt(index);

            col = new DataGridViewTextBoxColumn();
            col.Name = name;
            if (showName)
            {
                col.HeaderText = headerText;
            }
            col.Width = width;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.BackColor = Color.FromArgb(216, 216, 216);

            col.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.Resizable = DataGridViewTriState.False;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.Columns.Insert(index, col);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_ignoreEvents && e.RowIndex > -1)
            {
                var cells = dgv.Rows[e.RowIndex].Cells;
                if (e.ColumnIndex == 0)
                {
                    Value[e.RowIndex].baselineScene = (Scene)cells["Scene"].Value;
                }
                else if (e.ColumnIndex == 2)
                {
                    Value[e.RowIndex].motionDirection = (MotionDirection) cells["Motion"].Value;
                    SetGainCellProperties(cells["Gain"], Value[e.RowIndex].motionDirection, Value[e.RowIndex].gain);
                }
                else if (e.ColumnIndex == 3)
                {
                    Value[e.RowIndex].amplitude_degrees = float.Parse(cells["Amplitude"].Value.ToString());
                }
                else if (e.ColumnIndex == 4)
                {
                    Value[e.RowIndex].frequency_Hz = float.Parse(cells["Frequency"].Value.ToString());
                }
                else if (e.ColumnIndex == 5)
                {
                    if (Value[e.RowIndex].motionDirection == MotionDirection.Translation)
                    {
                        Value[e.RowIndex].gain = float.Parse(cells["Gain"].Value.ToString());
                        Debug.WriteLine("gain = " + Value[e.RowIndex].gain);
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    Value[e.RowIndex].duration_s = float.Parse(cells["Duration"].Value.ToString());
                }

                OnValueChanged();
            }
        }

        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents && dgv.CurrentCell.ColumnIndex < 3)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                SelectedRow = dgv.CurrentRow.Index;
                OnSelectionChanged();
            }
        }

    }
}
