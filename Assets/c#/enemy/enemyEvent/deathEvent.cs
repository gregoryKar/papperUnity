



using System;

namespace paper
{

    [Serializable]
    public class deathEvent : enemyEventBase
    {


     
        protected override bool sameTypeInternal(enemyEventBase enmEvent) => enmEvent is deathEvent;



    }



}