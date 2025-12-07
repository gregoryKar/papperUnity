
using System.Collections.Generic;
using UnityEngine;

namespace utils.colliders
{

    public class colliderManager : MonoBehaviour
    {


        collisionHandler _handler;
        static colliderManager instForbidden;
        static colliderManager inst
        {
            get
            {
                if (instForbidden == null)
                {
                    instForbidden = new GameObject("colliderManager").AddComponent<colliderManager>();

                    invo.infinite(() =>
                    {
                        inst._editCollidersCount = inst._colliders.Count;

                        int _actives = 0;
                        foreach (var item in inst._colliders)
                        {
                            if (item._activeCollider) _actives++;
                        }

                        inst._editActiveColliders = _actives;

                    }, 0.5f);
                }
                return instForbidden;


            }
        }
        public List<myCollider> _colliders = new();//myColliderBase

        void Awake()
        {
            _handler = new GameObject("handler")
           .AddComponent<collisionHandler>();
        }


        //one target per collision for now.. ..
        //not targeting other active colliders for now
        void Update()
        {


            // int collisionsChecked = 0;
            // int collisionsSuccess = 0;

            //myColliderBase
            List<(myCollider, myCollider)> collisions = new();

            foreach (var col in _colliders)
            {
                //collisionsChecked++;
                //Debug.Log("")

                if (col._activeCollider is false) continue;



                foreach (var other in _colliders)
                {
                    if (col == other) continue;
                    if (other._activeCollider) continue;

                    if (col.intresects(other) is false) continue;

                    //collisionsSuccess++;

                    collisions.Add(new(col, other));

                    break;

                }
            }

            _handler.handleCollisionsGroup(collisions);


        }



        [SerializeField] int _editCollidersCount, _editActiveColliders;


        public static void add(myCollider col) => inst._colliders.Add(col);
        public static void remove(myCollider col) => inst._colliders.Remove(col);


        public static myCollider detect(Vector2 point)
        {

            foreach (var item in inst._colliders)
            {

                if (item.pointInside(point)) return item;
            }

            return null;

        }

        public static myCollider detect(Vector2 point, float radious)
        {


            var circle = new circle(radious);
            myCollider target = null;

            foreach (var item in inst._colliders)
            {
                if (item.Equals(circle)) continue;
                if (circle.Intersects(item._shape, point, item.pos)) { target = item; break; }
            }


            return target;

        }



        public void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 0, 0.4f);
            foreach (var col in _colliders)
            {

                if (col._shape is square _square) drawBox(_square , col.pos);
                else if (col._shape is circle _circle) drawCircle(_circle, col.pos);


            }

            void drawBox(square _square, Vector2 pos) => Gizmos.DrawWireCube(pos, _square._size);

            void drawCircle(circle _circle, Vector2 pos) => Gizmos.DrawWireSphere(pos, _circle._radious);

        }






    }


}