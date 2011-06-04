using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleGameLib.Animations
{
    public class AnimationSpace
    {
        List<AnimationSequence> list;

        private static AnimationSpace instance = new AnimationSpace();
        int timer;

        private AnimationSpace()
        {
            list = new List<AnimationSequence>();
            timer = 0;
        }

        public static AnimationSpace getInstance()
        {
            return (instance); ;
        }

        public void updateTimer()
        {
            timer++;
            if (timer >= 1000)
            {
                timer = 0;
            }
        }

        public Boolean isTime()
        {
            if (timer % 5 == 0)
            {
                return (true);
            }

            return (false);
        }

        public void update()
        {
            updateTimer();

            //Only do updates 50 times a second
            if (isTime())
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list.ElementAt(index).isKilled())
                    {
                        list.RemoveAt(index);
                        //Log.getInstance().log("@AnimationSpace REMOVING ANIMATION...");
                    }
                    else
                    {
                        list.ElementAt(index).update();
                    }
                }
            }
        }

        public void draw(SpriteBatch batch)
        {
            for (int index = 0; index < list.Count; index++)
            {
                list.ElementAt(index).draw(batch);
            }

        }

        public void addAnimation(AnimationSequence animation)
        {
            list.Add(animation);
        }
    }
}
