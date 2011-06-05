using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.XML;

namespace SimpleGameLib
{
    /// <summary>
    /// The class is used to maintain the worlds
    /// </summary>
    public class WorldsKeeper
    {
        private Dictionary<String, World> information;

        private static WorldsKeeper instance = new WorldsKeeper();

        private World current;

        public static WorldsKeeper getInstance()
        {

            return instance;
        }

        private WorldsKeeper()
        {
            information = new Dictionary<string, World>();
            current = null;
        }

        /// <summary>
        /// The function sets the current world
        /// </summary>
        /// <param name="world"></param>
        public void setCurrent(World world)
        {
            current = world;
        }

        public World getWorld(String id)
        {
            try
            {
                return (information[id]);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@Folder:WorldKeeper, Class:WorldsKeeper, Log Type: Error, Line No: 49, " + "WorldsKeeper could not load the world " + id + " st " + System.Environment.StackTrace);
                System.Console.WriteLine(e);
                System.Environment.Exit(-1);
                return null;
            }

        }

        /// <summary>
        /// The function changes the current world
        /// </summary>
        /// <param name="id"></param>
        public void setToCurrent(String id)
        {
            World world = getWorld(id);
            setCurrent(world);
        }

        public void add(World world)
        {
            information.Add(world.Name, world);
        }


        /// <summary>
        /// Load all the worlds from the xml file
        /// </summary>
        public void init(String file)
        {
            Log.getInstance().log("@Folder:WorldKeeper, Class:WorldsKeeper, Log Type: Program Run Log, Line No: 78, " + "WorldsKeeper loading the worlds");
            XMLReader reader = new XMLReader(file);
            reader.process("worlds");
            reader.getObjectSpace().convert(this.convert);
            Log.getInstance().log("@Folder:WorldKeeper, Class:WorldsKeeper, Log Type: Program Run Log, Line No: 82, " + "WorldsKeeper finished loading the worlds");
        }

        /// <summary>
        /// The function converts the data about the worlds from an xml file
        /// </summary>
        /// <param name="objects"></param>
        public void convert(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;


            while (iter.MoveNext())
            {
                World world = new World();

                temp = iter.Current.findValueOfProperty("name");

                if (temp != null)
                {
                    world.Name = temp;
                }

                temp = iter.Current.findValueOfProperty("map");

                if (temp != null)
                {
                    world.MapFile = temp;
                }

                temp = iter.Current.findValueOfProperty("events");

                if (temp != null)
                {
                    world.EventMapFile = temp;
                }

                temp = iter.Current.findValueOfProperty("assets");

                if (temp != null)
                {
                    world.AssetFile = temp;
                }

                temp = iter.Current.findValueOfProperty("world_script");

                if (temp != null)
                {
                    world.ScriptFile = temp;
                }

                information.Add(world.Name,world);
            }
        }

        /// <summary>
        /// The function returns the current world
        /// </summary>
        /// <returns></returns>
        public World getCurrent()
        {
            if (current == null)
            {
                Log.getInstance().log("@Folder:WorldKeeper, Class:WorldsKeeper, Log Type: Error, Line No: 146, " + "WorldsKeeper Attempt to request the current world ,when the current world does not exist" + System.Environment.StackTrace);
                System.Environment.Exit(-1);
                return null;
            }

            return current;
        }

        /// <summary>
        /// The function checks whether the current world is ready
        /// </summary>
        /// <returns></returns>
        public Boolean isCurrentEmpty()
        {
            if (current == null)
            {
                return true;
            }

            return false;
        }
    }
}
