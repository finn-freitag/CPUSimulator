using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public static class Logger
    {
        public static event EventHandler LogChanged;

        static List<string> logs = new List<string>();

        public static void Log(string msg)
        {
            logs.Add(msg);
            if (LogChanged != null) LogChanged(null, EventArgs.Empty);
        }

        public static string Get(int i)
        {
            return logs[i];
        }

        public static new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < logs.Count; i++)
            {
                sb.AppendLine(logs[i]);
            }
            return sb.ToString();
        }

        public static void Clear()
        {
            logs.Clear();
            if (LogChanged != null) LogChanged(null, EventArgs.Empty);
        }

        public static int Count
        {
            get
            {
                return logs.Count;
            }
        }
    }
}
