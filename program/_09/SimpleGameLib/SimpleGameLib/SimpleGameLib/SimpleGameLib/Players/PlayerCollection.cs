using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Players
{
    /// <summary>
    /// The player collection maintains the players in the map
    /// </summary>
    public class PlayerCollection
    {
        private List<Player> list;

        /// <summary>
        /// 
        /// </summary>
        public PlayerCollection()
        {
            list = new List<Player>();
        }

        /// <summary>
        /// The function adds a player to the list
        /// </summary>
        /// <param name="player"></param>
        public void add(Player player)
        {
            list.Add(player);
        }

        /// <summary>
        /// The function removes the player with the name
        /// </summary>
        /// <param name="name"></param>
        public void remove(String name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list.ElementAt(i).Name==name)
                {
                    list.ElementAt(i).destroy();
                    list.RemoveAt(i);
                    Log.getInstance().log("@Folder:Players, Class:PlayerCollection, Log Type: Program Run Log, Line No: 44, " + "PlayerCollection removed the player with " + name);
                    return;
                }
            }

            Log.getInstance().log("@Folder:Players, Class:PlayerCollection, Log Type: Error, Line No: 49, " + "PlayerCollection could not find the player with name " + name);
        }


        /// <summary>
        /// The following function updates all the players
        /// </summary>
        public void update()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list.ElementAt(i).update();
            }
        }
    }
}
