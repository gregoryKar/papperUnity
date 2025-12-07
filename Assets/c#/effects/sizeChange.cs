using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public class sizeAdd : transformChange
    {

        public float _add;
        public override void applyInternal(Transform trans)
        {

            trans.localScale += new Vector3(_add, _add, 0);

        }

    }

}