using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.KeyBoardModels
{
    public class Observerable
    {
        private List<Observer> obs;
        private Object matter;

        public Observerable()
        {
            obs = new List<Observer>();
            matter = null;
        }

        /// <summary>
        /// The function adds an observer 
        /// </summary>
        /// <param name="obser"></param>
        public void addObserver(Observer obser)
        {
            obs.Add(obser);
        }

        /// <summary>
        /// The subject to be transmitted
        /// </summary>
        /// <param name="obj"></param>
        public void setMatter(Object obj)
        {
            matter = obj;
        }

        /// <summary>
        /// The function notifies all observers about the changes
        /// </summary>
        public void notifyAll()
        {
            for (int i = 0; i < obs.Count; i++)
            {
                obs.ElementAt(i).notify(matter);
            }
        }
    }
}
