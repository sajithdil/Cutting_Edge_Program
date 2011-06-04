using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SimpleGameLib.XML
{
    public class XMLReader
    {
        String fileName;
        XmlTextReader read;
        String contents;
        ObjectSpace objects;


        public XMLReader(String file)
        {
            fileName = file;
            contents = "";
            objects = new ObjectSpace();
            try
            {
                read = new XmlTextReader(file);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        public String getContents()
        {
            contents = objects.toText();
            return (contents);
        }

        public ObjectSpace getObjectSpace()
        {
            return (objects);
        }


        public void process(String token)
        {
            try
            {
                objects = new ObjectSpace();
                read = new XmlTextReader(fileName);
                xmlLoader(read, objects, token);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@XML could not load the file " + fileName + " " + e.ToString());
                System.Environment.Exit(-1);
            }
        }

        public void xmlLoader(XmlTextReader read, ObjectSpace objects,String tag)
        {
            xmlObject obj = new xmlObject("dummy");
            int count = 0;
            String token = tag;
            String name = "";


            while (read.Read())
            {

                //Check if we should reset the object counter
                if (count > 0)
                {
                    objects.addObject(obj);
                    count = 0;
                }

                //Check if it is the start of a new object
                if (read.Name.Equals(token))
                {
                    obj = new xmlObject(token);
                    count++;

                }
                else if (read.NodeType == XmlNodeType.Element)
                {
                    name = read.Name;
                }
                else if (read.NodeType == XmlNodeType.Text)
                {
                    obj.addAttributes(name, read.Value);
                }

            }
            objects.checkRemoveEmpty();
        }
    }
}
