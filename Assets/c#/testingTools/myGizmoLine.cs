

using UnityEngine;

namespace paper
{


    public class myGizmoLine
    {

        public Transform _trans;
        public Vector2 _direction;
        //public Vector2 _offset;
        public float _distance;
        public bool _keepAlive;

        myGizmoLine(Transform trans, Vector2 direction, float distance)
        {
            _trans = trans;
            _direction = direction;
            _distance = distance;

            myGizmos.add(this);
        }
        public static void up(Transform trans, float distance)
       => new myGizmoLine(trans, Vector2.up, distance);


    }





}