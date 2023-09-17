using System;
using System.Collections.Generic;
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

        public static void Init()
        {

        }
    }
}
