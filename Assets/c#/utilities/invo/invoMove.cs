
using System;
using UnityEngine;
using utils.math;

namespace utils
{


    //need seperation of with speed and duration
    public class invoMove : invoBase // IComparable<invo>, IEquatable<invo>
    {

        public Action _onEnd;

        Transform _trans;
        float _speed;
        float _duration;
        float _timer;
        Vector2 _startPos, _target;
        bool _local;

        public invoMove(Transform trans, Vector2 target, float speed, Action onEnd, bool local = false) : base(infinite: true)
        {
            _local = local;
            if (_local) _startPos = trans.vek2Local();
            else _startPos = trans.vek2();

            _trans = trans;
            _target = target;

            _speed = speed;
            _duration = (_target - _startPos).magnitude / speed;

            //Debug.Log("DURATION =  : " + _duration);

            _onEnd = onEnd;


        }


        void move()
        {



            _timer += Time.deltaTime;//! _speed; ALREADY ACOUNTED FOR


            //Debug.Log(_timer);

            _trans.posSameZ(Vector2.Lerp(_startPos, _target, _timer / _duration), local: _local);

            if (_timer < _duration) return;

            //Debug.LogError(" TIME t" +  myTime.now);
            //Debug.LogError(" FINISHED t" + _timer + " d " + _duration);

            _killMe = true;
            _trans.posSameZ(_target, local: _local);
            _onEnd?.Invoke();

            // Debug.LogWarning("invo move end " + myTime.now);


        }


        public static void move(Transform trans, Vector2 target, float speed, Action onEnd, bool local = false) => new invoMove(trans, target, speed, onEnd, local: local);
        public static void moveDuration(Transform trans, Vector2 target, float duration, Action onEnd, bool local = false)
        {
            var move = new invoMove(trans, target,
      -1, onEnd, local: local);

            move._duration = duration;

            if (local) move._speed = (target - trans.vek2Local()).magnitude / duration;
            else move._speed = (target - trans.vek2()).magnitude / duration;
            // (target - trans.vek2()).magnitude / duration

        }










        public override void invokeMe(invoBase _me) => move();







    }



}