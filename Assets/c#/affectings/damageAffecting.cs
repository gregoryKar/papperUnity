

using System;
using UnityEngine;


namespace paper.affecting
{



    [Serializable]
    public class damageAffecting : affectingBase
    {

        public int amount;

        public override void affect(enemy enm)
        {
            int before = enm._health;
            enm.damage(amount);
            int after = enm._health;

            //Debug.Log(before + " __ " + after);
            // look for damage events .. ..if alive 
        }



    }



}