


using System;
using System.Xml.Serialization;
using UnityEngine;

namespace utils.math
{


    public static class myUnityExtentions
    {

        // public static Vector3 pos(this SpriteRenderer rend) => rend.transform.position;



        public static void cloneTo(this SpriteRenderer clone, SpriteRenderer eidolo)
        {
            //var clone = inst.spritePool.Get();



            clone.transform.position =
            eidolo.transform.position;
            clone.transform.localScale =
           eidolo.transform.lossyScale;

            clone.sprite = eidolo.sprite;
            clone.color = eidolo.color;



        }
        public static void returnMe(this SpriteRenderer rend) { pools.returnMe(rend); }

        public static void posSameZ(this Transform trans, Vector2 pos, bool local = false)
        {
            if (local)
                trans.localPosition = new Vector3(pos.x, pos.y, trans.localPosition.z);
            else
                trans.position = new Vector3(pos.x, pos.y, trans.position.z);
        }

        public static void posSameZ(this Transform trans, float x, float y, bool local = false)
        {

            if (local)
                trans.localPosition = new Vector3(x, y, trans.localPosition.z);
            else
                trans.position = new Vector3(x, y, trans.position.z);
        }

        public static Vector2 vek2(this Transform trans) => trans.position;
        public static Vector2 vek2Local(this Transform trans) => trans.localPosition;

        public static float x(this Transform trans) => trans.position.x;
        public static float y(this Transform trans) => trans.position.y;
        public static float z(this Transform trans) => trans.position.z;


        public static Vector2 right(this Transform trans, float x) => trans.vek2() + Vector2.right * x;
        public static Vector2 left(this Transform trans, float x) => trans.vek2() + Vector2.left * x;



      


    }

}