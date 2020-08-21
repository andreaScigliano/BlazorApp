using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diabete.Stores.CounterStore
{
    public class CounterStore
    {

        private CounterState _state;

        private readonly IActionDispatcher actionDispatcher;

        public CounterStore(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            this.actionDispatcher = actionDispatcher;
            this.actionDispatcher.Subscript(HandleActions);
        }



        public CounterState GetState()
        {
            return _state;
        }
        
        private void HandleActions(IAction action)
        {

            this._state = new CounterState(((SetCountAction)action).Count);
            BroadcastStateChange();

        }
        
       

        //private void increment()
        //{
        //    var count = this._state.Count;
        //    count ++;
        //    this._state = new CounterState(count);
        //    BroadcastStateChange();
        //}

       //public void decrement()
       // {
       //     var count = this._state.Count;
       //     count --;
       //     this._state = new CounterState(count);
       //     BroadcastStateChange();
       // }

        #region observer pattern

        private Action _listeners;

        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        private void BroadcastStateChange()
        {
            _listeners.Invoke();
        }
        #endregion
    }

    public class CounterState
    {
        public int Count { get; set; }

        public CounterState(int count)
        {
            Count = count;
        }
    }
}
