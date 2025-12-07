


using System;
using UnityEngine;

namespace paper.motion
{





    /*
     THE LOGIC SEPERATES between auto ones and projectile ones
     auto you just give a transofrm they copy the values create 
     a copy of the original that then runs autonomously

     the projectile needs aditional data to start ( DIRECTION )
     thus the seperation of logic 
    */

    [Serializable]
    public abstract class motionBase : IKillable
    {


        //public motionBase() { }
        public void setUp(Transform t)
        {
            test.add(this);
            _canMove = true;
            _trans = t;
        }
        public abstract motionBase createClone(Transform t);

        [HideInInspector] public bool _canMove;
        [HideInInspector] public Transform _trans;

        public abstract void process(float delta);

        public virtual void kill() => test.remove(this);


        //public abstract motionBase create(Transform t);




    }



}