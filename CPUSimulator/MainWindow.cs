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
    public partial class MainWindow : Form
    {
        List<Form> AllWindows = new List<Form>();
        bool isMDI = true;

        public MainWindow()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            isMDI = Settings.isMDI;
            CreateMDIChild(new Visualization());
        }

        private void CreateMDIChild(Form form)
        {
            AllWindows.Add(form);
            if (isMDI) form.MdiParent = this; else form.MdiParent = null;
            form.Show();
        }

        private void visualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new Visualization());
        }

        private void openInSeparateWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMDI = !isMDI;
            Settings.isMDI = isMDI;
            foreach(Form form in AllWindows)
            {
                if (isMDI) form.MdiParent = this; else form.MdiParent = null;
            }
        }

        private void memoryViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new MemoryViewer());
        }

        private void assemblerEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new AssemblerEditor());
        }

        private void commandInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new CommandInfo());
        }

        private void loggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new LoggerView());
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new ControlPanel());
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMDIChild(new SettingsView());
        }
    }
}
