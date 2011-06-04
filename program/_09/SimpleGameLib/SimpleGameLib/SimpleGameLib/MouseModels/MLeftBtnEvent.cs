using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.MouseModels
{
    /// <summary>
    /// The left button has been pressed
    /// </summary>
    public class MLeftBtnEvent
    {
        private MouseState state;

        public MLeftBtnEvent()
        {
        }

        public MLeftBtnEvent(MouseState mouse)
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
