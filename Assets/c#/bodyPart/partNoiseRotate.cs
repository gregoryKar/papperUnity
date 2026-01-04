


using System;
using paper.animation;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partNoiseRotate : partAttribute
    {



        [Tooltip("how far it moves")]
        public float _amplitude = 0.5f;
        [Tooltip("how fast it changes")]
        public float _4speed = 1f;

        float _xSeed;




        float _startRot;
        Transform _trans;
        // float change = Mathf.PerlinNoise(0f, myTime.now * _noiseSpeed);
        // change = (change - 0.5f) * 2f * _noiseAmount;

        public override void init(bodyPart part, enemy user)
        {
            _trans = part.transform;
            _startRot = _trans.eulerAngles.z;

            _xSeed = myRandom.value01() * 100f;




            invo.infinite(() =>
            {
                float x = Mathf.PerlinNoise(Time.time * _4speed, _xSeed) - 0.5f;

                float offset = x * _amplitude;
                _trans.eulerAngles = Vector3.forward * (_startRot + offset);

            }, 0, user.getId());
        }





    }

}