
using System;
using UnityEngine;
using System.Collections.Generic;
using utils.math;

namespace paper
{

    public partial class enemy
    {



        public T getAttribute<T>() where T : partAttribute
        {
            foreach (var part in _parts)
            {
                foreach (var item in part._attributes)
                {
                    if (item is T tPart) return tPart;
                }
                //if (part is T tPart) return tPart;
            }

            return null;
        }

        public void castCondition(enemyCondition condition)
        {

            //check if condition already exists


            foreach (var cond in _conditions)
            {
                if (cond.GetType() == condition.GetType())
                {
                    cond.affectAffected(this, condition);
                    return;
                }

            }

            condition.affect(this);
            _conditions.Add(condition);

        }

        public void processConditon(enemyCondition condition)
        {
            condition.proccess(this, out bool killMe);
            if (killMe)
            {
                condition.remove(this);
                _conditions.Remove(condition);
            }
        }

        public bool inRange => _trans.x() < paperConstants._towerPos;
        public bool isAlive => _health > 0;

        public int healthPercent => (100f * _health / _maxHealth).round();

    }
}