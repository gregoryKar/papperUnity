


using System;
using System.Linq;
using paper.effects;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{


    [Serializable]
    public class partEffe : partActionBase
    {


        [SerializeReference]
        graphicChange _effe;
        [SerializeField] float _duration;

        //Vector2 startPos;
        public override void cast(bodyPart part, enemy enm)
        {
            if (part is not spriteBodyPart spritePart) return;
            spritePart.getGraphicFather().applyDuration(_effe, _duration);

        }
    }

}