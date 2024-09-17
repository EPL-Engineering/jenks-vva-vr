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

        private const int _maxRows = 3;

        public TestTable()
        {
            InitializeComponent();

            var col = dgv.Columns["Scene"] as DataGridViewComboBoxColumn;
            col.DataSource = Enum.GetValues(typeof(Scene));
            col.ValueType = typeof(Scene);

            col = dgv.Columns["Source"] as DataGridViewComboBoxColumn;
            col.DataSource = Enum.GetValues(typeof(MotionSource));
            col.ValueType = typeof(MotionSource);

            col = dgv.Columns["Motion"] as DataGridViewComboBoxColumn;
            col.DataSource = Enum.GetValues(typeof(MotionDirection));
            col.ValueType = typeof(MotionDirection);
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
                AddRow(Value[testIndex]);
            }
            _ignoreEvents = false;

            dgv.ClearSelection();
        }

        private void AddRow(TestSpecification test)
        {
            int rowIndex = dgv.Rows.Add();
            var cells = dgv.Rows[rowIndex].Cells;

            cells["Scene"].Value = test.scene;
            cells["Source"].Value = MotionSource.None.ToString();
            cells["Duration"].Value = test.duration_s.ToString();
        }

        private void CustomizeDisplayForType()
        {
            if (Type == MotionSource.None)
            {
                DisableColumn("Source", showName: true);
                DisableColumn("Motion");
                DisableColumn("Amplitude");
                DisableColumn("Velocity");
                DisableColumn("Gain");
            }
        }

        private void DisableColumn(string name, bool showName = false)
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
            col.DefaultCellStyle.BackColor = Color.FromArgb(216, 216, 216);
            dgv.Columns.Insert(index, col);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_ignoreEvents && e.RowIndex > -1)
            {
                var cells = dgv.Rows[e.RowIndex].Cells;
                if (e.ColumnIndex == 0)
                {
                    Value[e.RowIndex].scene = (Scene)cells["Scene"].Value;
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
            SelectedRow = dgv.CurrentRow.Index;
        }
    }
}
