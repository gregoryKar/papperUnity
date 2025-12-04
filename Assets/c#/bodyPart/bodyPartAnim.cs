


using System;
using paper.animation;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class bodyPartAnim : bodyPartAttribute
    {

        [SerializeReference] anim _anim;
        public override void init(bodyPart part, enemy user)
        {
            if (_anim is stepMove sm)
            {
                sm.play(part.transform);
            }
        }

    }

}