using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Players
{
    public class WalkUpState:State
    {
        public WalkUpState()
        {
        }

        public WalkUpState(String a,Player p):base(a,p)
        {
        }

        public override void move()
        {
            PlayerOfState.Y -= 1;
            //Update the state
            reflectGeoChanges();
        }

        public override void end()
        {
            PlayerOfState.State = PlayerOfState.Idle;
        }
    }
}
