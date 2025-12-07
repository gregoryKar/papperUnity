





using System;
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



    }




}