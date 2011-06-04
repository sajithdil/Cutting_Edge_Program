using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SimpleWindow.Controller;
using SimpleWindow.Structure;
using SimpleGameLib.KeyBoardModels;
using SimpleGameLib.MouseModels;
using SimpleGameLib.PythonScp;

namespace SimpleGameLib.SWRenderer
{
    /// <summary>
    /// The SWMinder maintains the UI
    /// </summary>
    public class SWMinder:Observer
    {
        private List<SWFrameModel> models;

        private SWFrameModel opWindow;

        public SWFrameModel OpWindow { get { return opWindow; } set { opWindow = value; } }

        public void killOpWindow()
        {
            System.Console.WriteLine("Killing opWindow...");
        }


        public SWMinder()
        {
            models = new List<SWFrameModel>();
        }

        public void add(SWFrameModel obj)
        {
            models.Add(obj);
        }

        public IEnumerator<SWFrameModel> getEnum()
        {
            return models.GetEnumerator();
        }

        /// <summary>
        /// The function generates models from the controller data
        /// </summary>
        /// <param name="g"></param>
        /// <param name="map"></param>
        /// <param name="style"></param>
        public void generate(GController g,Skinner map,Style style)
        {
            IEnumerator<GObject> iter = g.getEnumerator();

            while (iter.MoveNext())
            {
                models.Add(new SWFrameModel(iter.Current, map, style));
            }
        }

        //The function draws all the elements
        public void draw(SpriteBatch batch)
        {
            foreach (SWFrameModel m in models)
            {
                m.draw(batch);
            }
        }

        /// <summary>
        /// The function is used to check whether the model is alive
        /// </summary>
        public void update()
        {
            for (int i = 0; i < models.Count; i++)
            {
                //Remove the model if it is dead
                if (models.ElementAt(i).isAlive() == false)
                {
                    models.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// The function locates a model from the list
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public SWFrameModel getModel(String alias)
        {
            for (int i = 0; i <models.Count; i++)
            {
                //Find the models
                if (models.ElementAt(i).ModelData.Name == alias)
                {
                    return models.ElementAt(i);
                }
            }

            return null;
        }


        //The function acts as a listener for mouse state changes
        public void listenForLeftClicks(MouseState state)
        {
            //Build a rectangle
            Rectangle cursor = new Rectangle(state.X, state.Y, 32, 32);

            checkOnClickCollisions(cursor);
        }

        //The function checks whether a collision has occured between the mouse and 
        //a given collisiom box
        public void checkOnClickCollisions(Rectangle rect)
        {
            foreach (SWFrameModel model in models)
            {
                GObject temp = model.getCollision(model, rect);

                if( (temp != null)&&(temp.OnClick!=null))
                {
                    String script = temp.OnClick.Script;
                    //PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript(script));
                    //System.Console.WriteLine("The script : "+script+" was activated. ");

                    Log.getInstance().log("@SWMinder RAN SCRIPT : " + script);
                   
                }

            }
        }

        /// <summary>
        /// All events are handled here
        /// </summary>
        /// <param name="obj"></param>
        public void notify(Object obj)
        {
            MLeftBtnEvent left = new MLeftBtnEvent();

            //Check for a left click
            if (obj.GetType().Equals(left.GetType()))
            {
                left = (MLeftBtnEvent)obj;
                leftClick(left);
            }
        }


        /// <summary>
        /// The function handles all left click events
        /// </summary>
        /// <param name="left"></param>
        public void leftClick(MLeftBtnEvent left)
        {
            //Create a collision box
            Rectangle cbox = new Rectangle(left.State.X, left.State.Y, 32, 32);

            //Get a list of all scripts to run
            List<String> targets = new List<String>();

            foreach (SWFrameModel model in models)
            {
                GObject temp = model.getCollision(model, cbox);

                //Activate the script only if it is active
                if (((temp != null) && (temp.OnClick != null))&&(temp.OnClick.Active==true))
                {
                    String script = temp.OnClick.Script;
                    targets.Add(script);

                    //Turn off the click event so it is not activated again
                    temp.OnClick.Active = false;
                }

            }

            //Execute the scripts
            for (int index = 0; index < targets.Count; index++)
            {
                PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript(targets.ElementAt(index)));
            }

        }
    }
}
