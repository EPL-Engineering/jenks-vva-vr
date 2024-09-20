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
    public partial class ControlTable : KUserControl
    {
        public List<ControlSpecification> Value { set; get; } = null;

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

        public ControlTable()
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

        public void FillTable(List<ControlSpecification> test)
        {
            _ignoreEvents = true;

            Value = test;

            dgv.Rows.Clear();
            for (int k=0; k<Value.Count; k++)
            {
                var testIndex = Math.Min(k, Value.Count - 1);
                AddRow(Value[testIndex]);
            }
            SelectedRow = -1;
            dgv.ClearSelection();

            _ignoreEvents = false;

        }

        private void AddRow(ControlSpecification test)
        {
            int rowIndex = dgv.Rows.Add();
            var cells = dgv.Rows[rowIndex].Cells;

            cells["Scene"].Value = test.scene;
            cells["Motion"].Value = test.motionDirection;
            cells["Amplitude"].Value = test.amplitudeDegrees;
            cells["Velocity"].Value = test.frequencyHz;
            cells["Gain"].Value = test.gain;
            cells["Duration"].Value = test.duration_s.ToString();

        }

        //private void DisableColumn(string name, bool showName = false)
        //{
        //    var col = dgv.Columns[name];
        //    var index = col.Index;
        //    var headerText = col.HeaderText;
        //    var width = col.Width;
        //    dgv.Columns.RemoveAt(index);

        //    col = new DataGridViewTextBoxColumn();
        //    col.Name = name;
        //    if (showName)
        //    {
        //        col.HeaderText = headerText;
        //    }
        //    col.Width = width;
        //    col.ReadOnly = true;
        //    col.DefaultCellStyle.BackColor = Color.FromArgb(216, 216, 216);
        //    dgv.Columns.Insert(index, col);
        //}

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_ignoreEvents && e.RowIndex > -1)
            {
                var cells = dgv.Rows[e.RowIndex].Cells;
                if (e.ColumnIndex == 0)
                {
                    Value[e.RowIndex].scene = (Scene)cells["Scene"].Value;
                }
                else if (e.ColumnIndex == 1)
                {
                    Value[e.RowIndex].motionDirection = (MotionDirection) cells["Motion"].Value;
                }
                else if (e.ColumnIndex == 2)
                {
                    Value[e.RowIndex].amplitudeDegrees = float.Parse(cells["Amplitude"].Value.ToString());
                }
                else if (e.ColumnIndex == 3)
                {
                    Value[e.RowIndex].frequencyHz = float.Parse(cells["Frequency"].Value.ToString());
                }
                else if (e.ColumnIndex == 4)
                {
                    Value[e.RowIndex].gain = float.Parse(cells["Gain"].Value.ToString());
                }
                else if (e.ColumnIndex == 5)
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
