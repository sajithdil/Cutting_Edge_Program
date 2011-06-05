using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleGameLib.Players
{
    public interface PlayerState
    {
        /// <summary>
        /// The player collides
        /// </summary>
        void collide();

        /// <summary>
        /// The player starts 
        /// </summary>
        void init();

        /// <summary>
        /// The player ends what he is doing
        /// </summary>
        void end();

        /// <summary>
        /// The playr moves in the state
        /// </summary>
        void move();
    }
}
