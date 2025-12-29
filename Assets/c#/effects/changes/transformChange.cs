using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public abstract class transformChange : graphicChange
    {

        // public override void apply(object graphic)
        // {
        //     //Debug.Log("transformChange cast");
        //     if (graphic is ITrans t)
        //         applyInternal(t.getTrans());
        //     else   Debug.LogError("transformChange NO TRANS");
        // }

        // public override void reverse(object graphic)
        // {
        //     if (graphic is ITrans t)
        //         reverseInternal(t.getTrans());
        // }


        public abstract void applyInternal(Transform t);
        public abstract void reverseInternal(Transform t);










    }
}