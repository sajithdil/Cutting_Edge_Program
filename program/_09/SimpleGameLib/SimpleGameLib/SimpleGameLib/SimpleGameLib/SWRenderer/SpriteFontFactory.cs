using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.ContentWrappers;


namespace SimpleGameLib.SWRenderer
{
    /// <summary>
    /// The class is used to load and maitain fonts
    /// </summary>
    public class SpriteFontFactory
    {
        private Dictionary<String, SpriteFont> fonts;

        private SpriteFontFactory()
        {
            fonts = new Dictionary<string, SpriteFont>();
        }

        public void load()
        {
            //Load the fonts
            SpriteFont temp = ContentWrapper.getInstance().getContents().Load<SpriteFont>("NormalFont");
            fonts.Add("NormalFont", temp);
        }

        private static SpriteFontFactory intance = new SpriteFontFactory();

        public static SpriteFontFactory getInstance()
        {
            return (intance);
        }

        public SpriteFont findFont(String name)
        {
            return (fonts[name]);
        }
    }
}
