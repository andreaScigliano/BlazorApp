using Diabete.Stores.CounterStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diabete.Stores.StringStore
{
    public class StringStore
    {

        private StringState _state;

        private readonly IActionDispatcher actionDispatcher;

        public StringStore(IActionDispatcher actionDispatcher)
        {
            _state = new StringState("ciao");
            this.actionDispatcher = actionDispatcher;
            this.actionDispatcher.Subscript(HandleActions);
        }



        public StringState GetState()
        {
            return _state;
        }
        
        private void HandleActions(IAction action)
        {

            this._state = new StringState(((SetStringAction)action).Text);
            BroadcastStateChange();

        }
        
       

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

    public class StringState
    {
        public string Text { get; set; }

        public StringState(string text)
        {
            Text = text;
        }
    }
}
