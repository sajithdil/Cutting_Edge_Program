using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimpleGameLib.Players
{
    /// <summary>
    /// A single character in the game world
    /// </summary>
    public class Player
    {
        private String name;
        private float x;
        private float y;
        private State state;

        private State walkLeft;
        private State walkRight;
        private State idleState;


        public State PlayerState { get { return state; } set { state = value; } }
        public State Idle { get { return idleState; } set { idleState = value; } }
        public State WalkRight { get { return walkRight; } set { walkRight = value; } }
        public State WalkLeft { get { return walkLeft; } set { walkLeft = value; } }


        public Player(String n,float xp,float yp)
        {
            name = n;
            x = xp;
            y = yp;
        }

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// The state of the player is updated
        /// </summary>
        public void update()
        {
            state.move();
        }

        /// <summary>
        /// The resources used by the player are freed
        /// </summary>
        public void destroy()
        {
            state.destroy();
        }

    }
}
