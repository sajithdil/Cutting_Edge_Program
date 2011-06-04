using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Animations;
using Microsoft.Xna.Framework;

namespace SimpleGameLib.Players
{
    public abstract class State :PlayerState
    {
        private AnimationSequence animation;
        private Player player;


        public AnimationSequence AnimationSeq
        {
            get { return animation; }
            set { animation = value; }
        }

        public Player PlayerOfState
        {
            get { return player; }
            set { player = value; }
        }

        public State()
        {
            animation = null;
            player = null;
        }

        private State previous;

        public State Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public State(String alias,Player p)
        {
            animation = new AnimationSequence(alias);
            player = p;

            //Register the animation
            AnimationSpace.getInstance().addAnimation(animation);

            animation.setPos(new Vector2(player.X, player.Y));
            //Intialize the state
            init();
        }

        public void update()
        {
            AnimationSpace.getInstance().addAnimation(animation);
        }

        public virtual void collide()
        {
            PlayerOfState.State = PlayerOfState.Idle;
        }

        public void init()
        {
            reflectGeoChanges();
            animation.play();
        }

        public virtual void end()
        {

            PlayerOfState.State = PlayerOfState.Idle;
            //animation.stop();
            animation.kill();
           // animation.stop();
        }


        /// <summary>
        /// The function updates the position of the owner
        /// </summary>
        public void reflectGeoChanges()
        {
            animation.setPos(new Vector2(player.X, player.Y));
        }

        /// <summary>
        /// The player begins to move 
        /// </summary>
        public virtual void move()
        {
            reflectGeoChanges();
        }

        /// <summary>
        /// Destroy the resources used by the state
        /// </summary>
        public void destroy()
        {

        }
    }
}
