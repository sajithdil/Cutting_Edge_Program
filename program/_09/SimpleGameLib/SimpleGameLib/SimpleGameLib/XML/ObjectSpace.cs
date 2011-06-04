using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.XML
{
    public class ObjectSpace
    {
        List<xmlObject> list;
        int numOfElements;

        public int Count
        {
            get { return numOfElements; }
        }

        public ObjectSpace()
        {
            list = new List<xmlObject>();
            numOfElements = 0;
        }

        public IEnumerator<xmlObject> getIter()
        {
            return (list.GetEnumerator());
        }

        public void addObject(xmlObject ob)
        {
            list.Add(ob);
            numOfElements++;
        }

        public String toText()
        {
            String buffer = "";

            for (int index = 0; index < list.Count; index++)
            {
                buffer += list.ElementAt(index).toText() + '\n';
            }

            return (buffer);
        }


        public void checkRemoveEmpty()
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (list.ElementAt(index).Count <= 1)
                {
                    list.RemoveAt(index);
                    numOfElements--;
                }
            }
        }

        //public void clean()
        //{
        //    list.RemoveRange(0, list.Count);
        //}

        public delegate void converter(ObjectSpace objects);

        public void convert(converter c)
        {
            c(this);
        }
    }
}
