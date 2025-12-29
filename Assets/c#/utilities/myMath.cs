





using System;
using Unity.Mathematics;
using UnityEngine;
//using utils.colliders;

namespace utils.math
{


    public static class myMath
    {

        // public static void posSameZ(this Transform trans, Vector2 pos) =>
        //  trans.position = new Vector3(pos.x, pos.y, trans.position.z);



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

        public static float random01() => UnityEngine.Random.value;
        //UnityEngine.Random.Range (0f, 1f);

        public static float randomDir(float value) => UnityEngine.Random.Range
        (-value, value);
        public static float randomDirPercent(float value, int percent) => UnityEngine.Random.Range(-value, value) * (percent / 100f);

        public static int randomDir(int value) => UnityEngine.Random.Range
      (-value, value);
        public static int randomDirPercent(int value, int percent) => (UnityEngine.Random.Range
        ((float)-value, value) * (percent / 100f)).round();

        public static Vector2 angleToVec(float angle)//! from autopilot
        {
            return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
        }

        public static Vector2 randomDir() => angleToVec(random01() * 360f);



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