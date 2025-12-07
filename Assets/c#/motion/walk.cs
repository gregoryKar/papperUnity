

using System;
using UnityEngine;

namespace paper.motion
{

    [Serializable]
    public class Walk : motionBase
    {

        public float _speed;

        public override motionBase createClone(Transform t)
        {
            var w = new Walk()
            {
                _speed = this._speed
            };
            w.setUp(t);
            return w;
        }


        public override void process(float delta) =>
            _trans.position += Vector3.left * _speed * delta;





    }



}