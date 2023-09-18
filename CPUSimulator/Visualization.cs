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
        private const int MemoryExcerptLength = 9;

        public Visualization()
        {
            InitializeComponent();
            Processor.DataChanged += Processor_DataChanged;
            Memory.MemoryChanged += Memory_MemoryChanged;
            vScrollBar1.Maximum = Settings.MemorySize - MemoryExcerptLength;
            vScrollBar2.Maximum = Settings.MemorySize - MemoryExcerptLength;
            vScrollBar1.Value = Settings.MemoryProgramStart;
            vScrollBar2.Value = Settings.MemoryDataStart;
        }

        private void Memory_MemoryChanged(object sender, MemoryChangedEventArgs e)
        {
            int Mem1ExStart = vScrollBar1.Value;
            label6.Text = "" + Mem1ExStart;
            label7.Text = "" + (Mem1ExStart + 1);
            label9.Text = "" + (Mem1ExStart + 2);
            label10.Text = "" + (Mem1ExStart + 3);
            label11.Text = "" + (Mem1ExStart + 4);
            label12.Text = "" + (Mem1ExStart + 5);
            label13.Text = "" + (Mem1ExStart + 6);
            label14.Text = "" + (Mem1ExStart + 7);
            label15.Text = "" + (Mem1ExStart + 8);
            textBox8.Text = "" + Memory.Values[Mem1ExStart].ToString();
            textBox9.Text = "" + Memory.Values[Mem1ExStart + 1].ToString();
            textBox10.Text = "" + Memory.Values[Mem1ExStart + 2].ToString();
            textBox11.Text = "" + Memory.Values[Mem1ExStart + 3].ToString();
            textBox12.Text = "" + Memory.Values[Mem1ExStart + 4].ToString();
            textBox13.Text = "" + Memory.Values[Mem1ExStart + 5].ToString();
            textBox14.Text = "" + Memory.Values[Mem1ExStart + 6].ToString();
            textBox15.Text = "" + Memory.Values[Mem1ExStart + 7].ToString();
            textBox16.Text = "" + Memory.Values[Mem1ExStart + 8].ToString();

            int Mem2ExStart = vScrollBar2.Value;
            label16.Text = "" + Mem2ExStart;
            label17.Text = "" + (Mem2ExStart + 1);
            label18.Text = "" + (Mem2ExStart + 2);
            label19.Text = "" + (Mem2ExStart + 3);
            label20.Text = "" + (Mem2ExStart + 4);
            label21.Text = "" + (Mem2ExStart + 5);
            label22.Text = "" + (Mem2ExStart + 6);
            label23.Text = "" + (Mem2ExStart + 7);
            label24.Text = "" + (Mem2ExStart + 8);
            textBox17.Text = "" + Memory.Values[Mem2ExStart].ToString();
            textBox18.Text = "" + Memory.Values[Mem2ExStart + 1].ToString();
            textBox19.Text = "" + Memory.Values[Mem2ExStart + 2].ToString();
            textBox20.Text = "" + Memory.Values[Mem2ExStart + 3].ToString();
            textBox21.Text = "" + Memory.Values[Mem2ExStart + 4].ToString();
            textBox22.Text = "" + Memory.Values[Mem2ExStart + 5].ToString();
            textBox23.Text = "" + Memory.Values[Mem2ExStart + 6].ToString();
            textBox24.Text = "" + Memory.Values[Mem2ExStart + 7].ToString();
            textBox25.Text = "" + Memory.Values[Mem2ExStart + 8].ToString();
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
            vScrollBar1.Value = Convert.ToInt32(Processor.AddressBus.ToString());
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            Memory_MemoryChanged(null, null);
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            Memory_MemoryChanged(null, null);
        }
    }
}
