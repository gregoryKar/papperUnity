



using System;

namespace paper
{

    [Serializable]
    public abstract class enemyCondition
    {


        public enemy _target;
        public abstract void affect(enemy target);

        public abstract void affectAffected(enemy user, enemyCondition preexisting);

        public abstract void remove(enemy target);
        public abstract void proccess(enemy user, out bool killMe);

    }


}