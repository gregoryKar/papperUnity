
using System;
using UnityEngine;
using utils.math;

namespace utils
{


    //need seperation of with speed and duration
    public class invoRotate : invoBase // IComparable<invo>, IEquatable<invo>
    {

        public Action _onEnd;

        Transform _trans;
        float _speed;
        float _duration;
        float _timer;
        float _startRot, _target;
        //bool _local;//, bool local = false

        public invoRotate(Transform trans, float target, float speed, Action onEnd) : base(infinite: true)
        {
            //_local = local;
            //if (_local) _startPos = trans.eulerAngles.
            //else _startPos = trans.vek2();

            _startRot = trans.eulerAngles.z;

            _trans = trans;
            _target = target;

            _speed = speed;
            _duration = (_target - _startRot).abs() / speed;

            //Debug.Log("DURATION =  : " + _duration);

            _onEnd = onEnd;


        }


        void move()
        {



            _timer += Time.deltaTime;//! _speed; ALREADY ACOUNTED FOR


            //Debug.Log(_timer);

            // _trans.posSameZ(Vector2.Lerp(_startRot, _target, _timer / _duration), local: _local);
            _trans.rotateSet(Mathf.Lerp(_startRot, _target, _timer / _duration));

            if (_timer < _duration) return;

            //Debug.LogError(" TIME t" +  myTime.now);
            //Debug.LogError(" FINISHED t" + _timer + " d " + _duration);

            _killMe = true;
            _trans.rotateSet(_target);
            _onEnd?.Invoke();

            // Debug.LogWarning("invo move end " + myTime.now);


        }


        public static void rotate(Transform trans, float target, float speed, Action onEnd) => new invoRotate(trans, target, speed, onEnd);
        public static void rotateDuration(Transform trans, float target, float duration, Action onEnd) => new invoRotate(trans, target,
       (target - trans.eulerAngles.z).abs() / duration, onEnd);









        public override void invokeMe(invoBase _me) => move();







    }



}