using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWindow.Structure;

namespace SimpleWindow.Controller
{
    public class GController
    {
        private List<GObject> objects;

        public GController()
        {
            objects = new List<GObject>();
        }

        public void add(GObject go)
        {
            objects.Add(go);
        }

        public IEnumerator<GObject> getEnumerator()
        {
            return objects.GetEnumerator();
        }

        public GObject find(String name)
        {
            GObject obj;
            foreach (GObject ob in objects)
            {
                obj = ob.find(name);

                if (obj != null)
                {
                    return obj;
                }
            }

            return (null);
        }

        //The function removes the designated GObject
        public void killThis(String name)
        {
            GObject obj = find(name);

            if (obj != null)
            {
                obj.kill();
            }
        }
    }
}
