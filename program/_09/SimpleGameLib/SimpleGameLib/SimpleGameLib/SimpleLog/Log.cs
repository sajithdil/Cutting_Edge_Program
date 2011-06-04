using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleGameLib
{
    public class Log
    {
        private static Log instance = new Log();
        private String fileName;
        private TextWriter writer;

        public static Log getInstance()
        {
            return(instance);
        }

        private Log()
        {
            fileName = "Log.txt";
            writer = new StreamWriter(fileName);
            writer.WriteLine("Starting to log....");
            writer.Close();
        }

        public void log(String value)
        {
            writer = new StreamWriter(fileName,true);
            writer.WriteLine(" ");
            writer.WriteLine("[ "+System.DateTime.UtcNow+" ] "+value);
            writer.Close();
        }
    }
}
