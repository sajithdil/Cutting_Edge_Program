using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleGameLib.KeyBoardModels;
using Microsoft.Xna.Framework;
using SimpleGameLib.Inventorys;

namespace SimpleGameLib.Players
{
    /// <summary>
    /// A single character in the game world
    /// </summary>
    public class Player : Observer
    {
        private String name;
        private float x;
        private float y;
        private Rectangle cbox;

        private State state;

        private State walkLeft;
        private State walkRight;
        private State walkDown;
        private State walkUp;
        private State idleState;
        private State collisionState;
        private Inventory inventory;


        public State PlayerState { get { return state; } set { state = value; } }
        public State Idle { get { return idleState; } set { idleState = value; } }
        public State WalkRight { get { return walkRight; } set { walkRight = value; } }
        public State WalkLeft { get { return walkLeft; } set { walkLeft = value; } }
        public State WalkUp { get { return walkUp; } set { walkUp = value; } }
        public State WalkDown { get { return walkDown; } set { walkDown = value; } }
        public State Collision { get { return collisionState; } set { collisionState = value; } }


        public Player(String n, float xp, float yp)
        {
            name = n;
            x = xp;
            y = yp;
            inventory = new Inventory();
        }

        public Inventory InventoryData
        {
            get { return inventory; }
            set { inventory = value; }
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

        public void updateCBox()
        {
            cbox = new Rectangle((int)x, (int)y, 32, 32);
        }

        public Rectangle CBox
        {
            get { return cbox; }
            set { cbox = value; }
        }

        /// <summary>
        /// The state of the player is updated
        /// </summary>
        public void update()
        {
            //state.move();

            //Update the collision box of the player
            updateCBox();
            state.reflectGeoChanges();
        }

        /// <summary>
        /// The resources used by the player are freed
        /// </summary>
        public void destroy()
        {
            state.destroy();
        }

        /// <summary>
        /// The function listens for state change information based on keyboard events
        /// </summary>
        /// <param name="obj"></param>
        public void notify(object obj)
        {
            KeyDownEvent type = new KeyDownEvent();

            //WASD keys pressed
            if (obj.GetType().Equals(type.GetType()))
            {
                type = (KeyDownEvent)obj;
                changeState(type);
            }

            NoKeyPressedEvent noPress = new NoKeyPressedEvent();

            //No key has been pressed
            if (obj.GetType().Equals(noPress.GetType()))
            {
                state.end();
                state = idleState;
                state.move();
            }
        }

        public void playerCollision()
        {
            collisionState.Previous = state;
            state = collisionState;
            state.move();
        }

        /// <summary>
        /// The function handles the change state
        /// </summary>
        /// <param name="keyEvent"></param>w
        public void changeState(KeyDownEvent keyEvent)
        {
            if (keyEvent.Key == "W")
            {
                
                //Change the state to walk left
                state.end();
                state = walkUp;
                state.update();
                state.move();
            }
            else if (keyEvent.Key == "S")
            {
                
                state.end();
                state = walkDown;
                state.update();
                state.move();
            }
            else if (keyEvent.Key == "A")
            {
                
                state.end();
                state = walkLeft;
                state.update();
                state.move();
            }
            else if (keyEvent.Key == "D")
            {
               
                state.end();
                state = walkRight;
                state.update();
                state.move();
            }
        }

        /// <summary>
        /// The function changes the position of the player
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void setPosition(float xp, float yp)
        {
            x = xp;
            y = yp;
        }

    }
}
