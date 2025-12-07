

using UnityEngine;
using System;
namespace utils
{
    [Serializable]
    public class square : shape
    {
        public Vector2 _size;

        public square() { }
        public square(Vector2 size) => _size = size;


        public override shape cloneMe() =>
      new square(_size);

        public override bool Intersects(shape other, Vector2 posA, Vector2 posB) => other.IntersectsSquare(this, posB, posA);


        public override bool IntersectsCircle(circle c, Vector2 posA, Vector2 posB)
        {
            // Let Circle handle it for consistency
            return c.IntersectsSquare(this, posB, posA);
        }

        public override bool IntersectsSquare(square s, Vector2 posA, Vector2 posB)
        {
            Vector2 halfA = _size / 2f;
            Vector2 halfB = s._size / 2f;

            bool overlapX = Mathf.Abs(posA.x - posB.x) <= (halfA.x + halfB.x);
            bool overlapY = Mathf.Abs(posA.y - posB.y) <= (halfA.y + halfB.y);

            return overlapX && overlapY;
        }

        public override Collider2D makeCollider(bool trigger = false)
        {
            var col = new BoxCollider2D();
            col.size = _size;
            col.isTrigger = trigger;
            return col;
        }



        public override bool pointInside(Vector2 pos, Vector2 point)
        {

            if (pos.x - _size.x / 2f > point.x) return false;
            if (pos.x + _size.x / 2f < point.x) return false;

            if (pos.y - _size.y / 2f > point.y) return false;
            if (pos.y + _size.y / 2f < point.y) return false;

            return true;

        }
    }
}