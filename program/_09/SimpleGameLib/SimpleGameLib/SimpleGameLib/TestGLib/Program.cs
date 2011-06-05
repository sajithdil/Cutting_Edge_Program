using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameLib;
using SimpleGameLib.PythonScp;
using System.Reflection;
using System.IO;

namespace TestGLib
{
    class Program
    {
        static void Main(string[] args)
        {
            //ScriptKeeper.getInstance().addScript("window_create", "window_create.py");

            ScriptKeeper.getInstance().init("scripts/scripts.xml");

            //System.Console.WriteLine(ScriptKeeper.getInstance().getScript("window_create"));

            WorldsKeeper.getInstance().init("worlds/world_info.xml");

            World world = WorldsKeeper.getInstance().getWorld("room_one");
            world.init();

            Console.WriteLine("The world name : "+world.Name);

            PythonObject.getInstance().register();
            PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript("instruction"));
         // PythonObject.getInstance().getScope().SetVariable(
            //PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript("window_create"));

            P p = new P();
            A a = new A();

            List<P> test = new List<P>();

            test.Add(a);
            test.Add(p);

            foreach (P i in test)
            {
                i.attack();
            }

            Console.ReadLine();
        }
    }
}
