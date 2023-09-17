using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUSimulator
{
    public partial class MemoryViewer : Form
    {
        public MemoryViewer()
        {
            InitializeComponent();
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSize = false;
            Memory.MemoryChanged += Memory_MemoryChanged;
            Memory.SelectedPositionChanged += Memory_SelectedPositionChanged;
            Reload();
        }

        private void Memory_SelectedPositionChanged(object sender, SelectedPositionChangedEventArgs e)
        {
            int row = e.Position / Settings.MemoryColumns + 1;
            int col = e.Position % Settings.MemoryColumns + 1;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[row].Cells[col].Selected = true;
        }

        private void Memory_MemoryChanged(object sender, MemoryChangedEventArgs e)
        {
            if (e.ValidityChanged)
            {
                Reload();
            }
            else
            {
                int row = e.Position / Settings.MemoryColumns;
                int col = e.Position % Settings.MemoryColumns + 1;
                dataGridView1.Rows[row].Cells[col].Value = Convert.ToString(e.Data);
            }
        }

        public void Reload()
        {
            if (Memory.isValid)
            {
                int memSize = Settings.MemorySize;
                int colNum = Settings.MemoryColumns;
                string[] source = Memory.Values.Select(x => x.ToString()).ToArray();
                dataGridView1.DataSource = CreateDataTable(source);
                dataGridView1.Rows[0].ReadOnly = true;
                dataGridView1.Columns[0].ReadOnly = true;
                //for(int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].HeaderText = Convert.ToString(i);
                //}
                //for(int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i*dataGridView1.Columns.Count);
                //}
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        public DataTable CreateDataTable(string[] strings)
        {
            int columns = Settings.MemoryColumns;
            DataTable table = new DataTable();
            table.Columns.Add("Index");
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow row = null;
            for (int i = 0; i < strings.Length; i++)
            {
                if (i % columns == 0)
                {
                    row = table.NewRow();
                    table.Rows.Add(row);
                    row[0] = Convert.ToString(i);
                }
                row[i % columns + 1] = strings[i];
            }
            return table;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex * (dataGridView1.ColumnCount - 1) + e.ColumnIndex - 1;
            Memory.Values[index] = new Value((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void MemoryViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Memory.MemoryChanged -= Memory_MemoryChanged;
            Memory.SelectedPositionChanged -= Memory_SelectedPositionChanged;
        }
    }
}
