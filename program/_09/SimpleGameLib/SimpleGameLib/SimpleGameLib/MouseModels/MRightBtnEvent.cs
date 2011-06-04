using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.MouseModels
{
    /// <summary>
    /// The right mouse button has been pressed
    /// </summary>
    public class MRightBtnEvent
    {
        private MouseState state;

        public MRightBtnEvent()
        {

        }

        public MRightBtnEvent(MouseState mouse)
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
