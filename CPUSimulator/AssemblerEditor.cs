using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUSimulator
{
    public partial class AssemblerEditor : Form
    {
        public static event EventHandler<CommandChangedEventArgs> CommandChanged;

        public AssemblerEditor()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;

            int oldCursorPos = richTextBox1.SelectionStart;

            richTextBox1.SelectionChanged -= richTextBox1_SelectionChanged;

            //richTextBox1.SelectAll();
            //richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            //richTextBox1.SelectionColor = Color.Black;

            if (oldCursorPos > 0)
            {
                char c = text[oldCursorPos - 1];
                if (char.IsLetter(c))
                {
                    richTextBox1.Select(oldCursorPos - 1, 1);
                    richTextBox1.SelectionColor = Color.Blue;
                }
                if (char.IsDigit(c))
                {
                    richTextBox1.Select(oldCursorPos - 1, 1);
                    richTextBox1.SelectionColor = Color.Green;
                }
            }

            //Regex commandRegex = new Regex(@"\b(hello|world)\b");

            //foreach (Match match in commandRegex.Matches(text))
            //{
            //    richTextBox1.Select(match.Index, match.Length);
            //    richTextBox1.SelectionColor = Color.Purple;
            //}

            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionStart = oldCursorPos;

            richTextBox1.SelectionChanged += richTextBox1_SelectionChanged;

            SaveIntoMemory();
        }

        private void SaveIntoMemory()
        {
            int prgStart = Settings.MemoryProgramStart;
            int datStart = Settings.MemoryDataStart;
            int memSize = Settings.MemorySize;

            if (prgStart < datStart)
            {
                for(int i = prgStart; i < datStart; i++)
                {
                    Memory.Values[i] = 0;
                }
            }
            else
            {
                for(int i = prgStart; i < memSize; i++)
                {
                    Memory.Values[i] = 0;
                }
            }

            int address = prgStart;
            for(int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string[] parts = richTextBox1.Lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    int cmdID = CommandStorage.GetCommandID(parts[0], (s1, s2) => s1.ToLower().Equals(s2));
                    if (cmdID > -1)
                    {
                        Memory.Values[address] = cmdID;
                        //Memory.FireMemoryChanged(new MemoryChangedEventArgs(address, cmdID));
                        address++;
                        if (parts.Length > 1)
                        {
                            Memory.Values[address] = new Value(parts[1]);
                            //Memory.FireMemoryChanged(new MemoryChangedEventArgs(address, Memory.Values[address]));
                        }
                        else
                        {
                            Memory.Values[address] = 0;
                        }
                        address++;
                    }
                }
            }

            Memory.FireMemoryChanged(new MemoryChangedEventArgs(true));
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                string[] parts = richTextBox1.Lines[richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    int cmdID = CommandStorage.GetCommandID(parts[0], (s1, s2) => s1.ToLower().Equals(s2));
                    if (cmdID > -1 && CommandChanged != null)
                    {
                        CommandChanged(this, new CommandChangedEventArgs(cmdID));
                    }
                }
            }
        }
    }

    public class CommandChangedEventArgs
    {
        public int CommandID;

        public CommandChangedEventArgs(int commandID)
        {
            CommandID = commandID;
        }
    }
}
