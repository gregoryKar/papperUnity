



using System;

namespace utils
{
    //! need to seperate ids ??? like touch id and button id ?? 

    public class dualId : myId
    {



        simpleId _idUser;
        simpleId _idFather;
        public dualId(simpleId user, simpleId father)
        {
            _idUser = user;
            _idFather = father;
        }
        public simpleId getUser => _idUser;
        public simpleId getFather => _idFather;



        public override void killAll()
        {
            _idUser.killAll();
            //_idFather.killAll();
        }

        public override idType getIdType() => idType.none;



        public override bool containsInt(int number) =>
        _idUser.containsInt(number) || _idFather.containsInt(number);

        public override bool Equals(myId other) =>
        _idUser.Equals(other) || _idFather.Equals(other);



    }
}