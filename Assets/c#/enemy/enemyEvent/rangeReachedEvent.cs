



using System;

namespace paper
{

    [Serializable]
    public class rangeReachedEvent : enemyEventBase
    {

        protected override bool sameTypeInternal(enemyEventBase enmEvent) => enmEvent is rangeReachedEvent;


    }



}