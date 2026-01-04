using UnityEngine;


namespace utils.math
{


    public static class myRandom
    {


        public static float value01() => UnityEngine.Random.value;
        //UnityEngine.Random.Range (0f, 1f);

        public static float dir(float value) => UnityEngine.Random.Range
        (-value, value);
        public static float dirPercent(float value, int percent) => UnityEngine.Random.Range(-value, value) * (percent / 100f);

        public static int dir(int value) => UnityEngine.Random.Range
      (-value, value);
        public static int dirPercent(int value, int percent) => (UnityEngine.Random.Range
        ((float)-value, value) * (percent / 100f)).round();


        public static Vector2 dir() => myMath.angleToVec(value01() * 360f);


    }


}