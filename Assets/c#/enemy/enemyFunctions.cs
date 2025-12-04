
using System;
using UnityEngine;
using System.Collections.Generic;

namespace paper
{

    public partial class enemy
    {



        public T getAttribute<T>() where T : bodyPartAttribute
        {
            foreach (var part in _parts)
            {
                if (part is T tPart) return tPart;
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


    }
}