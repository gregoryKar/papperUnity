
using UnityEngine;
using System;

namespace utils.colliders
{

    public static class colliderMath
    {
        // public static bool circleBoxHit(myBox box, myCircle circle)
        //        => circleBoxHit(box.pos, box._size, circle.pos, circle._radious);

        //AI GENERATED
        static bool circleBoxHit(
            Vector2 boxPos, Vector2 boxSize, Vector2 circlePos, float r)
        {
            Vector2 boxHalfSize = boxSize / 2f;
            // Find the closest point on the rectangle to the circle
            float closestX = MathF.Max(boxPos.x - boxHalfSize.x, MathF.Min(circlePos.x, boxPos.x + boxHalfSize.x));
            float closestY = MathF.Max(boxPos.y - boxHalfSize.y, MathF.Min(circlePos.y, boxPos.y + boxHalfSize.y));

            // Distance from circle center to this closest point
            float dx = circlePos.x - closestX;
            float dy = circlePos.y - closestY;

            return (dx * dx + dy * dy) <= (r * r);
        }


        //     public static bool circleCircleHit(myCircle one, myCircle two)
        //    => Vector2.Distance(one.pos, two.pos) < one._radious + two._radious;
        //     public static bool boxBoxHit(myBox one, myBox two)
        //     {
        //         if (one.pos.x + one.halfSize.x < two.pos.x - two.halfSize.x) return false;
        //         if (one.pos.x - one.halfSize.x > two.pos.x + two.halfSize.x) return false;

        //         if (one.pos.y + one.halfSize.y < two.pos.y - two.halfSize.y) return false;
        //         if (one.pos.y - one.halfSize.y > two.pos.y + two.halfSize.y) return false;

        //         return true;
        //     }


        // public static bool pointInside(myBox box, Vector2 point)
        // {


        //     if (box._trans.position.x - box._size.x / 2f > point.x) return false;
        //     if (box._trans.position.x + box._size.x / 2f < point.x) return false;

        //     if (box._trans.position.y - box._size.y / 2f > point.y) return false;
        //     if (box._trans.position.y + box._size.y / 2f < point.y) return false;

        //     return true;

        // }
        //     public static bool pointInside(myCircle circle, Vector2 point) =>
        //    Vector2.Distance(circle._trans.position, point) < circle._radious;



    }


}