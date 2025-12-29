



using System;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class damageEvent : enemyEventBase
    {

        [HideInInspector] public int _damageAmount;

        [SerializeReference] damageEventConditionBase _condition;
        protected override bool triggerInternal(enemy enm, enemyEventBase enmEvent)
        {
            if (_condition == null) return true;
            return _condition.conditionsMet(enm, enmEvent);
        }
        protected override bool sameTypeInternal(enemyEventBase enmEvent) => enmEvent is damageEvent;



    }



}