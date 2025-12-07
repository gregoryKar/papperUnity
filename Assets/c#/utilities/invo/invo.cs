
using System;


namespace utils
{



    public class invo : invoBase // IComparable<invo>, IEquatable<invo>
    {

        public Action _action;

        private invo(Action action, float delay, int repeatsLeft, bool infinite = false, myId id = null) : base(delay: delay, repeats: repeatsLeft, infinite: infinite, id: id) { _action = action; }



        public static void simple(Action action, float delay, myId id = null) => new invo(action, delay, 0, id: id);
        public static void repeat(Action action, float delay, int repeat, myId id= null) => new invo(action, delay, repeat, id: id);

        public static invo infinite(Action action, float delay, myId id= null) =>
        new invo(action, delay, 0, infinite: true, id: id);


        public override void invokeMe(invoBase _me) => _action.Invoke();


        // public int CompareTo(invo other) return _endTime.CompareTo(other._endTime);
        // public bool Equals(invo other) return this == other;




    }



}