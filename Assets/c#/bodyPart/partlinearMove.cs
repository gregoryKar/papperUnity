


using System;
using paper.animation;
using Unity.Mathematics;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    //! UNDER CONSTRUCTION
    [Serializable]
    public class partLinearMove : partAttribute
    {

        public Vector2 _offset;
        public float _startDelay;
        public float _duration;
        public AnimationCurve _curve;
        //float _timer;
        Vector2 _startPos;
        public override void init(bodyPart part, enemy user)
        {

            _startPos = part.getTrans().localPosition;
            invo.infinite(() =>
            {
                float _timer = myTime.now % _duration;//+= Time.deltaTime;
                
                //if (_timer > _duration) _timer = 0;

                //! HAHAHAHHA TERRIBLE

                part.getTrans().posSameZ(math.lerp(_startPos, _startPos + _offset, _curve.Evaluate(_timer / +_duration)), local: true);



            }, 0f, user.getId(), startDelay: _startDelay);


        }




    }

}