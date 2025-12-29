



using System;

namespace utils
{
    //! need to seperate ids ??? like touch id and button id ?? 

    public abstract class myId : IEquatable<myId>
    {




        public abstract idType getIdType();
        public abstract bool containsInt(int number);
        public abstract void killAll();// => invoManager.killAll(this);
        public abstract bool Equals(myId other);
       

        public enum idType
        { simple, none }

    }
}