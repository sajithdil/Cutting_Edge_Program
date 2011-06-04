using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using SimpleGameLib.PythonScp;
using SimpleGameLib.XML;

namespace SimpleGameLib.Events
{
    /// <summary>
    /// The class is used to load the event map from an xml source file
    /// </summary>
    public class EventMap
    {

        private Dictionary<String, EventObject> events;

        public EventMap()
        {
            events = new Dictionary<String, EventObject>();
        }

        public void addEvent(EventObject obj)
        {
            try
            {
                events.Add(obj.Name, obj);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@EventMap could not add event object" + obj.Name+ " " + e.ToString());
            }
        }

        /// <summary>
        /// The function searches for an event by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventObject getEventByName(String name)
        {
            try
            {
                return (events[name]);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@EventMap " + this.ToString() + " could not find the event " + name + " st " + System.Environment.StackTrace);
                return (null);
            }
        }

        /// <summary>
        /// The function removes an event by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool killEventByName(String name)
        {
            try
            {
                events.Remove(name);
                return (true);
            }
            catch(Exception e)
            {
                Log.getInstance().log("@EventMap " + this.ToString() + " the event " + name + " could not kill the event st " + System.Environment.StackTrace);
                return (false);
            }
        }

        /// <summary>
        /// The function checks whether there has been a collision
        /// </summary>
        /// <param name="pyth"></param>
        /// <param name="player"></param>
        public void checkCollisionsWithPlayer(PythonObject pyth, Rectangle player)
        {
            IEnumerator<EventObject> iter = events.Values.GetEnumerator();

            while (iter.MoveNext())
            {
                if (((iter.Current.Triggered == Trigger.player_touch) && (iter.Current.getCollisionBox().Intersects(player)))
                    &&(iter.Current.Alive==true))
                {
                    //Remove the event
                    iter.Current.Alive = false;

                    //Execute the event
                    pyth.executeString(ScriptKeeper.getInstance().getScript(iter.Current.ScriptFile));
                }
            }

        }

        /// <summary>
        /// The function removes any dead events
        /// </summary>
        public void removeDead()
        {
            IEnumerator<EventObject> iter = events.Values.GetEnumerator();
            List<String> mark = new List<string>();

            //Find all the events which have been marked for removal
            while (iter.MoveNext())
            {
                if (iter.Current.Alive == false)
                {
                    mark.Add(iter.Current.Name);

                }
            }

            //Remove from the map
            foreach (String ev in mark)
            {
                events.Remove(ev);
                Log.getInstance().log("@EventMap removing the event " + ev);
            }

        }

        /// <summary>
        /// The function loads the events
        /// </summary>
        /// <param name="source"></param>
        public void init(String source)
        {
            Log.getInstance().log("@EventMap " + this.ToString() + " from " + source + " starting to load the events ");


            XMLReader reader = new XMLReader(source);
            reader.process("events");
            reader.getObjectSpace().convert(this.convert);

            Log.getInstance().log("@EventMap " + this.ToString() + " finished loading events " + source);

        }

        public void convert(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;
            float x, y;

            while (iter.MoveNext())
            {
                EventObject obj = new EventObject();
                x = -1;
                y = -1;

                temp = iter.Current.findValueOfProperty("name");

                if (temp != null)
                {
                    obj.Name = temp;
                }

                temp = iter.Current.findValueOfProperty("script_file");

                if (temp != null)
                {
                    obj.ScriptFile = temp;
                }

                temp = iter.Current.findValueOfProperty("x");

                if (temp != null)
                {
                    x = (float)Convert.ToDouble(temp);
                }

                temp = iter.Current.findValueOfProperty("y");

                if (temp != null)
                {
                    y = (float)Convert.ToDouble(temp);
                }


                

                temp = iter.Current.findValueOfProperty("width");

                if (temp != null)
                {
                    obj.Width = Convert.ToInt32(temp);
                }

                temp = iter.Current.findValueOfProperty("height");

                if (temp != null)
                {
                    obj.Height = Convert.ToInt32(temp);
                }

                temp = iter.Current.findValueOfProperty("trigger");

                if (temp != null)
                {
                    obj.Triggered = (Trigger)Convert.ToInt32(temp);
                }


                if ((x > -1) && (y > -1))
                {
                    obj.Pos = new Vector2(x, y);
                }

                events.Add(obj.Name, obj);
            }
        }

        public void destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
