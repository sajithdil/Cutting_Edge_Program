using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Players;

namespace SimpleGameLib.PlayerCollisions
{
    public class CollisionCheck
    {
        public static void collision(PlayerCollection players, MapInformation map)
        {
            //Check all players
            for (int indexOne = 0; indexOne < players.getAllPlayers().Count; indexOne++)
            {
                //Check against all objects if they have collision
                for (int indexTwo = 0; indexTwo < map.getAllMapObjects().Count; indexTwo++)
                {
                    MapObject mapObject = map.getAllMapObjects().ElementAt(indexTwo);

                    //Only check if the map object has collision
                    if (mapObject.Collision == true)
                    {
                        //Check if there is a collision
                        if(mapObject.CBox.Intersects(players.getAllPlayers().ElementAt(indexOne).CBox))
                        {
                            players.getAllPlayers().ElementAt(indexOne).playerCollision();
                        }
                    }
                }
            }
        }
    }
}
