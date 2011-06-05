using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameLib.Asset;


namespace SimpleGameLib
{
    public class MapObject
    {
        private String imageAlias;
        private float x;
        private float y;
        private bool collision;
        private bool visible;
        private Rectangle cbox;
        private int width;
        private int height;
        private String alias;

        public MapObject()
        {
            imageAlias = "";
            alias = "";
            x = 0;
            y = 0;
            collision = false;
            visible = true;
            width=32;
            height=32;
            cbox = new Rectangle((int) x,(int) y, width, height);
        }

        public MapObject(String alias,String imgAlias,float x,float y,Boolean collision,Boolean visible):base()
        {
            this.alias = alias;
            this.imageAlias = imgAlias;
            this.x = x;
            this.y = y;
            this.collision = collision;
            this.visible = visible;
            this.cbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
        }

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public bool Collision
        {
            get
            {
                return collision;
            }
            set
            {
                collision = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public String ImageAlias
        {
            get
            {
                return imageAlias;
            }
            set
            {
                imageAlias = value;
            }
        }

        public Rectangle CBox
        {
            get
            {
                return cbox;
            }
            set
            {
                cbox = value;
            }
        }

        public String Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public void updateCBox()
        {
            
        }

        public virtual void render(SpriteBatch batch)
        {
            batch.Draw(Assets.getInstance().get(imageAlias).Texture, new Rectangle((int)x, (int)y, width, height), Color.White);
        }
    }
}
