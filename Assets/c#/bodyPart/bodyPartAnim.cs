


using System;
using paper.animation;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class bodyPartAnim : partAttribute 
    {

        [SerializeReference] anim _anim;

      

        public override void init(bodyPart part, enemy user)
        {

            _anim.loop(part, user.getId());

            // if (_anim is stepMove sm)
            // {
            //     sm.play(part.transform);
            // }
        }

    }

}