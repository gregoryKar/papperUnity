using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public class positionChange : graphicChange
    {

        public Vector2 _add;

        public override void apply(graphicBase graphic)
        => graphic.addPosition(_add);



        // public override void applyInternal(Transform trans) =>
        //     trans.position += (Vector3)_add;

        public override graphicChange duplicate() => new positionChange { _add = _add };

    }

}