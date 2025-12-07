

using System;
using UnityEngine;
namespace paper.motion
{

    [Serializable]
    public class projectileMotion : motionProjectileBase
    {



        public float _StartSpeed;
        public Vector2 _velocity;
        public bool _drag, _gravity, _lookAtDirecion;
        public float _dragAmount, _gravityAmount;


        // public projectileMotion(){}
        // public projectileMotion(Transform t) : base(t) { }
        public override motionBase createClone(Transform t) => null;




        public override motionBase createShoot(Transform t, Vector2 dir)
        {
            var p = new projectileMotion()
            {
                _drag = this._drag,
                _gravity = this._gravity,
                _lookAtDirecion = this._lookAtDirecion,
                _dragAmount = this._dragAmount,
                _gravityAmount = this._gravityAmount,

                _StartSpeed = this._StartSpeed,
                _velocity = dir * this._StartSpeed,
            };
            p.setUp(t);
            return p;
        }

        //public override void kill() { base.kill(); }


        public override void process(float delta)
        {
            if (_drag)
            {
                _velocity -= _velocity * _dragAmount * delta;
            }
            if (_gravity)
            {
                _velocity.y -= _gravityAmount * delta;
            }

            _trans.position += (Vector3)_velocity * delta;

            if (_lookAtDirecion)
            {
                float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
                _trans.rotation = Quaternion.Euler(0, 0, angle);
            }




        }









    }
}