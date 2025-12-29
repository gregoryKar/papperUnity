




using System;
using paper;
using UnityEngine;

namespace utils.colliders
{

    [Serializable]
    public class myCollider : ITrans, IKillable
    {

        /* 
                [System.Flags]
                public enum myLayers
                {
                    bullet = 0,
                    entity = 1 << 0,
                    // bullet = 1 << 1,
                    // Environment = 1 << 2,
                    // Pickup = 1 << 3,
                    // Projectile = 1 << 4,
                }
         */
        [HideInInspector] public Transform _trans;
        public Vector2 pos => _trans.position;
        public Transform getTrans() => _trans;

        public bool _activeCollider;

        public ICollider _owner;

        [SerializeReference]
        public shape _shape;


        //myPositionBase posItem
        public myCollider() { }
        public myCollider(Transform trans, ICollider owner = null)
        {


            _trans = trans;
            colliderManager.add(this);
            //Debug.Log("ADDING COLLIDER");

            if (owner != null)
            {
                _owner = owner;
                _activeCollider = owner is IActiveCollider;
            }

        }
        public myCollider cloneMe(Transform trans, ICollider owner)
        {
            var c = new myCollider(trans, owner);
            c._shape = _shape.cloneMe();
            c._activeCollider = _activeCollider;
            return c;
        }

        //! NEED ARISED FROM BACKROUND ITEM WHERE IT DOEST GET INITIATED OR SOMETHING
        public void setTransAndOnwer(Transform trans, ICollider owner)
        {
            _trans = trans;
            colliderManager.add(this);
            //Debug.Log("ADDING COLLIDER");

            if (owner != null)
            {
                _owner = owner;
                _activeCollider = owner is IActiveCollider;
            }
        }



        public bool intresects(myCollider other) =>
             _shape.Intersects(other._shape, pos, other.pos);

        public bool pointInside(Vector2 point) =>
        _shape.pointInside(pos, point);


        public virtual void kill() => colliderManager.remove(this);

    }




    public interface ICollider { public myCollider GetCollider(); }
    public interface IActiveCollider { }

}


