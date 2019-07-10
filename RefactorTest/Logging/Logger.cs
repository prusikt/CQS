using System.Collections.Generic;

namespace RefactorTest.Logging
{
    public static class Logger
    {
        private static readonly List<string> LogList = new List<string>();

        public static void Log(string message)
        {
            LogList.Add(message);
        }

        public static void Clear()
        {
            LogList.Clear();
        }

        public static List<string> GetLogEntries()
        {
            return LogList;
        }
    }
}