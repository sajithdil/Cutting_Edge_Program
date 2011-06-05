using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimpleGameLib.Events
{
    /// <summary>
    /// The class is used to describe an event object
    /// </summary>
    public class EventObject
    {
        private String scriptFile;
        private Vector2 pos;
        private Trigger trigger;
        private String name;
        private Rectangle box;
        private int w, h;
        private Boolean alive;
       
        public EventObject(int w,int h,Vector2 p,String n,Trigger t,String f)
        {
            scriptFile = f;
            pos = p;
            trigger = t;
            this.w = w;
            this.h = h;
            name = n;
            alive = true;
            calculateCollisionBox();
        }

        public EventObject()
        {
            scriptFile = "";
            pos = new Vector2();
            trigger =Trigger.inactive;
            this.w = 0;
            this.h = 0;
            name = "";
            alive = true;
            calculateCollisionBox();
        }

        public Boolean Alive { get { return alive; } set { alive = value; } }

        public void calculateCollisionBox()
        {
            box = new Rectangle((int) ((pos.X/2)+w),(int) ((pos.Y/2)+h),( w/2), (h/2));
        }

        public Rectangle getCollisionBox()
        {
            return (box);
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String ScriptFile
        {
            get { return scriptFile; }
            set { scriptFile = value; }
        }

        public Trigger Triggered
        {
            get { return trigger; }
            set { trigger=value;}
        }

        public int Width
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        public int Height
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }

        public Vector2 Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
                calculateCollisionBox();
            }
        }
    }
}
