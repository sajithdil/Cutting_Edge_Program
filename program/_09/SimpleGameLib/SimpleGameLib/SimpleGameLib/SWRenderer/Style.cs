using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.XML;


namespace SimpleGameLib.SWRenderer
{
    /// <summary>
    /// The class describes the UI styles
    /// </summary>
    public class Style
    {
        private Dictionary<String, String> skins;

        public Style()
        {
            skins = new Dictionary<String, string>();
        }

        public String getSkin(String type)
        {
            try
            {
                return skins[type];
            }
            catch
            {
                return null;
            }
        }

        public void add(String type, String image)
        {
            skins.Add(type, image);
        }

        public void init(String file)
        {
            Log.getInstance().log("@Style starting to load the file style " + file);
            XMLReader reader = new XMLReader(file);
            reader.process("style");
            reader.getObjectSpace().convert(this.convert);
            Log.getInstance().log("@Style finished loading file style " + file);

        }

        //The function allows the style object to be loaded from a file
        public void convert(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;

            while (iter.MoveNext())
            {

                temp = iter.Current.findValueOfProperty("BUTTON_DOWN");
                if (temp != null)
                {
                    skins.Add("BUTTON_DOWN",temp);
                }

                temp = iter.Current.findValueOfProperty("BUTTON_UP");

                if (temp != null)
                {
                    skins.Add("BUTTON_UP", temp);
                }

            }

        }
    }
}
