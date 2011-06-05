using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.XML
{
    public class StringWrapper
    {
        String value;
        String property;

        public StringWrapper(String prop,String data)
        {
            value = data;
            property = prop;

        }

        public String getValue()
        {
            return (value);
        }

        public String getAttribute()
        {
            return (property);
        }
    }
}
