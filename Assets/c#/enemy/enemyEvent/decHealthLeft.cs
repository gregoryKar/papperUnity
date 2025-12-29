


//! dec == damageEventCondition
using System;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class decHealthLeft : damageEventConditionBase
    {

        [SerializeField] int _number;
        [SerializeField] bool _below;
        public override bool conditionsMet(enemy enm , enemyEventBase enmEvent)
        {

            if (_below)
            {
                if (enm._health > _number) return false;
            }
            else //if (_below is false)
            {
                if (enm._health < _number) return false;
            }

            return true;



        }


    }



}