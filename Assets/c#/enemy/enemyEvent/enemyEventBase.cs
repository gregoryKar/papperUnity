



using System;
using NUnit.Framework;

namespace paper
{

    [Serializable]
    public abstract class enemyEventBase
    {


        public bool trigger(enemy enm, enemyEventBase enmEvent) =>
            sameTypeInternal(enmEvent) && triggerInternal(enm, enmEvent);

        protected virtual bool triggerInternal(enemy enm, enemyEventBase enmEvent) => true;

        protected abstract bool sameTypeInternal(enemyEventBase enmEvent);



    }



}