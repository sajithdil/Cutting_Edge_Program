using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.Asset;
using Microsoft.Xna.Framework;

namespace SimpleGameLib
{
    public class MapQuadlilateral : MapObject
    {
        private int unitWidth;
        private int unitHeight;

        public MapQuadlilateral()
            : base()
        {
            unitHeight = 0;
            unitWidth = 0;
        }

        public MapQuadlilateral(String alias, String imgAlias, float x, float y, Boolean collision, Boolean visible, int unitWidth,
            int unitHeight)
            : base(alias, imgAlias, x, y, collision, visible)
        {
            this.unitWidth = unitWidth;
            this.unitHeight = unitHeight;
            CBox = new Rectangle((int)X, (int)Y, (int)(UW * 32), (int)(UH * 32));
        }

        public int UW
        {
            get
            {
                return unitWidth;
            }
            set
            {
                unitWidth = value;
            }
        }

        public int UH
        {
            get
            {
                return unitHeight;
            }
            set
            {
                unitHeight = value;
            }
        }

        public override void updateCBox()
        {
            CBox = new Rectangle((int)X, (int)Y, (int)(UW * 32), (int)(UH * 32));
        }

        public override void render(SpriteBatch batch)
        {

            //Width
            for (int indexOne = 0; indexOne < unitHeight; indexOne++)
            {

                //Height
                for (int indexTwo = 0; indexTwo < unitWidth; indexTwo++)
                {

                    batch.Draw(Assets.getInstance().get(ImageAlias).Texture, new Rectangle(((int)X) + (Width * indexTwo), ((int)Y) + (Height * indexOne), Width, Height), Color.White);
                }
            }
            return;

        }
    }
}
