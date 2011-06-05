using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public class GFrame:GObject
    {
        private String background;

        public String Background { get { return background; } set { background = value; } }
        public GFrame(String name,float x,float y,int width,int height):base(name,x,y,width,height)
        {

        }

        public GFrame():base()
        {

        }
    }
}
