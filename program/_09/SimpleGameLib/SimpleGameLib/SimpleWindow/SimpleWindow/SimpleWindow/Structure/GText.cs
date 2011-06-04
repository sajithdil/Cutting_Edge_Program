using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWindow.Structure
{
    public class GText:GObject
    {
        private String data;


        public String Data { get { return data; } set { data = value; } }
        public GText(String name,float x,float y,int width,int height,String text):base(name,x,y,width,height)
        {
            this.Text = text;
            this.TextVisible = true;
        }

        
    }
}
