using UnityEngine;

namespace utils
{


    [CreateAssetMenu(fileName = "physicsData", menuName = "A_scriptablo/physicsData")]//what are the  `` for ??
    public class physicsData : ScriptableObject
    {

        const float minMass = 0.1f;
        const float minDrag = 0.05f, minAngularDrag = 0.05f, minGravity = 0.05f;

        //public bool _dragOn, _gravityOn;

        public float _mass, _gravity, _drag, _angularDrag;
        public PhysicsMaterial2D _material;

        public void setParameters(Rigidbody2D rb)
        {
            rb.mass = _mass;
            if (_mass < minMass) rb.mass = 1;


            if (_gravity > minGravity) rb.gravityScale = _gravity;
            if (_drag > minDrag) rb.linearDamping = _drag;
            if (_angularDrag > minAngularDrag) rb.angularDamping = _angularDrag;

          


        }
        public void setMaterial(Rigidbody2D rb)
        { if (_material is not null) rb.sharedMaterial = _material; }


    }





}