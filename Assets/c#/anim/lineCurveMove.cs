


using System;
using UnityEngine;
using utils;

namespace paper.animation
{

    [Serializable]
    public abstract class lineCurveMove : anim
    {



        public AnimationCurve _curve;
        float _timer;



        public void play(Transform trans)
        {
            //Debug.Log("init anim" );

            // bool state = false;
            // invo.infinite(() =>
            // {
            //     trans.localPosition = _startPos + (state ? _extra : Vector2.zero);

            //     //Debug.Log("change state:" + state);

            //     state = !state;

            // }, _delay);
        }

        public override void play(object target, simpleId id)
        {
            
        }
        public override void loop(object target, simpleId id)
        {
            throw new NotImplementedException();
        }


    }

}