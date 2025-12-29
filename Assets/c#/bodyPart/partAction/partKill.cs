


using System;
using System.Linq;
using UnityEngine;

namespace paper
{


    [Serializable]
    public class partKill : partActionBase
    {

        public override void cast(bodyPart part, enemy enm)
        {
            part.killIndependant();

        }
    }

}