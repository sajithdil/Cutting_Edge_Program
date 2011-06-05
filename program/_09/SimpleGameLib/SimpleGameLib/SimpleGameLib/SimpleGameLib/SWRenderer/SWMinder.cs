using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SimpleWindow.Controller;
using SimpleWindow.Structure;

namespace SimpleGameLib.SWRenderer
{
    public class SWMinder
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
        


        //The function acts as a listener for mouse state changes
        public void listenForLeftClicks(MouseState state)
        {
            //Build a rectangle
            Rectangle cursor = new Rectangle(state.X, state.Y, 32, 32);

            checkOnClickCollisions(cursor);
        }

        //The function checks whether a collision has occured between the mouse and 
        public void checkOnClickCollisions(Rectangle rect)
        {
            foreach (SWFrameModel model in models)
            {
                GObject temp = model.getCollision(model, rect);

                if( (temp != null)&&(temp.OnClick!=null))
                {
                    String script = temp.OnClick.Script;
                    System.Console.WriteLine("The script : "+script+" was activated. ");
                }

            }
        }
    }
}
