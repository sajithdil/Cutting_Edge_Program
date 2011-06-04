using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.ContentWrappers;

namespace SimpleGameLib.Asset
{
    /// <summary>
    /// The class contains the data for an asset
    /// </summary>
    public class AssetWrapper
    {
        private Texture2D texture;
        private String alias;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public String Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        public AssetWrapper(String alias)
        {
            try
            {
                this.alias = alias;
                texture = ContentWrapper.getInstance().getContents().Load<Texture2D>(alias);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@AssetWrapper could not load the asset");
            }
        }


    }
}
