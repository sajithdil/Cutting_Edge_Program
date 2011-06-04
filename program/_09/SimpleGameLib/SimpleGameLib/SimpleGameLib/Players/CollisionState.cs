using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Players
{
    /// <summary>
    /// The player has collided with an object
    /// </summary>
    public class CollisionState:State
    {
       

        public CollisionState()
        {
        }

        public CollisionState(String a,Player p):base(a,p)
        {
            Previous = null;
        }



        public override void move()
        {
            if (Previous == null)
            {
                Log.getInstance().log("@CollisionState attempted to move in the collision state without a previous state");
                return;
            }

            WalkUpState up=new WalkUpState();
            if(Previous.GetType().Equals(up.GetType()))
            {
                PlayerOfState.Y +=10;
            }

            WalkDownState down=new WalkDownState();
            if(Previous.GetType().Equals(down.GetType()))
            {
                PlayerOfState.Y -= 10;
            }

            WalkLeftState left=new WalkLeftState();
            if(Previous.GetType().Equals(left.GetType()))
            {
                PlayerOfState.X += 10;
            }

            WalkRightState right=new WalkRightState();
            if(Previous.GetType().Equals(right.GetType()))
            {
                PlayerOfState.X -= 10;
            }

            base.reflectGeoChanges();
        }
    }
}
