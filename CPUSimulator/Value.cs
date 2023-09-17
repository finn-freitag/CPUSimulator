using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public struct Value
    {
        string value;

        public static Value Default = new Value() { value = "0" };

        public Value(string value)
        {
            this.value = value;

            // Validate
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    Convert.ToByte(value);
                    break;
                case MemoryType.SByte:
                    Convert.ToSByte(value);
                    break;
                case MemoryType.Short:
                    Convert.ToInt16(value);
                    break;
                case MemoryType.UShort:
                    Convert.ToUInt16(value);
                    break;
                case MemoryType.Int:
                    Convert.ToInt32(value);
                    break;
                case MemoryType.UInt:
                    Convert.ToUInt32(value);
                    break;
                case MemoryType.Long:
                    Convert.ToInt64(value);
                    break;
                case MemoryType.ULong:
                    Convert.ToUInt64(value);
                    break;
            }
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Value)) return false;
            return value.Equals(((Value)obj).value);
        }

        public static Value operator +(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return new Value(Convert.ToString((byte)((Convert.ToByte(v1.value) + Convert.ToByte(v2.value)) % 256)));
                case MemoryType.SByte:
                    return new Value(Convert.ToString((sbyte)((Convert.ToSByte(v1.value) + Convert.ToSByte(v2.value)) % 128)));
                case MemoryType.Short:
                    return new Value(Convert.ToString((short)((Convert.ToInt16(v1.value) + Convert.ToInt16(v2.value)) % 32768)));
                case MemoryType.UShort:
                    return new Value(Convert.ToString((short)((Convert.ToUInt16(v1.value) + Convert.ToUInt16(v2.value)) % 65536)));
                case MemoryType.Int:
                    return new Value(Convert.ToString(Convert.ToInt32(v1.value) + Convert.ToInt32(v2.value)));
                case MemoryType.UInt:
                    return new Value(Convert.ToString(Convert.ToUInt32(v1.value) + Convert.ToUInt32(v2.value)));
                case MemoryType.Long:
                    return new Value(Convert.ToString(Convert.ToInt64(v1.value) + Convert.ToInt64(v2.value)));
                case MemoryType.ULong:
                    return new Value(Convert.ToString(Convert.ToUInt64(v1.value) + Convert.ToUInt64(v2.value)));
            }
            return 0;
        }

        public static Value operator -(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return new Value(Convert.ToString((byte)((Convert.ToByte(v1.value) - Convert.ToByte(v2.value)) % 256)));
                case MemoryType.SByte:
                    return new Value(Convert.ToString((sbyte)((Convert.ToSByte(v1.value) - Convert.ToSByte(v2.value)) % 128)));
                case MemoryType.Short:
                    return new Value(Convert.ToString((short)((Convert.ToInt16(v1.value) - Convert.ToInt16(v2.value)) % 32768)));
                case MemoryType.UShort:
                    return new Value(Convert.ToString((short)((Convert.ToUInt16(v1.value) - Convert.ToUInt16(v2.value)) % 65536)));
                case MemoryType.Int:
                    return new Value(Convert.ToString(Convert.ToInt32(v1.value) - Convert.ToInt32(v2.value)));
                case MemoryType.UInt:
                    return new Value(Convert.ToString(Convert.ToUInt32(v1.value) - Convert.ToUInt32(v2.value)));
                case MemoryType.Long:
                    return new Value(Convert.ToString(Convert.ToInt64(v1.value) - Convert.ToInt64(v2.value)));
                case MemoryType.ULong:
                    return new Value(Convert.ToString(Convert.ToUInt64(v1.value) - Convert.ToUInt64(v2.value)));
            }
            return 0;
        }

        public static Value operator *(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return new Value(Convert.ToString((byte)((Convert.ToByte(v1.value) * Convert.ToByte(v2.value)) % 256)));
                case MemoryType.SByte:
                    return new Value(Convert.ToString((sbyte)((Convert.ToSByte(v1.value) * Convert.ToSByte(v2.value)) % 128)));
                case MemoryType.Short:
                    return new Value(Convert.ToString((short)((Convert.ToInt16(v1.value) * Convert.ToInt16(v2.value)) % 32768)));
                case MemoryType.UShort:
                    return new Value(Convert.ToString((short)((Convert.ToUInt16(v1.value) * Convert.ToUInt16(v2.value)) % 65536)));
                case MemoryType.Int:
                    return new Value(Convert.ToString(Convert.ToInt32(v1.value) * Convert.ToInt32(v2.value)));
                case MemoryType.UInt:
                    return new Value(Convert.ToString(Convert.ToUInt32(v1.value) * Convert.ToUInt32(v2.value)));
                case MemoryType.Long:
                    return new Value(Convert.ToString(Convert.ToInt64(v1.value) * Convert.ToInt64(v2.value)));
                case MemoryType.ULong:
                    return new Value(Convert.ToString(Convert.ToUInt64(v1.value) * Convert.ToUInt64(v2.value)));
            }
            return 0;
        }

        public static Value operator /(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return new Value(Convert.ToString((byte)((Convert.ToByte(v1.value) / Convert.ToByte(v2.value)) % 256)));
                case MemoryType.SByte:
                    return new Value(Convert.ToString((sbyte)((Convert.ToSByte(v1.value) / Convert.ToSByte(v2.value)) % 128)));
                case MemoryType.Short:
                    return new Value(Convert.ToString((short)((Convert.ToInt16(v1.value) / Convert.ToInt16(v2.value)) % 32768)));
                case MemoryType.UShort:
                    return new Value(Convert.ToString((short)((Convert.ToUInt16(v1.value) / Convert.ToUInt16(v2.value)) % 65536)));
                case MemoryType.Int:
                    return new Value(Convert.ToString(Convert.ToInt32(v1.value) / Convert.ToInt32(v2.value)));
                case MemoryType.UInt:
                    return new Value(Convert.ToString(Convert.ToUInt32(v1.value) / Convert.ToUInt32(v2.value)));
                case MemoryType.Long:
                    return new Value(Convert.ToString(Convert.ToInt64(v1.value) / Convert.ToInt64(v2.value)));
                case MemoryType.ULong:
                    return new Value(Convert.ToString(Convert.ToUInt64(v1.value) / Convert.ToUInt64(v2.value)));
            }
            return 0;
        }

        public static Value operator %(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return new Value(Convert.ToString((byte)((Convert.ToByte(v1.value) % Convert.ToByte(v2.value)) % 256)));
                case MemoryType.SByte:
                    return new Value(Convert.ToString((sbyte)((Convert.ToSByte(v1.value) % Convert.ToSByte(v2.value)) % 128)));
                case MemoryType.Short:
                    return new Value(Convert.ToString((short)((Convert.ToInt16(v1.value) % Convert.ToInt16(v2.value)) % 32768)));
                case MemoryType.UShort:
                    return new Value(Convert.ToString((short)((Convert.ToUInt16(v1.value) % Convert.ToUInt16(v2.value)) % 65536)));
                case MemoryType.Int:
                    return new Value(Convert.ToString(Convert.ToInt32(v1.value) % Convert.ToInt32(v2.value)));
                case MemoryType.UInt:
                    return new Value(Convert.ToString(Convert.ToUInt32(v1.value) % Convert.ToUInt32(v2.value)));
                case MemoryType.Long:
                    return new Value(Convert.ToString(Convert.ToInt64(v1.value) % Convert.ToInt64(v2.value)));
                case MemoryType.ULong:
                    return new Value(Convert.ToString(Convert.ToUInt64(v1.value) % Convert.ToUInt64(v2.value)));
            }
            return 0;
        }

        public static bool operator >(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return Convert.ToByte(v1.value) > Convert.ToByte(v2.value);
                case MemoryType.SByte:
                    return Convert.ToSByte(v1.value) > Convert.ToSByte(v2.value);
                case MemoryType.Short:
                    return Convert.ToInt16(v1.value) > Convert.ToInt16(v2.value);
                case MemoryType.UShort:
                    return Convert.ToUInt16(v1.value) > Convert.ToUInt16(v2.value);
                case MemoryType.Int:
                    return Convert.ToInt32(v1.value) > Convert.ToInt32(v2.value);
                case MemoryType.UInt:
                    return Convert.ToUInt32(v1.value) > Convert.ToUInt32(v2.value);
                case MemoryType.Long:
                    return Convert.ToInt64(v1.value) > Convert.ToInt64(v2.value);
                case MemoryType.ULong:
                    return Convert.ToUInt64(v1.value) > Convert.ToUInt64(v2.value);
            }
            return false;
        }

        public static bool operator <(Value v1, Value v2)
        {
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    return Convert.ToByte(v1.value) < Convert.ToByte(v2.value);
                case MemoryType.SByte:
                    return Convert.ToSByte(v1.value) < Convert.ToSByte(v2.value);
                case MemoryType.Short:
                    return Convert.ToInt16(v1.value) < Convert.ToInt16(v2.value);
                case MemoryType.UShort:
                    return Convert.ToUInt16(v1.value) < Convert.ToUInt16(v2.value);
                case MemoryType.Int:
                    return Convert.ToInt32(v1.value) < Convert.ToInt32(v2.value);
                case MemoryType.UInt:
                    return Convert.ToUInt32(v1.value) < Convert.ToUInt32(v2.value);
                case MemoryType.Long:
                    return Convert.ToInt64(v1.value) < Convert.ToInt64(v2.value);
                case MemoryType.ULong:
                    return Convert.ToUInt64(v1.value) < Convert.ToUInt64(v2.value);
            }
            return false;
        }

        public static bool operator ==(Value v1, Value v2)
        {
            return v1.value.Equals(v2.value);
        }

        public static bool operator !=(Value v1, Value v2)
        {
            return !v1.value.Equals(v2.value);
        }

        public static implicit operator Value(byte Byte)
        {
            return new Value(Convert.ToString(Byte));
        }

        public static implicit operator Value(sbyte SByte)
        {
            return new Value(Convert.ToString(SByte));
        }

        public static implicit operator Value(short Short)
        {
            return new Value(Convert.ToString(Short));
        }

        public static implicit operator Value(ushort UShort)
        {
            return new Value(Convert.ToString(UShort));
        }

        public static implicit operator Value(int Int)
        {
            return new Value(Convert.ToString(Int));
        }

        public static implicit operator Value(uint UInt)
        {
            return new Value(Convert.ToString(UInt));
        }

        public static implicit operator Value(long Long)
        {
            return new Value(Convert.ToString(Long));
        }

        public static implicit operator Value(ulong ULong)
        {
            return new Value(Convert.ToString(ULong));
        }
    }
}
