using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SimpleGameLib.Animations
{
    public class AnimationSequence
    {
        int currentFrame;
        AnimationWrapper handle;
        String alias;
        Boolean playState;
        Vector2 pos;
        private bool killState;



        public AnimationSequence(String alias)
        {
            this.alias = alias;
            playState = true;
            killState = false;
            handle = AnimationAssets.getInstance().findAnimationWrapper(alias);
            pos = new Vector2();
            currentFrame = 0;
        }


        public void play()
        {
            this.playState = true;
        }

        public void isAlarm()
        {
            
        }

        public void kill()
        {
            killState = true;
        }

        public Boolean isKilled()
        {
            return(killState);
        }

        public void stop()
        {
            playState = false;
        }

        public void reset()
        {
            currentFrame = 0;
        }

        public void setPos(Vector2 position)
        {
            this.pos = position;
        }

        public void update()
        {
            //Update only if the animation is playing
            if (playState == true)
            {
                //Check if we should reset
                if ((currentFrame+1) <handle.getMaximum())
                {
                    currentFrame ++;
                }
                else
                {
                    currentFrame=0;
                }
            }
                       
        }

        public void draw(SpriteBatch batch)
        {
            batch.Draw(handle.getFrame(currentFrame),pos,Color.White);
        }
    }
}
