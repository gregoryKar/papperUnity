



using System;

namespace utils
{
    //! need to seperate ids ??? like touch id and button id ?? 

    public class myId : IEquatable<myId> , IEquatable<int>
    {

        //enum idType { basic, touch, button }
        // idType _type;
        static int idCounter;
        int _idForbidden;

        public int _id
        {
            get { return _idForbidden; }
            private set { _idForbidden = value; }
        }
        public myId()
        {
            idCounter++;
            if (idCounter > 9999) idCounter = 0;
            _id = idCounter;
        }

        public bool Equals(myId other) => _id == other._id;
        public bool Equals(int number) => _id == number;

    }
}