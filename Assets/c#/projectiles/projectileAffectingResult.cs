


using System;
using paper.affecting;
using UnityEngine;

namespace paper.projectiles
{

    [Serializable]
    public class projectileAffectingResult : projectileResult
    {


        [SerializeReference]
        public affectingBase _affecting;
        public override void cast(enemy enm)
        {
            _affecting?.affect(enm);
        }



    }





}