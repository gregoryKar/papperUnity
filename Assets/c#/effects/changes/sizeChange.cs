using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public class sizeAdd : graphicChange
    {



        public float _add;

        public override void apply(graphicBase graphic)
        => graphic.addSize(Vector2.one * _add);



        public override graphicChange duplicate() => new rotationChange { _add = _add };

    }

}