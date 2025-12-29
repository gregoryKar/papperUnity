

using UnityEngine;
using utils;
using utils.math;
namespace paper.attacks
{



    public class meeleAttack : enemyAttack
    {
        Transform _weaponTrans;
        Vector2 _startPos;
        public override void execute(enemy user)
        {

            //gets weapon..
            var weapon = user.getAttribute<weapon>();

            if (weapon == null)
            {
                Debug.LogError("NO WAPON SIR");
                return;
            }

            _weaponTrans = weapon.getTrans();
            _startPos = _weaponTrans.position;// need better 
                                              // maybe get the start pos and rotation from weapon

            attack();


        }

        void attack() { new invoMove(_weaponTrans, _weaponTrans.getLeft(0.5f), 3f, resultAndBack); }
        void resultAndBack()
        {
            _result.sayName();
            new invoMove(_weaponTrans, _startPos, 1f, callAttack);
        }
        void callAttack()
        {
            invo.simple(attack, _cooldown);
        }



    }




}