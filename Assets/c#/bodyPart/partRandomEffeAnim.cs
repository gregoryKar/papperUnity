


using System;
using System.Linq;
using paper.animation;
using paper.effects;
using Sirenix.OdinInspector;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partRandomEffeAnim : partAttribute
    {


        [SerializeReference] effectBase[] _effects;
        bodyPart _partHolder;

        public override void init(bodyPart part, enemy user)
        {


            _partHolder = part;
            testMe();


        }

        [Button]
        void testMe()
        {
            
                foreach (var item in _effects)
                {
                    item.cast(_partHolder);
                }

            
        }
    }
}