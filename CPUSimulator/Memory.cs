using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public static class Memory
    {
        public static Value[] Values = null;

        public static event EventHandler<MemoryChangedEventArgs> MemoryChanged;

        public static event EventHandler<SelectedPositionChangedEventArgs> SelectedPositionChanged;

        public static bool isValid = false;

        public static void Init()
        {
            int length = Settings.MemorySize;
            Values = new Value[length];
            for(int i = 0; i < Values.Length; i++)
            {
                Values[i] = Value.Default;
            }
            isValid = true;
            if (MemoryChanged != null) MemoryChanged(null, new MemoryChangedEventArgs(true));
        }

        public static void FireMemoryChanged(MemoryChangedEventArgs e)
        {
            if (MemoryChanged != null) MemoryChanged(null, e);
        }

        public static void FireSelectedPositionChanged(SelectedPositionChangedEventArgs e)
        {
            if (SelectedPositionChanged != null) SelectedPositionChanged(null, e);
        }

        public static void Dispose()
        {
            isValid = false;
            Values = null;
            if (MemoryChanged != null) MemoryChanged(null, new MemoryChangedEventArgs(true));
        }
    }

    public class MemoryChangedEventArgs
    {
        public int Position;
        public Value Data;
        public bool ValidityChanged = false;

        public MemoryChangedEventArgs(bool ValidityChanged)
        {
            this.ValidityChanged = ValidityChanged;
        }

        public MemoryChangedEventArgs(int Position, Value Data)
        {
            this.Position = Position;
            this.Data = Data;
        }
    }

    public class SelectedPositionChangedEventArgs
    {
        public int Position;

        public SelectedPositionChangedEventArgs(int position)
        {
            Position = position;
        }
    }

    public enum MemoryType
    {
        Byte,
        SByte,
        Short,
        UShort,
        Int,
        UInt,
        Long,
        ULong
    }
}
