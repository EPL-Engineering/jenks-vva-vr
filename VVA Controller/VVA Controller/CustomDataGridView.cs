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

namespace VVA_Controller
{
    public partial class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Extract the key code from the key value. 
            Keys key = (keyData & Keys.KeyCode);

            //// Handle the ENTER key as if it were a RIGHT ARROW key. 
            if (key == Keys.Enter || key == Keys.Return)
            {
                if (CurrentCell.ColumnIndex < Columns.Count - 2)
                    return this.ProcessRightKey(keyData);
                else
                    return this.ProcessLeftKey(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
