using System;
using UnityEngine;


namespace paper.casting
{


    [Serializable]
    public abstract class castingArea
    {


        public abstract void processPotition(Vector2 pos, out Vector2 finalPosition, out bool acceptable);



    }






}