


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
    public class motionMixer : motionBase
    {


        //! CHANGING THE CAN MOVE BOOL HAVE NO DIFFERENCE IN THIS ONE CAUSE 
        //! IT JUST INTERACTS WITH THE ORHTERS IN INIT OR IN KILL SO
        //! IF YOU NEED SOMETHING EXTRA LIKE IMOBILESE THAT HERE YOU WILL SET EXTRA CODE !! !!

        [SerializeReference]
        public motionBase[] _motions;
        public override motionBase createClone(Transform t)
        {

            var m = new motionMixer();
            m._motions = new motionBase[_motions.Length];


            for (int i = 0; i < _motions.Length; i++)
            {
                m._motions[i] = _motions[i].createClone(t);
            }

            return m;
        }




        public override void process(float delta)
        {
            for (int i = 0; i < _motions.Length; i++)
            {
                _motions[i].process(delta);
            }

        }

        public override void kill()
        {
            for (int i = 0; i < _motions.Length; i++)
            {
                test.remove(_motions[i]);
            }
        }



        //public abstract motionBase create(Transform t);




    }



}