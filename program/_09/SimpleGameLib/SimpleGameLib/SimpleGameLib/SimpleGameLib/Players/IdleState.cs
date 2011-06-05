using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Animations;

namespace SimpleGameLib.Players
{
    public class IdleState:State
    {
        public IdleState(String a,Player p):base(a,p)
        {

        }

        public override void collide()
        {

        }

        public override void end()
        {
            throw new NotImplementedException();
        }
    }
}
