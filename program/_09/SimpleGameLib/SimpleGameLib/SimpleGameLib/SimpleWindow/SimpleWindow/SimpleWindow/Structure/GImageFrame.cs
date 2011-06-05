using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public class GImageFrame:GObject
    {
        private String image;
        private bool isVisible;

        public String Image { get { return image; } set { image = value; } }


        public GImageFrame(String name,float x,float y,int width,int height,String image):base(name,x,y,width,height)
        {
            isVisible = true;
            this.image = image;
        }

        public override string ToString()
        {
            return " { " + Name + " - > Image : " + Image + " } ";
        }

        public GImageFrame():base()
        {
            isVisible = true;
            this.image = "";
        }
    }
}
