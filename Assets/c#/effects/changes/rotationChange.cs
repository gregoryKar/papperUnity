using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public class rotationChange : graphicChange
    {

     
        public float _add;

        public override void apply(graphicBase graphic)
        => graphic.setRotation(_add);



        // public override void applyInternal(Transform trans) =>
        //     trans.position += (Vector3)_add;

        public override graphicChange duplicate() => new rotationChange { _add = _add };

    }

}