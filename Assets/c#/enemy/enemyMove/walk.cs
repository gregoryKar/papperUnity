

using System;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class walk : enemyMove, IneedClone
    {
        public float _speed;
        public override void Move(enemy _user)
        {
            _user._trans.position += Vector3.left * _speed * Time.deltaTime;
        }

       

        object IneedClone.clone()
        {
            return new walk
            {
                _speed = this._speed
            };
        }
    }



}