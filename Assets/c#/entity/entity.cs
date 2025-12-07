using System;
using UnityEngine;
using utils;
using utils.colliders;

namespace paper
{
    /* 
    array of attributs [] ??
    or leave this for entityExtended ? ??
    and have projectile and 

    is it even needed to have same parent class ??


   */

    public abstract class entity : MonoBehaviour, IHaveId, IKillable
    {

        myId _id;
        public myId getId() => _id;
        public virtual void itinitialiseId() => _id = new myId();

      

        public abstract void kill();

    }
}