

using UnityEngine;
using utils;
using utils.math;
namespace paper.attacks
{



    public class meeleAttack : enemyAttack
    {

        public override void execute(enemy user)
        {

            //gets weapon..
            var weapon = user.getAttribute<weapon>().getTrans();
            Vector2 startPos = weapon.position;

            void go() { }


            new invoMove(weapon, weapon.left(0.5f), 3f, attackAndBack);

            void attackAndBack()
            {
                _result.sayName();
                new invoMove(weapon, startPos, 1f , null);

            }


        }


    }




}