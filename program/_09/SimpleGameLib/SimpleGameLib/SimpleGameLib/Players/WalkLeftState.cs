using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Animations;
using SimpleGameLib.KeyBoardModels;

namespace SimpleGameLib.Players
{
    public class WalkLeftState:State
    {
        public WalkLeftState()
        {
        }

        public WalkLeftState(String a,Player p):base(a,p)
        {              
        }

        public override void move()
        {

            PlayerOfState.X -= 1;

            //Update the state
            reflectGeoChanges();
        }

        public override void end()
        {

            //AnimationSeq.kill();
            PlayerOfState.State = PlayerOfState.Idle;
        }
    }
}
