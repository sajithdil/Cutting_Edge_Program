using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.MouseModels
{
    public class MouseCursorEvent
    {
        private MouseState state;

        public MouseCursorEvent()
        {

        }

        public MouseCursorEvent(MouseState mouse)
        {
            state = mouse;
        }

        public MouseState State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
