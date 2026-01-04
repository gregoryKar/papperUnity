


using System;
using System.Xml.Serialization;
using UnityEngine;

namespace utils.math
{


    public static class myUnityExtentions
    {

        // public static Vector3 pos(this SpriteRenderer rend) => rend.transform.position;


        #region TRANSFORM RELATED

        public static void rotateSet(this Transform trans, float rot)
        {
            Vector3 holder = trans.eulerAngles;
            holder.z = rot;
            trans.eulerAngles = holder;
        }
        public static void rotateAdd(this Transform trans, float rot)
        {
            Vector3 holder = trans.eulerAngles;
            holder.z += rot;
            trans.eulerAngles = holder;
        }
        public static float rotateGet(this Transform trans) => trans.eulerAngles.z;






        public static void posSameZ(this Transform trans, Vector2 pos, bool local = false)
        {
            if (local)
                trans.localPosition = new Vector3(pos.x, pos.y, trans.localPosition.z);
            else
                trans.position = new Vector3(pos.x, pos.y, trans.position.z);
        }

        public static void scaleSameZ(this Transform trans, Vector2 pos)
        {
            trans.localScale = new Vector3(pos.x, pos.y, trans.localPosition.z);
        }
        public static void scaleAdd(this Transform trans, Vector2 scale) =>
            trans.localScale += (Vector3)scale;


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


        public static Vector2 getRight(this Transform trans, float x) => trans.vek2() + Vector2.right * x;
        public static Vector2 getLeft(this Transform trans, float x) => trans.vek2() + Vector2.left * x;
        public static Vector2 getUp(this Transform trans, float x) => trans.vek2() + Vector2.up * x;
        public static Vector2 getDown(this Transform trans, float x) => trans.vek2() + Vector2.up * -x;

        public static Vector2 goUp(this Transform trans, float x) => trans.position += trans.up * x;



        #endregion



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




        public static void changeA(this SpriteRenderer rend, float a) =>
         rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, a);


        /// <summary>
        /// used in duration and returns 0 1 value to use 
        /// </summary>
        public static float syncedValue01(this float duration)
        => (myTime.now % duration) / duration;
        public static float syncedValue(this float duration)
        => myTime.now % duration;



    }

}