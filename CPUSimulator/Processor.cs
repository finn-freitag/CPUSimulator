using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public static class Processor
    {
        public static Value Accumulator = Value.Default;
        public static Value DataBus = Value.Default;
        public static Value AddressBus = Value.Default;
        public static Value InstructionPointer = 0;
        public static Value OPCode = Value.Default;
        public static Value OperandPart = Value.Default;
        public static Value ALUParam1 = Value.Default;
        public static Value ALUParam2 = Value.Default;
        public static Value ALUResult = Value.Default;
        public static Flag Flag = Flag.none;

        public static event EventHandler DataChanged;

        public static void Init()
        {
            InstructionPointer = Settings.MemoryProgramStart;
        }

        public static void FireDataChanged()
        {
            if (DataChanged != null) DataChanged(null, EventArgs.Empty);
        }

        public static void ExecuteAll()
        {
            while (ExecuteCommand()) ;
        }

        public static bool ExecuteCommand()
        {
            Logger.Log("New command!");
            
            // fetch 1
            AddressBus = InstructionPointer;
            Logger.Log("fetch1: Write the content of the instruction pointer (" + InstructionPointer + ") to the address bus.");
            DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
            Logger.Log("fetch1: Put the content of the memory address (" + DataBus + ") on the data bus.");
            OPCode = DataBus;
            Logger.Log("fetch1: Write the data content of the data bus (" + DataBus + ") as OP-Code into the instruction Register.");
            InstructionPointer += 1;
            Logger.Log("fetch1: Increase instruction pointer by one.");

            if (DataChanged != null) DataChanged(null, EventArgs.Empty);

            if (OPCode == CommandStorage.GetCommandID("PASS"))
            {
                Logger.Log("decode: OP-Code " + OPCode + " means PASS");
                return true;
            }
            if (OPCode == CommandStorage.GetCommandID("HOLD"))
            {
                Logger.Log("decode: OP-Code " + OPCode + " means HOLD");
                Logger.Log("execute: Program stopped!");
                return false;
            }
            if (OPCode == CommandStorage.GetCommandID("EXCP"))
            {
                Logger.Log("decode: OP-Code " + OPCode + " means EXCP");
                Logger.Log("execute: Program throws an exception!");
                return false;
            }

            //fetch 2
            AddressBus = InstructionPointer;
            Logger.Log("fetch2: Write the content of the instruction pointer (" + InstructionPointer + ") to the address bus.");
            DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
            Logger.Log("fetch2: Put the content of the memory address (" + DataBus + ") on the data bus.");
            OperandPart = DataBus;
            Logger.Log("fetch2: Write the data content of the data bus (" + DataBus + ") as operand part into the instruction Register.");
            InstructionPointer += 1;
            Logger.Log("fetch2: Increase instruction pointer by one.");

            if (DataChanged != null) DataChanged(null, EventArgs.Empty);

            //decode
            Logger.Log("decode: OP-Code " + OPCode + " means " + CommandStorage.GetCommandName(Convert.ToInt32(OPCode.ToString())));

            //execute
            switch (CommandStorage.GetCommandName(Convert.ToInt32(OPCode.ToString())))
            {
                case "LOAD":
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    Accumulator = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") into the accumulator.");
                    break;
                case "LOADI":
                    Accumulator = OperandPart;
                    Logger.Log("execute: Put the content of the operand part into the accumulator.");
                    break;
                case "STORE":
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the data bus.");
                    Memory.Values[Convert.ToInt32(AddressBus.ToString())] = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the memory.");
                    Memory.FireMemoryChanged(new MemoryChangedEventArgs(Convert.ToInt32(AddressBus.ToString()), DataBus));
                    break;
                case "DIV":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    ALUResult = ALUParam1 / ALUParam2;
                    Logger.Log("execute: Divides the content of the accumulator (" + ALUParam1 + ") through the value from memory (" + ALUParam2 + ").");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "DIVI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") into the ALU.");
                    ALUResult = ALUParam1 / ALUParam2;
                    Logger.Log("execute: Divide the content of the accumulator (" + ALUParam1 + ") by the operand part (" + ALUParam2 + ") in the ALU.");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "MOD":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    ALUResult = ALUParam1 % ALUParam2;
                    Logger.Log("execute: Calculates the remainder of the content of the accumulator (" + ALUParam1 + ") divided by the value from memory (" + ALUParam2 + ").");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "MODI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") into the ALU.");
                    ALUResult = ALUParam1 % ALUParam2;
                    Logger.Log("execute: Calculate the remainder of the content of the accumulator (" + ALUParam1 + ") divided by the operand part (" + ALUParam2 + ") in the ALU.");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "CMP":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    if (ALUParam1 < ALUParam2)
                    {
                        ALUResult = 2;
                        Flag = Flag.negativ;
                        Logger.Log("execute: Set flag to 'negative'.");
                    }
                    if (ALUParam1 == ALUParam2)
                    {
                        ALUResult = 0;
                        Flag = Flag.zero;
                        Logger.Log("execute: Set flag to 'zero'.");
                    }
                    if (ALUParam1 > ALUParam2)
                    {
                        ALUResult = 1;
                        Flag = Flag.none;
                        Logger.Log("execute: Set no flag.");
                    }
                    break;
                case "CMPI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") to the ALU.");
                    if (ALUParam1 < ALUParam2)
                    {
                        ALUResult = 2;
                        Flag = Flag.negativ;
                        Logger.Log("execute: Set flag to 'negative'.");
                    }
                    if (ALUParam1 == ALUParam2)
                    {
                        ALUResult = 0;
                        Flag = Flag.zero;
                        Logger.Log("execute: Set flag to 'zero'.");
                    }
                    if (ALUParam1 > ALUParam2)
                    {
                        ALUResult = 1;
                        Flag = Flag.none;
                        Logger.Log("execute: Set no flag.");
                    }
                    break;
                case "ADD":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    ALUResult = ALUParam1 + ALUParam2;
                    Logger.Log("execute: Adds the content of the accumulator (" + ALUParam1 + ") to the value from memory (" + ALUParam2 + ").");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "ADDI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") into the ALU.");
                    ALUResult = ALUParam1 + ALUParam2;
                    Logger.Log("execute: Add the content of the accumulator (" + ALUParam1 + ") to the operand part (" + ALUParam2 + ") in the ALU.");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "SUB":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    ALUResult = ALUParam1 - ALUParam2;
                    Logger.Log("execute: Subtracts the content of the accumulator (" + ALUParam1 + ") by the value from memory (" + ALUParam2 + ").");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "SUBI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") into the ALU.");
                    ALUResult = ALUParam1 - ALUParam2;
                    Logger.Log("execute: Subtract the content of the accumulator (" + ALUParam1 + ") by the operand part (" + ALUParam2 + ") in the ALU.");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "MUL":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    AddressBus = OperandPart;
                    Logger.Log("execute: Write the operand part (" + OperandPart + ") to the address bus.");
                    DataBus = Memory.Values[Convert.ToInt32(AddressBus.ToString())];
                    Logger.Log("execute: Put the content of the memory address (" + DataBus + ") on the data bus.");
                    ALUParam2 = DataBus;
                    Logger.Log("execute: Put the content of the data bus (" + DataBus + ") to the ALU.");
                    ALUResult = ALUParam1 * ALUParam2;
                    Logger.Log("execute: Multiplies the content of the accumulator (" + ALUParam1 + ") by the value from memory (" + ALUParam2 + ").");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "MULI":
                    ALUParam1 = Accumulator;
                    Logger.Log("execute: Put the content of the accumulator (" + Accumulator + ") to the ALU.");
                    ALUParam2 = OperandPart;
                    Logger.Log("execute: Put the operand part (" + OperandPart + ") into the ALU.");
                    ALUResult = ALUParam1 * ALUParam2;
                    Logger.Log("execute: Multiply the content of the accumulator (" + ALUParam1 + ") by the operand part (" + ALUParam2 + ") in the ALU.");
                    Accumulator = ALUResult;
                    Logger.Log("execute: Put the result (" + ALUResult + ") to the accumulator.");
                    break;
                case "JMP":
                    InstructionPointer = OperandPart;
                    Logger.Log("execute: Jump to " + InstructionPointer);
                    break;
                case "JMPZ":
                    if(Flag == Flag.zero)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (zero-flag is set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (zero-flag is not set).");
                    }
                    break;
                case "JMPNZ":
                    if(Flag != Flag.zero)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (zero-flag is not set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (zero-flag is set).");
                    }
                    break;
                case "JMPN":
                    if(Flag == Flag.negativ)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (negative-flag is set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (negative-flag is not set).");
                    }
                    break;
                case "JMPNN":
                    if(Flag != Flag.negativ)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (negative-flag is not set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (negative-flag is set).");
                    }
                    break;
                case "JMPP":
                    if(Flag == Flag.none)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (no flag is set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (any is set).");
                    }
                    break;
                case "JMPNP":
                    if(Flag != Flag.negativ)
                    {
                        InstructionPointer = OperandPart;
                        Logger.Log("execute: Jump to " + InstructionPointer + " (negative-flag or zero-flag is not set).");
                    }
                    else
                    {
                        Logger.Log("execute: Stay on position " + InstructionPointer + " (negative-flag or zero-flag is set).");
                    }
                    break;
            }

            if (DataChanged != null) DataChanged(null, EventArgs.Empty);

            return true;
        }
    }

    public enum Flag
    {
        none,
        zero,
        negativ
    }
}
