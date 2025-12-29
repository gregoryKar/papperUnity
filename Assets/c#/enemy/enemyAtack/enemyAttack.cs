


using System;
using UnityEngine;
using utils;

namespace paper.attacks
{


    [Serializable]
    public abstract class enemyAttack
    {

        public float _cooldown;
        public float _initDelay;


        [SerializeReference]
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