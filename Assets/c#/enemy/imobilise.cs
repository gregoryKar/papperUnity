



using System;
using System.Collections.Generic;
using utils;

namespace paper
{

    [Serializable]
    public class imobilise : enemyCondition
    {


        public bool _inRange;
        List<myId> _imobilisers = new List<myId>();
        myId _tempId;

        public imobilise(myId imobiliser = null) { _tempId = imobiliser; }


        public override void affect(enemy target)
        {
            target._move._canMove = false;
        }

        public override void affectAffected(enemy user, enemyCondition preexistingGeneric)
        {

            var preExisting = (imobilise)preexistingGeneric;

            _inRange = user._move.isInRange(user);

            if (_tempId != null)
            {
                if (preExisting._imobilisers.Contains(_tempId)) return;
                else preExisting._imobilisers.Add(_tempId);
            }
        }
        public void removeImobiliser(myId imobiliser)
        {
            _imobilisers.Remove(imobiliser);
        }

        // public override void proccess(enemy user, out bool killMe)
        // {
        //     user._move._canMove = !_inRange && _imobilisers.Count == 0;
        // }

        public override void remove(enemy target)
        {
            //throw new NotImplementedException();
            target._move._canMove = true;
        }
    }


}