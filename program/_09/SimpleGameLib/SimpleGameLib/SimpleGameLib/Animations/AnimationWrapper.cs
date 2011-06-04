using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SimpleGameLib.Asset;

namespace SimpleGameLib.Animations
{
    public class AnimationWrapper
    {
        String alias;
        List<String> frames;
        List<Texture2D> palette;


        public AnimationWrapper(String alias,List<String> list)
        {
            this.alias=alias;
            frames = list;
            palette = new List<Texture2D>();
            getResources();
        }

        public String getAlias()
        {
            return (alias);
        }

        public void getResources()
        {
            List<AssetWrapper> temp = Assets.getInstance().getAssets(frames);
            
            for (int index = 0; index < temp.Count; index++)
            {
                palette.Add(temp.ElementAt(index).Texture);
            }
        }

        public Texture2D getFrame(int count)
        {
            return (palette.ElementAt(count));
        }

        public int getMaximum()
        {
            return (palette.Count);
        }

    }
}
