


//! dec == damageEventCondition
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class decCombine : damageEventConditionBase
    {

        [SerializeReference]
        damageEventConditionBase[] _conditions;
        [SerializeField] bool _AND;
        public override bool conditionsMet(enemy enm, enemyEventBase enmEvent)
        {

            int trueCount = 0;
            foreach (var item in _conditions)
            {
                if (item.conditionsMet(enm, enmEvent)) trueCount++;
            }

            if (_AND) return trueCount == _conditions.Length;
            else return trueCount > 1;



        }


    }



}