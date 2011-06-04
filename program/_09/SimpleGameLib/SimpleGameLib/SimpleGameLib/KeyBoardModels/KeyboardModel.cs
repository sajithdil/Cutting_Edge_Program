using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.KeyBoardModels
{
    /// <summary>
    /// The class maintains the state of the keyboard and notifies listeners of changes to the keyboard model
    /// </summary>
    public class KeyboardModel:Observerable
    {
        private static KeyboardModel instance = new KeyboardModel();

        private KeyboardState stateOfModel;

        private KeyboardModel()
        {
            stateOfModel = new KeyboardState() ;
        }

        public static KeyboardModel getInstance()
        {
            return instance;
        }

        /// <summary>
        /// The function updates the state of the model
        /// </summary>
        /// <param name="state"></param>
        public void update(KeyboardState state)
        {
            stateOfModel = state;

            if(state.IsKeyDown(Keys.W))
            {
                setMatter(new KeyDownEvent("W"));
                notifyAll();
            }
            else if(state.IsKeyDown(Keys.D))
            {
                setMatter(new KeyDownEvent("D"));
                notifyAll();
            }
            else if (state.IsKeyDown(Keys.S))
            {
                setMatter(new KeyDownEvent("S"));
                notifyAll();
            }
            else if (state.IsKeyDown(Keys.A))
            {
                setMatter(new KeyDownEvent("A"));
                notifyAll();
            }
            else
            {
                setMatter(new NoKeyPressedEvent());
                notifyAll();
            }
        }
    }
}
