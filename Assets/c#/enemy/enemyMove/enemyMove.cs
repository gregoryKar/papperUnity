

using System;
using utils.math;

namespace paper
{


    [Serializable]
    public abstract class enemyMove : enemyAttribute
    {

        public bool _canMove = true;

        public abstract void Move(enemy _user);

        public bool isInRange(enemy _user)
        {
            return _user._trans.x() < paperConstants._towerPos;
        }

    }




}