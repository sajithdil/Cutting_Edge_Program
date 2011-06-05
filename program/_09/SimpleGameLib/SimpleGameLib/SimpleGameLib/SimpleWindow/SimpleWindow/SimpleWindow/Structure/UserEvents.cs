using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public class UserEvents
    {
        private String script;
        public delegate void handle(GObject owner);
        private handle eventOps;

        public UserEvents(String script)
        {
            this.script = script;
            eventOps = null;
        }

        public UserEvents(handle func)
        {
            eventOps = func;
            script = null;
        }

        public String Script
        {
            get { return script; }
            set { script = value; }
        }

    }
}
