using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public static class CommandStorage
    {
        public static string[,] Commands = new string[,]
        {
            // ID // OP-Code // Parameter // InstrPoiChange // Description
            { "0", "PASS", "-", "+1", "Increases the instruction pointer by one." },
            { "1", "LOAD", "address", "+2", "Load the accumulator with the data from the memory at the address." },
            { "2", "LOADI", "value", "+2", "Load the accumulator with the value that immediately follows the operation code." },
            { "3", "STORE", "address", "+2", "Store the accumulator in the memory at the address."},
            { "4", "DIV", "address", "+2", "Divide the accumulator contents by the contents of the memory cell at the address and store the result of the integer division in the accumulator."},
            { "5", "DIVI", "value", "+2", "Divide the accumulator contents by the value and store the result of the integer division in the accumulator."},
            { "6", "MOD", "address", "+2", "Divide the accumulator contents by the contents of the memory cell at the address and store the remainder of the integer division in the accumulator."},
            { "7", "MODI", "address", "+2", "Divide the accumulator contents by the value and store the remainder of the integer division in the accumulator."},
            { "8", "CMP", "address", "+2", "Compare the accumulator contents with the contents of the memory cell at the address and set the status register accordingly.\r\nAccumulator content > memory cell content => no flag\r\nAccumulator content = memory cell content => zero flag\r\nAccumulator content < memory cell content => negative flag" },
            { "9", "CMPI", "value", "+2", "Compare the accumulator contents with the value and set the status register accordingly.\r\nAccumulator content > memory cell content => no flag\r\nAccumulator content = memory cell content => zero flag\r\nAccumulator content < memory cell content => negative flag"},
            { "10", "ADD", "address", "+2", "Add to the accumulator contents the contents of the memory cell at the address and store the result in the accumulator."},
            { "11", "ADDI", "value", "+2", "Add to the accumulator contents the value and store the result in the accumulator."},
            { "12", "SUB", "address", "+2", "Subtract from the accumulator contents the contents of the memory cell at the address and store the result in the accumulator."},
            { "13", "SUBI", "value", "+2", "Subtract from the accumulator contents the value and store the result in the accumulator."},
            { "14", "SUB", "address", "+2", "Multiply the accumulator contents by the contents of the memory cell at the address and store the result in the accumulator."},
            { "15", "SUBI", "value", "+2", "Multiply the accumulator contents by the value and store the result in the accumulator."},
            { "16", "JMP", "address", "address", "Jump to address, by writing address in the instruction pointer." },
            { "17", "JMPZ", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the zero flag is set." },
            { "18", "JMPNZ", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the zero flag is not set." },
            { "19", "JMPN", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the negative flag is set." },
            { "20", "JMPNN", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the negative flag is not set." },
            { "21", "JMPP", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the negative flag and the zero flag are not set." },
            { "22", "JMPNP", "address", "+2 or address", "Jump to address, by writing address in the instruction pointer, if the negative flag or the zero flag is set." },
            { "23", "HOLD", "-", "+0", "Stops the processor." },
            { "24", "EXCP", "-", "+0", "Stops the processor, because of an exception." }
        };

        public static string GetCommandName(int number)
        {
            if (number > 24) return "EXCP";
            return Commands[number, 1];
        }

        public static int GetCommandID(string commandName)
        {
            for(int i = 0; i < Commands.GetLength(0); i++)
            {
                if (Commands[i, 1].Equals(commandName)) return Convert.ToInt32(Commands[i, 0]);
            }
            return -1;
        }

        public static int GetCommandID(string commandName, Equal equal)
        {
            for(int i = 0; i < Commands.GetLength(0); i++)
            {
                if (equal(Commands[i, 1], commandName)) return Convert.ToInt32(Commands[i, 0]);
            }
            return -1;
        }

        public delegate bool Equal(string str1, string str2);
    }
}
