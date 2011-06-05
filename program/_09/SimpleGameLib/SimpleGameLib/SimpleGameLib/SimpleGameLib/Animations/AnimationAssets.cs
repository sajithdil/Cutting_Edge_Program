using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Animations
{
    public class AnimationAssets
    {
        List<AnimationWrapper> list;

        static AnimationAssets instance = new AnimationAssets();

        private AnimationAssets()
        {
            list = new List<AnimationWrapper>();
        }

        public static AnimationAssets getInstance()
        {
            return (instance);
        }


        public void addAsset(AnimationWrapper wrapper)
        {
            list.Add(wrapper);
        }

        public AnimationWrapper findAnimationWrapper(String alias)
        {
            IEnumerator<AnimationWrapper> iter = list.GetEnumerator();

            while (iter.MoveNext())
            {
                if (iter.Current.getAlias() == alias)
                {
                    return (iter.Current);
                }
            }

            return (null);
        }

       
    }
}
