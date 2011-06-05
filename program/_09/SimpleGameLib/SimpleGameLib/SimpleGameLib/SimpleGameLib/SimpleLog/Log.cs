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
            writer.WriteLine("Types of Log:");
            writer.WriteLine("Error Log: There is a problem with the program that needs to be fixed.\n This error mostly occurs due to the fact that an error occured with the scripting or loading a file and not due to the fact that there is something wrong with the library.");
            writer.WriteLine("Program Run Log: This log means that everything pertaining to this line of log has loaded itself sucessfully");
            writer.WriteLine("");
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
