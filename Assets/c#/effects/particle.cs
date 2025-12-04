
using UnityEngine;
using utils;

namespace paper.effects
{

    public class particle : IRend, ITrans
    {

        Transform _trans;
        SpriteRenderer _rend;

        particeData _data;

        public particle(particeData data, Vector2 pos)
        {
            _data = data;

            _rend = pools.sprite();
            var obj = _rend.gameObject;
            obj.name = "particle " + data.name;

            _trans = obj.transform;
            _trans.localScale = Vector3.one * data._size;
            _rend.sprite = data._sprite;

            _trans.position = pos;

            invo.simple(change, _data._delay);

        }
        int counter;
        void change()
        {

            _data._changes[counter].apply(this);

            counter++;
            if (counter < _data._changes.Length) invo.simple(change, _data._delay);
            else pools.returnMe(_rend);

        }

        public SpriteRenderer getRend() => _rend;
        public Transform getTrans() => _trans;





    }
}

