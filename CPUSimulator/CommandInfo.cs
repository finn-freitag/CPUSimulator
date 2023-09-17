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
    public partial class CommandInfo : Form
    {
        public CommandInfo()
        {
            InitializeComponent();
            AssemblerEditor.CommandChanged += CommandChanged;
        }

        private void CommandChanged(object sender, CommandChangedEventArgs e)
        {
            label1.Text = CommandStorage.GetCommandName(e.CommandID);
            label2.Text = "Byte code: " + e.CommandID;
            label3.Text = "Instruction pointer change: " + CommandStorage.Commands[e.CommandID, 3];
            label4.Text = "Parameter type: " + CommandStorage.Commands[e.CommandID, 2];
            textBox1.Text = CommandStorage.Commands[e.CommandID, 4];
        }
    }
}
