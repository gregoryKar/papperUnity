using UnityEngine;

namespace paper.effects
{
    public class sizeAdd : transformChange
    {

        public float _add;
        public override void applyInternal(Transform trans)
        {

            trans.localScale += new Vector3(_add, _add, 0);

        }

    }

}