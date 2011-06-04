using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace SimpleGameLib.Asset
{
    /// <summary>
    /// The class allows access to the assets
    /// </summary>
    public class Assets
    {

        private List<AssetWrapper> list;
        private static Assets instance = new Assets();

        public static Assets getInstance()
        {
            return (instance);
        }

        private Assets()
        {
            list = new List<AssetWrapper>();
        }

        /// <summary>
        /// The function locates an asset
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public AssetWrapper get(String alias)
        {
            IEnumerator<AssetWrapper> iter = list.GetEnumerator();

            while (iter.MoveNext())
            {
                if (iter.Current.Alias.Equals(alias))
                {
                    return (iter.Current);
                }
            }

            Log.getInstance().log("@Assets could not locate the asset " + alias + " st " + System.Environment.StackTrace);

            return (null);
        }

        public void add(String alias)
        {
            list.Add(new AssetWrapper(alias));
        }

        /// <summary>
        /// The function loads the assets
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public List<AssetWrapper> getAssets(List<String> asset)
        {
            List<AssetWrapper> buf = new List<AssetWrapper>();
            AssetWrapper temp;
            for (int index = 0; index < asset.Count; index++)
            {
                temp=get(asset.ElementAt(index));
                if(temp!=null)
                {
                    buf.Add(temp);
                }
               
            }

            return(buf);
        }
    }
}
