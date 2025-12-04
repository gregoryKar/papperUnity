
using System;


namespace utils
{



    public class invo : invoBase // IComparable<invo>, IEquatable<invo>
    {

        public Action _action;

        private invo(Action action, float delay, int repeatsLeft, bool infinite = false) : base(delay: delay, repeats: repeatsLeft , infinite : infinite) { _action = action;  }



        public static void simple(Action action, float delay) => new invo(action, delay, 0);
        public static void repeat(Action action, float delay, int repeat) => new invo(action, delay, repeat);

        public static invo infinite(Action action, float delay) =>
        new invo(action, delay, 0, infinite: true);


        public override void invokeMe(invoBase _me) => _action.Invoke();


        // public int CompareTo(invo other) return _endTime.CompareTo(other._endTime);
        // public bool Equals(invo other) return this == other;




    }



}