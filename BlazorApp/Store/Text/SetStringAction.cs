using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diabete.Stores.CounterStore
{
    public class SetStringAction : IAction
    {
        
        public SetStringAction(string n)
        {
            Text = n;
        }
        public const string INCREMENT = "INCREMENT";
        
        public string Name => INCREMENT;

        public string  Text { get; set; }

    }
}
