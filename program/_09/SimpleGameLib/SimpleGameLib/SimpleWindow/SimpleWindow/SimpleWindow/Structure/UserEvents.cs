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
        private Boolean active;

        public UserEvents(String script)
        {
            this.script = script;
            eventOps = null;
            active = true;
        }

        public UserEvents(handle func)
        {
            eventOps = func;
            script = null;
            active = true;
        }

        public String Script
        {
            get { return script; }
            set { script = value; }
        }

        /// <summary>
        /// Whether the events should be executed or not
        /// </summary>
        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }

    }
}
