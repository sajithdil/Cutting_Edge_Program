using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Animations;

namespace SimpleGameLib.Players
{
    public class WalkRightState:State
    {
        public WalkRightState()
        {
        }

        public WalkRightState(String a,Player p):base(a,p)
        {
        }

        public override void move()
        {
            PlayerOfState.X += 1;
            //Update the state
            reflectGeoChanges();
        }

        public override void end()
        {

            PlayerOfState.State = PlayerOfState.Idle;
            //AnimationSeq.kill();
        }
    }
}
