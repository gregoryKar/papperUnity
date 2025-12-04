


using System;
using utils;

namespace paper.attacks
{



    public abstract class enemyAttack
    {

        public float _cooldown;
        public float _initDelay;
        float _nextAtack;
        public float _attacking;
        public attackResult _result;

        public void beginAttack(enemy user)
        {

            invo.simple(() =>
                        {
                           execute(user);
                        }, _initDelay);

        }
        public abstract void execute(enemy user);

    }




}