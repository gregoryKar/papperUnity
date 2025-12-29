


using System;
using paper.animation;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class weapon : partAttribute , ITrans
    {

        Transform _trans;
        public Transform getTrans()=>_trans;

        public override void init(bodyPart part , enemy user)
        {
           _trans = part.transform;
        }

    }

}