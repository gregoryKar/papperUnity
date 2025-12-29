
using UnityEngine;

namespace paper
{


    public interface partKillable
    {
        public void kill(bodyPart part, enemy user);
    }

    public interface partEventListener
    { 
        public void invoke(bodyPart part, enemy user, enemyEventBase type);
    }


}