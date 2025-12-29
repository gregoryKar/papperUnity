



using System;
using UnityEngine;
using utils;
using utils.math;

namespace paper.effects
{
    [Serializable]
    public class spriteGraphic : graphicBase
    {


        Transform _trans;
        SpriteRenderer _rend;//! DANGEROUS PRACTICE ?? ??


        protected override void takeStartData()
        {

            _trans = _rend.transform;

            _startColor = _rend.color;
            _startSize = _trans.localScale;
            _startRot = _trans.eulerAngles.z;
            _startPos = _trans.vek2Local();



        }
        protected override void resetStartData()
        {
            _rend.color = _startColor;
            _trans.scaleSameZ(_startSize);
            _trans.rotateSet(_startRot);
            _trans.posSameZ(_startPos, local: true);
        }

        public spriteGraphic(SpriteRenderer graphic)
        {
            _rend = graphic;
            _id = new simpleId();
            takeStartData();
        }
        public spriteGraphic(SpriteRenderer graphic, simpleId owner)
        {
            _rend = graphic;
            _id = new dualId(new simpleId(), owner);
            takeStartData();

        }






        public override void setColor(Color col) => _rend.color = col;
        public override void setSize(Vector2 scale) => _trans.scaleSameZ(scale);
        public override void addSize(Vector2 scale) => _trans.scaleAdd(scale);
        public override void setRotation(float rot) => _trans.rotateSet(rot);
        public override void addRotation(float rot) => _trans.rotateAdd(rot);
        public override void addPosition(Vector2 pos) => _trans.position += (Vector3)pos;

    }
}