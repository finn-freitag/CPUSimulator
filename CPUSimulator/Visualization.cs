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
    public partial class Visualization : Form
    {
        public Visualization()
        {
            InitializeComponent();
            Processor.DataChanged += Processor_DataChanged;
        }

        private void Processor_DataChanged(object sender, EventArgs e)
        {
            textBox26.Text = Processor.DataBus.ToString();
            textBox1.Text = Processor.Accumulator.ToString();
            textBox6.Text = Processor.OPCode.ToString();
            textBox7.Text = Processor.OperandPart.ToString();
            textBox2.Text = Processor.ALUParam1.ToString();
            textBox3.Text = Processor.ALUParam2.ToString();
            textBox4.Text = Processor.ALUResult.ToString();
            textBox5.Text = Processor.InstructionPointer.ToString();
            textBox27.Text = Processor.AddressBus.ToString();
        }
    }
}
