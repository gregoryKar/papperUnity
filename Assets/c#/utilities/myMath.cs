





using System;
using Unity.Mathematics;
using UnityEngine;
//using utils.colliders;

namespace utils.math
{


    public static class myMath
    {


     


        public static void LookAt2D_chatGtp(Transform t, Vector2 targetPos)
        {
            Vector2 dir = targetPos - (Vector2)t.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            t.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        public static void LookAtDir2D_chatGtp(Transform t, Vector2 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            t.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public static void rotate(Transform trans, Vector2 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            trans.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        public static void rotate(Transform trans, float angle)
        {
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            trans.transform.rotation = Quaternion.Euler(0, 0, angle);
        }



        public static Vector2 angleToVec(float angle)//! from autopilot
        {
            return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
        }



        /// <summary>
        /// "MIN IN , MAX OUT"
        /// </summary>
        public static int2 clamp(int2 value, int min, int max)
        {
            value.x = clamp(value.x, min, max);
            value.y = clamp(value.y, min, max);

            return value;
        }
        /// <summary>
        // "MIN IN , MAX OUT"
        /// </summary>
        public static int clamp(int value, int min, int max)
        {
            if (value < min) value = min;
            else if (value >= max) value = max - 1;

            return value;
        }



    }
}