using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.Events;
using SimpleGameLib.AssetKeeper;
using SimpleGameLib.XML;
using SimpleGameLib.PythonScp;

namespace SimpleGameLib
{
    /// <summary>
    /// The class is used to store information about a game world
    /// </summary>
    public class World
    {
        private MapInformation map;
        private EventMap eventMap;
        private AssetsKeeper assets;
        private String assetFile;
        private String eventFile;
        private String mapFile;
        private String name;
        private String scriptFile;

        

        public World(String name,String assets,String events,String map)
        {
            this.assetFile = assets;
            this.name = name;
            this.eventFile = events;
            this.mapFile = map;
            this.scriptFile = "";

            this.assets = new AssetsKeeper();
            this.map = new MapInformation();
            this.eventMap = new EventMap();
        }

        public World()
        {
            this.assetFile = "";
            this.name = "";
            this.eventFile = "";
            this.mapFile = "";
            this.scriptFile = "";

            this.assets = new AssetsKeeper();
            this.map = new MapInformation();
            this.eventMap = new EventMap();
        }

        /// <summary>
        /// The events in the map 
        /// </summary>
        public EventMap EventMapData
        {
            get
            {
                return eventMap;
            }
            set
            {
                eventMap = value;
            }
        }

        /// <summary>
        /// The look of the map
        /// </summary>
        public MapInformation MapData
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

        /// <summary>
        /// The assets which make up the map
        /// </summary>
        public String AssetFile
        {
            get
            {
                return assetFile;
            }
            set
            {
                assetFile = value;
            }
        }

        /// <summary>
        /// The name of the world
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public String MapFile
        {
            get
            {
                return mapFile;
            }
            set
            {
                mapFile = value;
            }
        }

        public String EventMapFile
        {
            get
            {
                return eventFile;
            }
            set
            {
                eventFile = value;
            }
        }


        public String ScriptFile
        {
            get
            {
                return scriptFile;
            }

            set
            {
                scriptFile = value;
            }
        }

        /// <summary>
        /// Load the data
        /// </summary>

        public void init()
        {
            Log.getInstance().log("@Folder:WorldData, Class:World, Log Type: Program Run Log, Line No: 158, " + "World loading world " + Name);
            eventMap.init(eventFile);
            map.init(mapFile);
            assets.init(assetFile);

            Log.getInstance().log("@Folder:WorldData, Class:World, Log Type: Program Run Log, Line No: 163, " + "World executing the world script : " + scriptFile);

            if (ScriptFile != "")
            {
                PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript(scriptFile));
            }
            else
            {
                Log.getInstance().log("@Folder:WorldData, Class:World, Log Type: Error, Line No: 171, " + "World no world script file entered");
            }

            Log.getInstance().log("@Folder:WorldData, Class:World, Log Type: Program Run Log, Line No: 174, " + "World finished executing the world script");
            Log.getInstance().log("@Folder:WorldData, Class:World, Log Type: Program Run Log, Line No: 155, " + "World finished loading the world " + Name);
        }

        //Remove all the data which was loaded
        public void destroy()
        {
            eventMap.destroy();
            map.destroy();
            assets.destroy();
        }

        

    }
}
