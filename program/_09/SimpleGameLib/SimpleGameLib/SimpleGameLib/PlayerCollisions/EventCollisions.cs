using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Players;
using SimpleGameLib.SWRenderer;
using SimpleGameLib.Events;
using SimpleGameLib.PythonScp;

namespace SimpleGameLib.PlayerCollisions
{
    /// <summary>
    /// The class checks whether the players has collided with any events
    /// </summary>
    public class EventCollisions
    {
        /// <summary>
        /// The function checks whether each player has collided with an event
        /// </summary>
        /// <param name="players"></param>
        /// <param name="map"></param>
        public static void collisions(PlayerCollection players, EventMap map)
        {
            for (int i = 0; i < players.getAllPlayers().Count; i++)
            {
                map.checkCollisionsWithPlayer(PythonObject.getInstance(), players.getAllPlayers().ElementAt(i).CBox);
            }
        }
    }
}
