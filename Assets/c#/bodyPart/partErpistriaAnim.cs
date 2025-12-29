


using System;
using System.Linq;
using paper.animation;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partErpistriaAnim : partAttribute, partEventListener
    {






        Transform[] _children;
        float[] _values;
        float _mainValue;
        float _partOffset;
        [SerializeField] float _speed;

        [SerializeField] float _circleTime = 0.2f;
        float _fullTime = 1;
        [SerializeField] float _moveDownTime;
        //float _moveDownTime;
        Transform _circle0;//IS ME NOT
        [SerializeField] Transform _circle1;
        [SerializeField] float _circleRadious;
        float _moveArea;
        float _downY;

        void processParts()
        {

            _mainValue = myTime.now % _fullTime;

            for (int i = 0; i < _values.Length; i++)
            {
                _values[i] = _mainValue + _partOffset * i;
                if (_values[i] > _fullTime) _values[i] = _values[i] % _fullTime;

                processPart(_children[i], _values[i]);
            }


        }
        void processPart(Transform part, float value)
        {

            // px 0-0.2 circle 1
            // 0.2-0.8 middle
            // 0.8 - 1 circle 2
            float value01;
            if (value < _circleTime)
            {
                value01 = value / _circleTime;
                float angle = Mathf.Lerp(90, 0, value01);
                Vector2 dir = myMath.angleToVec(angle);
                part.posSameZ(_circle0.vek2() - dir * _circleRadious);
                part.rotateSet(-angle);

            }
            else if (value < _fullTime - _circleTime)
            {
                value01 = value - _circleTime;
                value01 = value01 / _moveDownTime;
                float pos = Mathf.Lerp(0, _moveArea, value01);
                part.posSameZ(new Vector2(pos, _downY), local: true);

            }
            else
            {
                value01 = value - ((_fullTime - _circleTime) / _circleTime);
                float angle = Mathf.Lerp(0, -90, value01);
                Vector2 dir = myMath.angleToVec(angle);
                part.posSameZ(_circle1.vek2() - dir * _circleRadious);
                part.rotateSet(angle);
            }


        }





        public override void init(bodyPart part, enemy user)
        {
            _children = new Transform[part.transform.childCount];
            _values = new float[part.transform.childCount];

            _fullTime = _moveDownTime + 2 * _circleTime;

            _circle0 = part.transform;

            _moveArea = (_circle0.localPosition.x - _circle1.localPosition.x).abs();
            _downY = part.transform.vek2Local().y - _circleRadious;

            for (int i = 0; i < part.transform.childCount; i++)
            {
                _children[i] = part.transform.GetChild(i);
            }

            _partOffset = _fullTime / _children.Length;

            invo.infinite(processParts, 0, user.getId());


        }

        public void invoke(bodyPart part, enemy user, enemyEventBase enmEvent)
        {
            //throw new NotImplementedException();
        }



    }

}