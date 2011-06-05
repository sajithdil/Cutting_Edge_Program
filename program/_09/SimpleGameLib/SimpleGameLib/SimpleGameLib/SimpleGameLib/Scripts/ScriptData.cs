using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Scripts
{
    /// <summary>
    /// The class contains the data of the script
    /// </summary>
    public class ScriptData
    {
        private String alias;
        private String file;
        private String data;

        public String Alias { get { return alias; } set { alias = value; } }
        public String File { get { return file; } set { file = value; } }

        public String Data { get { return data; } set { data = value; } }

        public ScriptData()
        {
            alias = "";
            file = "";
            data = "";
        }
    }
}
