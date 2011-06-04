using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.KeyBoardModels;

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

            //Subscribe to the keyboard model
            KeyboardModel.getInstance().addObserver(player);
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
                    Log.getInstance().log("@PlayerCollection removed the player with " + name);
                    return;
                }
            }

            Log.getInstance().log("@PlayerCollection could not find the player with name " + name);
        }

        public List<Player> getAllPlayers()
        {
            return list;
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

        /// <summary>
        /// The function allows access to the player
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Player getPlayerAt(int index)
        {
            if (index < list.Count)
            {
                return list.ElementAt(index);
            }

            Log.getInstance().log("@PlayerCollection attempt to access a player when the collection is empty");
            System.Environment.Exit(-1);
            return null;
        }
    }
}
