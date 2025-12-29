



using System;
using UnityEngine;

namespace utils
{
    //! need to seperate ids ??? like touch id and button id ?? 

    public class simpleId : myId //: IEquatable<myId>, IEquatable<int>
    {


        static int idCounter;
        int _idForbidden;
        public int _id
        {
            get { return _idForbidden; }
            private set { _idForbidden = value; }
        }
        public simpleId()
        {
            idCounter++;
            if (idCounter > 9999) idCounter = 0;
            _id = idCounter;
        }



        public override void killAll() => invoManager.killAll(this);    

        public override idType getIdType() => idType.simple;




        public override bool containsInt(int number) => _id == number;
       

        public override bool Equals(myId other)
        {
            if (other.containsInt(_id) is false) return false;

            if (other is simpleId) return getIdType() == other.getIdType();
            else if (other is dualId dual) return dual.Equals(this);
            else
            {

                Debug.LogError("TYPE A = " + getIdType() + " B = " + other.getIdType());
                throw new NotImplementedException("ID EQUATION CASE");
            }

        }

    }
}