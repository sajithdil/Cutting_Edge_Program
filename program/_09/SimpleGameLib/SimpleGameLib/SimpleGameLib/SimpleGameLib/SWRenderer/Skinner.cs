using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SimpleWindow.Structure;
using SimpleGameLib.Asset;


namespace SimpleGameLib.SWRenderer
{
    public class Skinner
    {
        public  Texture2D getTexture(Style style,GObject g)
        {
            String alias;

            GButton ob = new GButton();

            //Check for buttons
            if (g.GetType().Equals(ob.GetType()))
            {
                //Determine whether the button is down
                ob = (GButton)g;

                if (ob.IsClicked== true)
                {
                    alias = style.getSkin("BUTTON_DOWN");
                    return (Assets.getInstance().get(alias).Texture);
                }

                alias = style.getSkin("BUTTON_UP");
                return (Assets.getInstance().get(alias).Texture);             
            }

            //Check for Frames
            GFrame test = new GFrame();
            if(g.GetType().Equals(test.GetType()))
            {
                test = (GFrame)g;

                alias = test.Background;
                return(Assets.getInstance().get(alias).Texture);
            }

            GImageFrame image = new GImageFrame();
            //Check for image frames
            if(g.GetType().Equals(image.GetType()))
            {
                image=(GImageFrame) g;

                return(Assets.getInstance().get(image.Image).Texture);
            }
           
            return (null);
        }

        
    }
}
