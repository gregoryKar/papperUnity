


using System;
using UnityEngine;

namespace utils.math
{


    public static class myMathExtentions
    {

        // public static void posSameZ(this Transform trans, Vector2 pos) =>
        //  trans.position = new Vector3(pos.x, pos.y, trans.position.z);

        public static float clamp01(this float value) =>
                value = Math.Clamp(value, 0f, 1f);
        public static float abs(this float value) => Math.Abs(value);
        public static int abs(this int value) => Math.Abs(value);

        public static int round(this float value) => Mathf.RoundToInt(value);


        

    }




}
