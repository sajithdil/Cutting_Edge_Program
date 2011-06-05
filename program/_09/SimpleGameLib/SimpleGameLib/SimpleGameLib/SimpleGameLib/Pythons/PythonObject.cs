using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.Reflection;
using System.IO;

namespace SimpleGameLib.PythonScp
{
    public class PythonObject
    {
        private static PythonObject instance = new PythonObject();
        ScriptEngine engine;
        ScriptScope scope;
        ScriptRuntime runtime;
        public static PythonObject getInstance()
        {
            return instance;
        }

        public void register()
        {
            engine = Python.CreateEngine();
            scope = null;
            runtime = engine.Runtime;

            scope = runtime.CreateScope();
        }

        public ScriptScope getScope()
        {
            return (scope);
        }

        /// <summary>
        /// The function executes a file
        /// </summary>
        /// <param name="file"></param>
        public void executeF(String file)
        {
            try
            {
                ScriptSource source = engine.CreateScriptSourceFromFile(file);
                source.Execute(scope);
            }
            catch (Exception e)
            {
                Log.getInstance().log("@Folder:Pythons, Class:PythonObject, Log Type: Error, Line No: 51, " + "PythonObject could not execute the file " + file + " " + e.ToString());
            }
        }

        /// <summary>
        /// The function executes a string
        /// </summary>
        /// <param name="source"></param>
        public void executeString(String source)
        {
            try
            {
                ScriptSource s = engine.CreateScriptSourceFromString(source, SourceCodeKind.Statements);
                s.Execute(scope);
            }
            catch(Exception e)
            {
                Log.getInstance().log("@Folder:Pythons, Class:PythonObject, Log Type: Error, Line No: 68, " + "PythonObject could not execute the string " + e.ToString());

            }
        }

        public ScriptRuntime getRuntime()
        {
            return (runtime);
        }
    }
}
