

using System;

using UnityEngine;
namespace utils
{

    [Serializable]
    public class circle : shape
    {
        public float _radious;

        public circle() { }
        public circle(float radius)=> _radious = radius;
      

        public override shape cloneMe() =>
        new circle(_radious);

        public override bool Intersects(shape other, Vector2 posA, Vector2 posB)
        => other.IntersectsCircle(this, posB, posA);


        public override bool IntersectsCircle(circle c, Vector2 posA, Vector2 posB)
        {
            float dist = Vector2.Distance(posA, posB);
            return dist <= _radious + c._radious;
        }




        public override bool IntersectsSquare(square s, Vector2 posA, Vector2 posB)
        {
            // Circle at posA, Square at posB
            Vector2 half = s._size / 2f;

            Vector2 min = posB - half;
            Vector2 max = posB + half;

            float closestX = Mathf.Clamp(posA.x, min.x, max.x);
            float closestY = Mathf.Clamp(posA.y, min.y, max.y);

            float dist = Vector2.Distance(posA, new Vector2(closestX, closestY));
            return dist <= _radious;
        }


        public override Collider2D makeCollider(bool trigger = false)
        {
            var col = new CircleCollider2D();
            col.radius = _radious;
            col.isTrigger = trigger;
            return col;
        }

        public override bool pointInside(Vector2 pos, Vector2 point) =>
        Vector2.Distance(pos, point) < _radious;



    }
}