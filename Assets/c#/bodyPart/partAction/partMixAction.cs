
using System;
using System.Linq;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class partMixAction : partActionBase
    {


        [SerializeReference] partActionBase[] _actions;
        public override void cast(bodyPart part, enemy enm)
        {
            foreach (var item in _actions)
            {
                item?.cast(part, enm);
            }

        }
    }

}