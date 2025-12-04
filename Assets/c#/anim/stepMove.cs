


using System;
using UnityEngine;
using utils;

namespace paper.animation
{

    [Serializable]
    public class stepMove : anim
    {

        Vector2 _startPos;
        [SerializeField] Vector2 _extra;
        [SerializeField] float _delay;
        public void play(Transform trans)
        {
            //Debug.Log("init anim" );

            bool state = false;
            invo.infinite(() =>
            {
                trans.localPosition = _startPos + (state ? _extra : Vector2.zero);

                //Debug.Log("change state:" + state);

                state = !state;

            }, _delay);
        }


    }

}