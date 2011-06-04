using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.KeyBoardModels
{
    /// <summary>
    /// The observable interface allows an observable
    /// </summary>
    public interface Observer
    {
       void notify(Object obj);
    }
}
