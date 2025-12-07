




using System;
using paper;
using UnityEngine;

// namespace utils.colliders
// {

//     [Serializable]
//     public abstract class myColliderBase : ITrans, IKillable
//     {

//         /* 
//                 [System.Flags]
//                 public enum myLayers
//                 {
//                     bullet = 0,
//                     entity = 1 << 0,
//                     // bullet = 1 << 1,
//                     // Environment = 1 << 2,
//                     // Pickup = 1 << 3,
//                     // Projectile = 1 << 4,
//                 }
//          */
//         [HideInInspector] public Transform _trans;
//         public Vector2 pos => _trans.position;
//         public Transform getTrans() => _trans;

//         public bool _activeCollider;

//         public ICollider _owner;


//         //myPositionBase posItem
//         public myColliderBase() { }
//         public myColliderBase(Transform trans, ICollider owner = null)
//         {


//             _trans = trans;
//             colliderManager.add(this);
//             //Debug.Log("ADDING COLLIDER");

//             if (owner != null)
//             {
//                 _owner = owner;
//                 _activeCollider = owner is IActiveCollider;
//             }

//         }
//         public abstract myColliderBase cloneMe(Transform trans, ICollider owner);



//         public bool intresects(myColliderBase other)
//         {
//             int box = 0, circle = 0;

//             if (this is myBox) box++;
//             else if (this is myCircle) circle++;

//             if (other is myBox) box++;
//             else if (other is myCircle) circle++;






//             if (box == 2) return colliderMath.boxBoxHit((myBox)this, (myBox)other);//BOXES

//             if (circle == 2) return colliderMath.circleCircleHit((myCircle)this, (myCircle)other);//CIRCLES

//             if (box == 1 && circle == 1)// BOX CIRCLE
//             {
//                 if (this is myBox) return colliderMath.circleBoxHit((myBox)this, (myCircle)other);
//                 else return colliderMath.circleBoxHit((myBox)other, (myCircle)this);
//             }

//             return false;
//         }
//         public bool pointInside(Vector2 point)
//         {
//             if (this is myBox box) return box.pointInsideExt(point);
//             if (this is myCircle circle) return circle.pointInsideExt(point);

//             Debug.LogError("NO POINT INSIDE FOR SHAPE == " + GetType());
//             return false;
//         }

//         public virtual void kill() => colliderManager.remove(this);

//     }




//     // public interface ICollider { public myColliderBase GetCollider(); }
//     // public interface IActiveCollider { }

// }


