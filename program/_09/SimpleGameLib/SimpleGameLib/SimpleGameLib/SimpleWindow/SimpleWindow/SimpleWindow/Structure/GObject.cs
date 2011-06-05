using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public abstract class GObject
    {
        private int width;
        private int height;

        private bool visible;
        private bool alive;

        
        private GObject owner;
        private String name;

        //Absolute position of the component
        private float absX;
        private float absY;

        private String text;
        private Boolean textVisible;



        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }
        public bool Visible { get { return visible; } set { visible = value; } }
        public bool Alive { get { return alive; } set { alive = value; } }
        public float X { get { return absX; } set { absX = value; } }
        public float Y { get { return absY; } set { absY = value; } }
        public GObject Owner { get { return owner; } set { owner = value; } }
        public String Name { get { return name; } set { name = value; } }
        public Boolean TextVisible { get { return textVisible; } set { textVisible = value; } }
        public String Text { get { return text; } set { text = value; } }
       

        private List<GObject> objects;

        //The various events
        private UserEvents onClick;
        private UserEvents onMouseOver;

        public UserEvents OnClick { get { return onClick; } set { onClick = value; } }
        public UserEvents OnMouseOver { get { return onMouseOver; } set { onMouseOver = value; } }

        public GObject(String nv,float xv,float yv,int wv,int hv)
        {
            name = nv;
            absX = xv;
            absY = yv;
            width = wv;
            height = hv;
            objects =new  List<GObject>();
            owner = null;
            onClick = null;
            onMouseOver = null;
            textVisible = false;
        }

        public GObject()
        {
            name = "";
            absX = -1;
            absY = -1;
            width = -1;
            height = -1;
            objects = new List<GObject>();
            owner = null;
            onClick = null;
            onMouseOver = null;
            textVisible = false;
        }
      
        //The function adds a GObject component
        public void register(GObject obj)
        {
            obj.Owner = this;
            obj.X = this.X + obj.X;
            obj.Y = this.Y + obj.Y;
            objects.Add(obj);
        }

        //The function kills all GObjects stored inside as well as itself
        public void kill()
        {
            for (int index = 0; index < objects.Count; index++)
            {
                objects.ElementAt(index).kill();
            }
            
            //Mark as not alive
            alive = false;
        }

        //The function sets the visibility
        public void setVisibility(Boolean state)
        {
            visible = state;

            foreach (GObject obj in objects)
            {
                obj.setVisibility(state);
            }
        }

        //The function finds a given GObject inside the GObject
        public GObject find(String name)
        {
            if (Name == name)
            {
                return (this);
            }

            GObject found;
            //Check the objects
            foreach (GObject obj in objects)
            {
                found=find(name);
                if (found != null)
                {
                    return(found);
                }
            }

            return(null);
        }

        //The function returns all objects owned by the GObject
        public List<GObject> getAllObjectsOwned(List<GObject> possesions)
        {
           

            if (objects.Count == 0)
            {
                possesions.Add(this);
                return (possesions);
            }
            else
            {

                foreach (GObject g in objects)
                {
                    possesions=g.getAllObjectsOwned(possesions);
                }

                return (possesions);
            }
        }

        /// <summary>
        /// The function  indicates whether an object owns other objects
        /// </summary>
        /// <returns></returns>
        public Boolean isOwner()
        {
            if (objects.Count == 0)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            String buffer = ""+Name+" < ";

            foreach (GObject ob in objects)
            {
                buffer += ob.ToString();
            }

            return buffer+ " > ";
        }

    }
}
