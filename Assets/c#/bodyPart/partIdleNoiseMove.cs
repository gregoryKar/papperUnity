


using System;
using paper.animation;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partIdleNoiseMove : partAttribute
    {



        [Tooltip("how far it moves")]
        public float _amplitude = 0.5f;   
        [Tooltip("how fast it changes")]
        public float _4speed = 1f;        

        float _xSeed;
        float _ySeed;



        Vector2 _startPos;
        Transform _trans;
        // float change = Mathf.PerlinNoise(0f, myTime.now * _noiseSpeed);
        // change = (change - 0.5f) * 2f * _noiseAmount;

        public override void init(bodyPart part, enemy user)
        {
            _trans = part.transform;
            _startPos = _trans.localPosition;

            _xSeed = myRandom.value01() * 100f;
            _ySeed = myRandom.value01() * 100f;






            invo.infinite(() =>
            {
                float x = Mathf.PerlinNoise(Time.time * _4speed, _xSeed) - 0.5f;
                float y = Mathf.PerlinNoise(Time.time * _4speed, _ySeed) - 0.5f;

                Vector2 offset = new Vector2(x, y) * _amplitude;
                _trans.localPosition = _startPos + offset;

            }, 0, user.getId());
        }





    }

}