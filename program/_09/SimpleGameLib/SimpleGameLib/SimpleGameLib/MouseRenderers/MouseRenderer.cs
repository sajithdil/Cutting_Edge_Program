using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.KeyBoardModels;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.Asset;
using Microsoft.Xna.Framework;
using SimpleGameLib.MouseModels;

namespace SimpleGameLib.MouseRenderers
{
    /// <summary>
    /// The class is used to maintain the position of the cursor
    /// </summary>
    public class MouseRenderer:Observer
    {
        private String alias;
        private Rectangle cBox;
        private AssetWrapper wrapper;

        public MouseRenderer()
        {
            alias = "";
        }

        public MouseRenderer(String cursorAlias)
        {
            alias=cursorAlias;
            wrapper=Assets.getInstance().get(alias);
        }

        public void notify(object obj)
        {
            MouseCursorEvent cursorEvent = new MouseCursorEvent();

            //Check for a cursor event
            if (obj.GetType().Equals(cursorEvent.GetType()))
            {
                //Update the state of the collision box
                cursorEvent = (MouseCursorEvent)obj;

                cBox = new Rectangle(cursorEvent.State.X, cursorEvent.State.Y, 32, 32);
            }
        }


        public Rectangle CBox
        {
            get { return cBox; }
            set { cBox = value; }
        }

        public String Alias
        {
            get { return alias; }
            set { alias = value; wrapper = Assets.getInstance().get(alias); } 
        }

        public void render(SpriteBatch batch)
        {
            if (wrapper != null)
            {
                batch.Draw(wrapper.Texture, cBox, Color.Wheat);
                return;
            }

            Log.getInstance().log("@MouseRenderer could not paint the cursor since the texture : " + alias + " was not found.");
        }
    }
}
