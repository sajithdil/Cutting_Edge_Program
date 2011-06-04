using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.XML
{
    public class xmlObject
    {
        String name;
        List<StringWrapper> attributes;
        int numOfElements;

        public int Count
        {
            get { return numOfElements; }
        }

        public xmlObject(String value)
        {
            name = value;
            attributes = new List<StringWrapper>();

        }

        public void addAttributes(String property, String value)
        {
            attributes.Add(new StringWrapper(property,value));
            numOfElements++;
        }

        public IEnumerator<StringWrapper> getIter()
        {
            return (attributes.GetEnumerator());
        }

        public String findValueOfProperty(String property)
        {
            IEnumerator<StringWrapper> iter = attributes.GetEnumerator();


            while (iter.MoveNext())
            {
                if (iter.Current.getAttribute() == property)
                {
                    return (iter.Current.getValue());
                }
            }

            return (null);
        }

        public String toText()
        {
            String buffer = "";

            buffer += name + '\n';
            for (int index = 0; index < attributes.Count; index++)
            {
                buffer += "attribute: " + attributes.ElementAt(index).getAttribute ()+ " = > "
                    + attributes.ElementAt(index).getValue() + '\n';
            }

            return (buffer);
        }
    }
}
