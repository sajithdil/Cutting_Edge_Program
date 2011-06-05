using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib.XML;
using SimpleGameLib.Asset;

namespace SimpleGameLib.AssetKeeper
{
    /// <summary>
    /// The class is used to store the assets
    /// </summary>
    public class AssetsKeeper
    {

        private List<String> assets;

        public AssetsKeeper()
        {
            assets = new List<string>();
        }

        /// <summary>
        /// The function loads the assets
        /// </summary>
        /// <param name="source"></param>
        public void init(String source)
        {
            Log.getInstance().log("@Folder:AssetKeeper, Class:AssetsKeeper, Log Type: Program Run Log, Line No: 29, " + "AssetsKeeper " + this.ToString() + " loading the assets from : " + source);

            try
            {
                XMLReader reader = new XMLReader(source);
                reader.process("assets");
                reader.getObjectSpace().convert(this.convert);

                //Add to the asset systems
                for (int i = 0; i < assets.Count; i++)
                {
                    Assets.getInstance().add(assets.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Log.getInstance().log("@Folder:AssetKeeper, Class:AssetKeeper, Log Type: Error, Line No: 45, " + "AssetsKeeper could not load the assets " + e.ToString());
                System.Environment.Exit(-1);
                System.Console.WriteLine(e);               
            }

            Log.getInstance().log("@Folder:AssetKeeper, Class:AssetKeeper, Log Type: Program Run Log, Line No: 50, " + "AssetsKeeper finished loading the assets from " + source);
        }


        public void convert(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;


            while (iter.MoveNext())
            {
               
                temp = iter.Current.findValueOfProperty("name");

                if (temp != null)
                {
                    assets.Add(temp);
                }
            }
        }

        public void destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
