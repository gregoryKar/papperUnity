

using System;
using UnityEngine;

namespace paper
{


    [Serializable]
    public class fly : enemyMove
    {

        public float _speed;
        public override void Move(enemy _user)
        {
            _user._trans.position += Vector3.left * _speed * Time.deltaTime;
        }

        // public override enemyAttribute clone() =>
        //      new walk { _speed = this._speed };


    }




}