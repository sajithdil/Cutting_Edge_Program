using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SimpleGameLib.XML;
using SimpleGameLib.Scripts;

namespace SimpleGameLib
{
    /// <summary>
    /// The class maintains the scripts in memory and loads all the scripts from a file specified at run time
    /// </summary>
    public class ScriptKeeper
    {
        private Dictionary<String, ScriptData> scripts;
        private static ScriptKeeper instance = new ScriptKeeper();

        public static ScriptKeeper getInstance()
        {
            return instance;
        }

        private ScriptKeeper()
        {
            scripts = new Dictionary<String,ScriptData>();
        }

        /// <summary>
        /// The function gets the script
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public String getScript(String alias)
        {
            try
            {
                return (scripts[alias].Data);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@ ScriptKeeper : Could find the script " + alias + "st " + System.Environment.StackTrace);
                System.Console.WriteLine(e);
                System.Environment.Exit(-1);
                return "";
            }
        }

        /// <summary>
        /// The contents of the script file are loaded as a string
        /// If the script file is not found , it will close the game
        /// </summary>
        /// <param name="alias">The alias of the script</param>
        /// <param name="file">The file name</param>
        public void addScript(ScriptData script)
        {
            try
            {
                //Load the script as a string
                FileStream fs = File.Open(script.File, FileMode.Open, FileAccess.Read);
                TextReader reader = new StreamReader(fs);

                script.Data = reader.ReadToEnd();
                scripts.Add(script.Alias,script);
                reader.Close();
            }
            catch (Exception e)
            {
                Log.getInstance().log("@Script Keeper :The script file " + script.File + "could not be loaded. Exception " + e.ToString());
                System.Console.WriteLine(e);
                System.Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Loads the scripts from a file
        /// </summary>
        /// <param name="source"></param>
        public void init(String source)
        {
           
            Log.getInstance().log("@Scriptkeeper : Starting to load scripts ");
            XMLReader reader = new XMLReader(source);
            reader.process("script");
            reader.getObjectSpace().convert(this.convert);
            Log.getInstance().log("@Scriptkeeper : Finished loading scripts ");
        }

        /// <summary>
        /// The function is used to read the script xml 
        /// </summary>
        /// <param name="objects"></param>
        public void convert(ObjectSpace objects)
        {
            IEnumerator<xmlObject> iter = objects.getIter();
            String temp;
            ScriptData script;

            while (iter.MoveNext())
            {

                script = new ScriptData();

                temp = iter.Current.findValueOfProperty("alias");

                if (temp != null)
                {
                    script.Alias = temp;
                }

                temp = iter.Current.findValueOfProperty("file");

                if (temp != null)
                {
                    script.File = temp;
                }

                //Check if there is a file name and alias
                if ((script.Alias != "") && (script.File != ""))
                {
                    Log.getInstance().log("@ Scriptkeeper : Empty script file missing alias or file ");
                }

                //Load the script
                addScript(script);
            }               
        }
    }
}

