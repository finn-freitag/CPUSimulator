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
    public partial class LoggerView : Form
    {
        public LoggerView()
        {
            InitializeComponent();
            Logger.LogChanged += Logger_LogChanged;
        }

        private void Logger_LogChanged(object sender, EventArgs e)
        {
            textBox1.Text = Logger.ToString();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Clear();
        }
    }
}
