
using System;
using System.Linq;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class partDisableAction : partActionBase
    {



        public override void cast(bodyPart part, enemy enm)
        {
            part.gameObject.SetActive(false);

        }
    }

}