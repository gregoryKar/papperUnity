using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public abstract class spriteChange : graphicChange
    {

        public override void apply(object graphic)
        {
            if (graphic is IRend r)
                applyInternal(r);
        }

        public abstract void applyInternal(IRend rend);
    }
}