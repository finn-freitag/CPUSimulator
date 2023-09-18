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
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    comboBox1.Text = "Byte";
                    break;
                case MemoryType.SByte:
                    comboBox1.Text = "SByte";
                    break;
                case MemoryType.Short:
                    comboBox1.Text = "Short";
                    break;
                case MemoryType.UShort:
                    comboBox1.Text = "UShort";
                    break;
                case MemoryType.Int:
                    comboBox1.Text = "Int";
                    break;
                case MemoryType.UInt:
                    comboBox1.Text = "UInt";
                    break;
                case MemoryType.Long:
                    comboBox1.Text = "Long";
                    break;
                case MemoryType.ULong:
                    comboBox1.Text = "ULong";
                    break;
            }
            numericUpDown1.Maximum = Settings.MemorySize - 1;
            numericUpDown1.Value = Settings.MemoryProgramStart;
            numericUpDown2.Maximum = Settings.MemorySize - 1;
            numericUpDown2.Value = Settings.MemoryDataStart;
            numericUpDown3.Value = Settings.MemorySize;
            numericUpDown4.Value = Settings.MemoryColumns;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown3.Value;
            numericUpDown2.Maximum = numericUpDown3.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Byte":
                    Settings.MemoryType = MemoryType.Byte;
                    break;
                case "SByte":
                    Settings.MemoryType = MemoryType.SByte;
                    break;
                case "Short":
                    Settings.MemoryType = MemoryType.Short;
                    break;
                case "UShort":
                    Settings.MemoryType = MemoryType.UShort;
                    break;
                case "Int":
                    Settings.MemoryType = MemoryType.Int;
                    break;
                case "UInt":
                    Settings.MemoryType = MemoryType.UInt;
                    break;
                case "Long":
                    Settings.MemoryType = MemoryType.Long;
                    break;
                case "ULong":
                    Settings.MemoryType = MemoryType.ULong;
                    break;
            }
            Settings.MemoryProgramStart = (int)numericUpDown1.Value;
            Settings.MemoryDataStart = (int)numericUpDown2.Value;
            Settings.MemorySize = (int)numericUpDown3.Value;
            Settings.MemoryColumns = (int)numericUpDown4.Value;
            Settings.Save();
            Application.Restart();
        }
    }
}
