


using System;
using UnityEngine;

namespace paper.motion
{


    //: ITrans
    // public abstract Transform getTrans();

    [Serializable]
    public abstract class motionProjectileBase : motionBase
    {

        //   public abstract motionBase createClone(Transform t);
        public abstract motionBase createShoot(Transform t, Vector2 dir);


    }



}