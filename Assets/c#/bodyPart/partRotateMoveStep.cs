


using System;
using paper.animation;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partRotateMoveStep : partAttribute
    {



        Vector2 _startPos;
        [SerializeField] Vector2 _extra;
        int _startRotation;
        [SerializeField] int _rotateExtra;

        [SerializeField] float _duration;
        [SerializeField] float _wait;

        public override void init(bodyPart part, enemy user)
        {
            Transform trans = part.getTrans();
            _startPos = trans.localPosition;
            _startRotation = (int)trans.eulerAngles.z;


            bool state = false;

            invoAdvanced.infinite((invaki) =>
           {
               trans.posSameZ(_startPos + (state ? _extra : Vector2.zero), local: true);

               trans.eulerAngles = Vector3.forward * (state ? _rotateExtra : 0);

               state = !state;
               invaki.setDelay(state ? _duration : _wait);

           }, _duration, id: user.getId());
        }



    }

}