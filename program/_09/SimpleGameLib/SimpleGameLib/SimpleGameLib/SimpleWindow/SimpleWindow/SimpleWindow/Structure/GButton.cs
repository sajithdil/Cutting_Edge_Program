using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public class GButton:GObject
    {

        private bool isClicked;

        public Boolean IsClicked { get { return isClicked; } set { isClicked = value; } }

        public GButton(String name,float x,float y,int width,int height):base(name,x,y,width,height)
        {
            isClicked = false;
        }

        public GButton()
            : base()
        {
        }

        public override string ToString()
        {
            return "{ " +base.Name + " } ";
        }
    }
}
