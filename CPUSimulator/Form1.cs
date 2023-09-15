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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = Strings.Title;
            label1.Text = Strings.DataBus;
            label2.Text = Strings.AddressBus;
            label3.Text = Strings.Accumulator;
            label4.Text = Strings.InstructionPointer;
            label5.Text = Strings.InstructionRegister;
            label8.Text = Strings.ALU;
            button1.Text = Strings.Settings;
        }
    }
}
