




using System;
using UnityEngine;


namespace utils
{

    [Serializable]
    public abstract class shape
    {
        public abstract bool Intersects(shape other, Vector2 posA, Vector2 posB);
        public abstract bool pointInside(Vector2 pos, Vector2 point);


        public abstract bool IntersectsCircle(circle c, Vector2 posA, Vector2 posB);
        public abstract bool IntersectsSquare(square s, Vector2 posA, Vector2 posB);

        public abstract shape cloneMe();


        public abstract Collider2D makeCollider(bool trigger = false);

    }



}