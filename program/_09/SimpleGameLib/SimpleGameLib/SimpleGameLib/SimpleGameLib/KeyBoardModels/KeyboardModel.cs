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
    public class KeyboardModel
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

        public void register()
        {
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

            }
            else if(state.IsKeyDown(Keys.D))
            {

            }
            else if (state.IsKeyDown(Keys.S))
            {

            }
            else if (state.IsKeyDown(Keys.A))
            {

            }
        }
    }
}
