using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public abstract class transformChange : graphicChange
    {

        public override void apply(object graphic)
        {
            if (graphic is ITrans t)
                applyInternal(t.getTrans());
        }
        public abstract void applyInternal(Transform t);

       



    }
}