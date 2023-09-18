using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public static class Settings
    {
        public static int MemoryColumns { get; set; } = 10;
        public static int MemorySize { get; set; } = 200;
        public static int MemoryProgramStart { get; set; } = 0;
        public static int MemoryDataStart { get; set; } = 100;
        public static MemoryType MemoryType { get; set; } = MemoryType.Byte;
        public static bool isMDI { get; set; } = true;

        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CPUSimulator\\";

        public static void Init()
        {
            if(File.Exists(path + "settings.dat"))
            {
                string[] data = File.ReadAllLines(path + "settings.dat");
                MemoryColumns = Convert.ToInt32(data[0]);
                MemorySize = Convert.ToInt32(data[1]);
                MemoryProgramStart = Convert.ToInt32(data[2]);
                MemoryDataStart = Convert.ToInt32(data[3]);
                switch (data[4])
                {
                    case "Byte":
                        MemoryType = MemoryType.Byte;
                        break;
                    case "SByte":
                        MemoryType = MemoryType.SByte;
                        break;
                    case "Short":
                        MemoryType = MemoryType.Short;
                        break;
                    case "UShort":
                        MemoryType = MemoryType.UShort;
                        break;
                    case "Int":
                        MemoryType = MemoryType.Int;
                        break;
                    case "UInt":
                        MemoryType = MemoryType.UInt;
                        break;
                    case "Long":
                        MemoryType = MemoryType.Long;
                        break;
                    case "ULong":
                        MemoryType = MemoryType.ULong;
                        break;
                }
            }
        }

        public static void Save()
        {
            List<string> data = new List<string>();
            data.Add(Convert.ToString(MemoryColumns));
            data.Add(Convert.ToString(MemorySize));
            data.Add(Convert.ToString(MemoryProgramStart));
            data.Add(Convert.ToString(MemoryDataStart));
            switch (Settings.MemoryType)
            {
                case MemoryType.Byte:
                    data.Add("Byte");
                    break;
                case MemoryType.SByte:
                    data.Add("SByte");
                    break;
                case MemoryType.Short:
                    data.Add("Short");
                    break;
                case MemoryType.UShort:
                    data.Add("UShort");
                    break;
                case MemoryType.Int:
                    data.Add("Int");
                    break;
                case MemoryType.UInt:
                    data.Add("UInt");
                    break;
                case MemoryType.Long:
                    data.Add("Long");
                    break;
                case MemoryType.ULong:
                    data.Add("ULong");
                    break;
            }
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            File.WriteAllLines(path + "settings.dat", data.ToArray());
        }
    }
}
