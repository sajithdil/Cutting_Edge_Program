using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SimpleGameLib.ContentWrappers
{
    public class ContentWrapper
    {
        private ContentManager mng;

        private static ContentWrapper instance=new ContentWrapper();

        public static ContentWrapper getInstance()
        {
            return (instance);
        }

        private ContentWrapper()
        {
            mng = null;
        }

        public void setContent(ContentManager c)
        {
            mng = c;
        }

        public ContentManager getContents()
        {
            return (mng);
        }
    }
}
