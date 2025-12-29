using System;
using UnityEngine;


namespace paper.casting
{


    [Serializable]
    public class castingVericalLineArea : castingArea
    {


        [SerializeField] Vector2 _size;

        public override void processPotition(Vector2 pos, out Vector2 finalPosition, out bool acceptable)
        {
            acceptable = true;
            finalPosition = new Vector2(pos.x, 0);

        }



    }






}