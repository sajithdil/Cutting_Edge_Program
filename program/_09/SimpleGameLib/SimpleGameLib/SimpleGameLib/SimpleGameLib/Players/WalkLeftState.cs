using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Animations;

namespace SimpleGameLib.Players
{
    public class WalkLeftState:State
    {
        public WalkLeftState(String a,Player p):base(a,p)
        {              
        }

        public override void collide()
        {
            PlayerOfState.State = PlayerOfState.Idle;
        }

        public override void end()
        {
            PlayerOfState.State = PlayerOfState.Idle;
        }
    }
}
