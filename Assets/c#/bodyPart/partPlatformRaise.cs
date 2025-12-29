


using System;
using paper.animation;
using paper.effects;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partPlatformRaise : partAttribute, partEventListener
    {


        Transform[] _legs;
        public override void init(bodyPart part, enemy user)
        {
            int zigoChildCount = part.transform.childCount;
            if (zigoChildCount % 2 == 1) zigoChildCount--;

            _legs = new Transform[zigoChildCount];

            for (int i = 0; i < zigoChildCount; i++)
            {
                _legs[i] = part.transform.GetChild(i);
            }

            _startY = _legs[0].transform.localPosition.y;

            // Debug.LogError("kid 0 name " + _legs[0].name);

            // invoMove.moveDuration(_legs[0], _legs[0].vek2Local() + Vector2.up, 3, null , local : true);
            // invoRotate.rotateDuration(_legs[0], 25, 3, null);
        }

       
        public float _duration;
        public float _signleHeight;
        public float _angle;
        float _startY;



        [SerializeReference] enemyEventBase _raiseEvent;
        public void invoke(bodyPart part, enemy user, enemyEventBase enmEvent)
        {

            if (_raiseEvent.trigger(user, enmEvent) is false) return;

            Debug.LogError("invoke try in platform");
            //if (_type != type) return;

            //float raise = 1f;
            //float angle = _signleHeight / _legs[0].lossyScale.x;
            //Debug.LogError("angle " + angle);
            float dur = _duration;

            for (int i = 0; i < _legs.Length; i++)
            {
                Debug.LogError("Leg " + i);

                Transform t = _legs[i];
                Vector2 pos = (Vector2)t.localPosition + Vector2.up * _signleHeight * ((i / 2) + 1);
                float tempAngle = i % 2 == 0 ? _angle : -_angle;

                invoMove.moveDuration(t, pos, dur, null, local: true);
                invoRotate.rotateDuration(t, tempAngle, dur, null);
            }
        }
    }

}