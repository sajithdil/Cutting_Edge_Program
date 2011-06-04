using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.KeyBoardModels;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.MouseModels
{
    /// <summary>
    /// The class maintains the state of the mouse and informs listeners of 
    /// changes to it state
    /// </summary>
    public class MouseModel:Observerable
    {
        private MouseState state;

        private static MouseModel instance = new MouseModel();


        public static MouseModel getInstance()
        {
            return instance;
        }

        private MouseModel()
        {
            state = new MouseState();
        }

        public void update(MouseState mouse)
        {
            state = mouse;

            //Update the mouse cursor position
            setMatter(new MouseCursorEvent(state));
            notifyAll();

            //Check if the left mouse button has been pressed
            if (state.LeftButton==ButtonState.Pressed)
            {
                setMatter(new MLeftBtnEvent(state));
                notifyAll();
            }

            //Check if the right mouse button has been pressed
            if (state.RightButton == ButtonState.Pressed)
            {
                setMatter(new MRightBtnEvent(state));
                notifyAll();
            }
        }
    }
}
