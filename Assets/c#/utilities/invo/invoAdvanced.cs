
using System;


namespace utils
{
    public class invoAdvanced : invoBase
    {


        public Action<invoAdvanced> _action;

        private invoAdvanced(Action<invoAdvanced> action, float delay, int repeatsLeft, myId id= null) : base(delay, repeatsLeft, id: id) => _action = action;


        public static void simple(Action<invoAdvanced> action, float delay, myId id= null) => new invoAdvanced(action, delay, 0, id: id);
        public static void repeat(Action<invoAdvanced> action, float delay, int repeat, myId id= null) => new invoAdvanced(action, delay, repeat, id: id);

        public static void infinite(Action<invoAdvanced> action, float delay, myId id= null) => new invoAdvanced(action, delay, -1, id: id);


        public override void invokeMe(invoBase _me) => _action.Invoke((invoAdvanced)_me);





    }
}
