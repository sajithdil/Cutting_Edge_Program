using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleWindow.Structure;


namespace SimpleGameLib.SWRenderer
{
    public class SWFrameModel
    {
        private Rectangle box;
        private GObject obj;
        private Texture2D texture;
        private List<SWFrameModel> models;
        private Boolean alive;

        public SWFrameModel(GObject ov, Skinner map, Style style)
        {
            obj = ov;
            box = new Rectangle((int)obj.X, (int)obj.Y, obj.Width, obj.Height);
            models = new List<SWFrameModel>();
            texture = map.getTexture(style, ov);
            alive = true;

            //Add Gobjects inside if owns other elements
            if (ov.isOwner() == true)
            {
                List<GObject> p = new List<GObject>();
                p = obj.getAllObjectsOwned(p);

                //Create models for all 

                foreach (GObject g in p)
                {
                    models.Add(new SWFrameModel(g, map, style));
                }
            }
        }

        public GObject ModelData { get { return obj; } set { obj = value; } }

        public Rectangle Box { get { return box; } set { box = value; } }

        public Boolean isCollision(Rectangle cursor) { if (box.Intersects(cursor)) { return true; } else { return false; } }

        //The function checks whether there are any child elements
        public Boolean isOwner()
        {
            if (models.Count == 0)
            {
                return false;
            }

            return true;
        }


        //The following function draws the frame
        public void draw(SpriteBatch batch)
        {
            //Draw the texture
            if (texture != null)
            {
                //Draw the current 
                batch.Draw(texture, box, Color.White);
            }

            //Draw the text if it should be displayed
            if (obj.TextVisible == true)
            {
                batch.DrawString(SpriteFontFactory.getInstance().findFont("NormalFont"), obj.Text, new Vector2(obj.X, obj.Y), Color.White);
            }

            //Attempt to draw any objects owned
            foreach (SWFrameModel model in models)
            {
                model.draw(batch);
            }
        }

        /// <summary>
        /// The function kills the model
        /// </summary>
        public void kill()
        {
            Log.getInstance().log("Attempting to kill the model");
            alive = false;
        }

        /// <summary>
        /// The function checks whether the model is alive
        /// </summary>
        /// <returns></returns>
        public Boolean isAlive()
        {
            return alive;
        }

        //The function determines whether a collision has taken place between cursor and
        //models
        public GObject getCollision(SWFrameModel parent, Rectangle cursor)
        {
            if (parent.isOwner() == false)
            {
                //Check for an interesection
                if (parent.isCollision(cursor) == true)
                {
                    return (parent.ModelData);
                }

                return null;
            }
            else
            {

                foreach (SWFrameModel model in models)
                {
                    GObject result = getCollision(model, cursor);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return (null);
        }


        //The function returns all elements in the model
        public List<SWFrameModel> getAllObjectsOwned(List<SWFrameModel> list)
        {
            if (models.Count == 0)
            {
                list.Add(this);
                return (list);
            }
            else
            {

                foreach (SWFrameModel model in models)
                {
                    list = model.getAllObjectsOwned(list);
                }

                return list;
            }
        }



    }
}
