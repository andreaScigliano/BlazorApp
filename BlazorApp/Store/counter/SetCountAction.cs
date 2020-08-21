using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diabete.Stores.CounterStore
{
    public class SetCountAction : IAction
    {
        
        public SetCountAction(int n)
        {
            Count = n;
        }
        public const string INCREMENT = "INCREMENT";
        
        public string Name => INCREMENT;

        public int  Count { get; set; }

    }
}
