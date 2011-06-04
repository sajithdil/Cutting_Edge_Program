using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.XML;

namespace SimpleGameLib
{
    /// <summary>
    /// The class is used to store the visual representation of the map
    /// </summary>
    public class MapInformation
    {
        private List<MapObject> information;

        public MapInformation()
        {
            information = new List<MapObject>();
        }

        public void addMapObject(MapObject mapo)
        {
            information.Add(mapo);
        }

        /// <summary>
        /// The function returns all objects in the map
        /// </summary>
        /// <returns></returns>
        public List<MapObject> getAllMapObjects()
        {
            return information;
        }

        /// <summary>
        /// The function finds
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MapObject findMapObject(String id)
        {
            IEnumerator<MapObject> iter = information.GetEnumerator();

            while (iter.MoveNext())
            {
                if (iter.Current.Alias == id)
                {
                    return iter.Current;
                }
            }

            Log.getInstance().log("@MapInformation " + this.ToString() + " could not find the map item with alias " + id + " st " + System.Environment.StackTrace);

            return null;
        }

        /// <summary>
        /// The function renders the map to screen using spritebatch
        /// </summary>
        /// <param name="batch"></param>
        public void render(SpriteBatch batch)
        {
            for (int i = 0; i < information.Count; i++)
			{
                if (information.ElementAt(i).Visible == true)
                {
                    information.ElementAt(i).render(batch);
                }
			}
        }
       
        /// <summary>
        /// The function loads the map information from an xml file
        /// </summary>
        /// <param name="source"></param>
        public void init(String source)
        {
            Log.getInstance().log("@MapInformation " + this.ToString() + " starting to load the map " + source);

            XMLReader reader = new XMLReader(source);
            reader.process("mapObject");
            reader.getObjectSpace().convert(this.getMapObjects);

            reader = new XMLReader(source);
            reader.process("mapQuads");
            reader.getObjectSpace().convert(this.getMapQuads);

            Log.getInstance().log("@MapInformation " + this.ToString() + " finished loading the map information from " + source);

        }

        /// <summary>
        /// The functions converts the xml data 
        /// </summary>
        /// <param name="objects"></param>
        public void getMapObjects(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;


            while (iter.MoveNext())
            {
                MapObject obj = new MapObject();

                temp = iter.Current.findValueOfProperty("x");
                if (temp != null)
                {
                    obj.X = (float) Convert.ToDouble(temp);
                }

                temp = iter.Current.findValueOfProperty("y");

                if (temp != null)
                {
                    obj.Y = (float)Convert.ToDouble(temp);
                }

   
                temp = iter.Current.findValueOfProperty("visible");

                if (temp != null)
                {
                    obj.Visible=Convert.ToBoolean(temp);
                }

                temp = iter.Current.findValueOfProperty("collision");

                if (temp != null)
                {
                    obj.Collision = Convert.ToBoolean(temp);
                }


                temp = iter.Current.findValueOfProperty("image");

                if (temp != null)
                {
                    obj.ImageAlias = temp;
                }


                temp = iter.Current.findValueOfProperty("alias");

                if (temp != null)
                {
                    obj.Alias = temp;
                    obj.updateCBox();
                }

                information.Add(obj);
            }
        }

        /// <summary>
        /// The function converts the xml data
        /// </summary>
        /// <param name="objects"></param>
        public void getMapQuads(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;


            while (iter.MoveNext())
            {
                MapQuadlilateral obj = new MapQuadlilateral();

                temp = iter.Current.findValueOfProperty("x");
                if (temp != null)
                {
                    obj.X = (float)Convert.ToDouble(temp);
                }

                temp = iter.Current.findValueOfProperty("y");

                if (temp != null)
                {
                    obj.Y = (float)Convert.ToDouble(temp);
                }


                temp = iter.Current.findValueOfProperty("visible");

                if (temp != null)
                {
                    obj.Visible = Convert.ToBoolean(temp);
                }

                temp = iter.Current.findValueOfProperty("collision");

                if (temp != null)
                {
                    obj.Collision = Convert.ToBoolean(temp);
                }


                temp = iter.Current.findValueOfProperty("image");

                if (temp != null)
                {
                    obj.ImageAlias = temp;
                }


                temp = iter.Current.findValueOfProperty("alias");

                if (temp != null)
                {
                    obj.Alias = temp;
                }

                temp = iter.Current.findValueOfProperty("unitw");

                if (temp != null)
                {
                    obj.UW = Convert.ToInt32(temp);
                }

                temp = iter.Current.findValueOfProperty("unith");

                if (temp != null)
                {
                    obj.UH = Convert.ToInt32(temp);
                }

                obj.updateCBox();

                information.Add(obj);
            }
        }

        public void destroy()
        {
            throw new System.NotImplementedException();
        }

    }
}
