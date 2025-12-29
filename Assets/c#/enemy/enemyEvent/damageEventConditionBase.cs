



using System;

namespace paper
{

    [Serializable]
    public abstract class damageEventConditionBase
    {

        public abstract bool conditionsMet(enemy enm , enemyEventBase enmEvent);


    }



}