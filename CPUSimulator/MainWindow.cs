using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public static Form visualization = null;
        public static Form memoryViewer = null;
        public static Form assemblerEditor = null;
        public static Form commandInfo = null;
        public static Form loggerView = null;
        public static Form controlPanel = null;
        public static Form settingsView = null;

        public MainWindow()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            isMDI = Settings.isMDI;
            CreateMDIChild(new Visualization());
        }

        private Form CreateMDIChild(Form form)
        {
            AllWindows.Add(form);
            if (isMDI) form.MdiParent = this; else form.MdiParent = null;
            form.Show();
            return form;
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
            if (memoryViewer == null) memoryViewer = CreateMDIChild(new MemoryViewer());
            else memoryViewer.BringToFront();
        }

        private void assemblerEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (assemblerEditor == null) assemblerEditor = CreateMDIChild(new AssemblerEditor());
            else assemblerEditor.BringToFront();
        }

        private void commandInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (commandInfo == null) commandInfo = CreateMDIChild(new CommandInfo());
            else commandInfo.BringToFront();
        }

        private void loggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loggerView == null) loggerView = CreateMDIChild(new LoggerView());
            else loggerView.BringToFront();
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controlPanel == null) controlPanel = CreateMDIChild(new ControlPanel());
            else controlPanel.BringToFront();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsView == null) settingsView = CreateMDIChild(new SettingsView());
            else settingsView.BringToFront();
        }

        private void openAssemblerCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Assembler code (*.asm)|*.asm";
            ofd.Title = "Open assembler code...";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (assemblerEditor == null) assemblerEditor = CreateMDIChild(new AssemblerEditor());
                ((AssemblerEditor)assemblerEditor).SetText(File.ReadAllText(ofd.FileName));
            }
        }

        private void saveAssemblerCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (assemblerEditor == null) MessageBox.Show("Write some code at first!");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Assembler code (*.asm)|*.asm";
            sfd.CheckPathExists = true;
            sfd.Title = "Save assembler code...";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, ((AssemblerEditor)assemblerEditor).GetText());
            }
        }

        private void openMemoryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Open memory data...";
            ofd.Filter = "Memory Data (*.csv)|*.csv";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] parts = File.ReadAllText(ofd.FileName).Split(',');
                for(int i = 0; i < parts.Length; i++)
                {
                    Memory.Values[i] = new Value(parts[i]);
                }
            }
        }

        private void saveMemoryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckPathExists = true;
            sfd.Filter = "Memory data (*.csv)|*.csv";
            sfd.Title = "Save memory data as...";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Memory.Values[0].ToString());
                for(int i = 1; i < Memory.Values.Length; i++)
                {
                    sb.Append("," + Memory.Values[i].ToString());
                }
                File.WriteAllText(sfd.FileName, sb.ToString());
            }
        }
    }
}
