using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.KeyBoardModels
{
    /// <summary>
    /// The class is used to notify listeners of keyboard down events
    /// </summary>
    public class KeyDownEvent
    {
        private String key;

        public KeyDownEvent()
        {
            key = "";
        }

        public KeyDownEvent(String k)
        {
            key = k;
        }

        public String Key
        {
            get { return key; }
            set { key = value; }
        }
    }
}
