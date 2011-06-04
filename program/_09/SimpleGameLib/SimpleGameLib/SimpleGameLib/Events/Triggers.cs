using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Events
{
    public enum Trigger : int
    {
        inactive=0,
        player_touch=1,
        mouse_click=2
    }
}
