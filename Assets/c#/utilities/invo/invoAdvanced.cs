
using System;


namespace utils
{
    public class invoAdvanced : invoBase
    {


        public Action<invoAdvanced> _action;

        private invoAdvanced(Action<invoAdvanced> action, float delay, int repeatsLeft) : base(delay, repeatsLeft) => _action = action;


        public static void simple(Action<invoAdvanced> action, float delay) => new invoAdvanced(action, delay, 0);
        public static void repeat(Action<invoAdvanced> action, float delay, int repeat) => new invoAdvanced(action, delay, repeat);

        public static void infinite(Action<invoAdvanced> action, float delay, int repeat) => new invoAdvanced(action, delay, -1);


        public override void invokeMe(invoBase _me) => _action.Invoke((invoAdvanced)_me);





    }
}
