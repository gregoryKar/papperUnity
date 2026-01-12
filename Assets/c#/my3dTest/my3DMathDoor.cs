

using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using utils.math;

namespace my3dtest
{
    public class my3DMathDoor : MonoBehaviour
    {




        [SerializeField] Rigidbody _door;
        [SerializeField] float limitX;

        [SerializeField] float _minDistance, _maxDistance;
        [SerializeField] float _forceAdjust;
        //[SerializeField] float _maxMove;
        [SerializeField] float _closeForce;
        [SerializeField] float _debugForce01, _debugDistance;
        private void Update()
        {
            float distance = Vector3.Distance(transform.position, my3DController._inst.transform.position);
            update(distance);
            _debugDistance = distance;
        }
        void update(float distance)
        {


            float force01;
            if (distance < _minDistance) force01 = 1;
            else if (distance > _maxDistance) force01 = 0;
            else force01 = 1 - myMath.Normalize(distance, _minDistance, _maxDistance);

            _debugForce01 = force01;
            float force = -_closeForce + force01 * _forceAdjust;



            _door.AddForce(_door.transform.right * force);

            anims(force01);



            //  f = 1 / (r ^ 2 - r0) * f0



        }


        [Space(20)]
        [SerializeField] Transform[] _granazi;
        [SerializeField] float[] _rotateAdjust;

        [SerializeField] Transform _forceVisualiser, _posVisualiser;

        void anims(float value01)
        {
            for (int i = 0; i < _granazi.Length; i++)
            {
                _granazi[i].Rotate(Vector3.forward, _door.linearVelocity.x * _rotateAdjust[i]);

            }


            _forceVisualiser.localScale = new Vector3(1, value01, 1);
            float posValue = myMath.Normalize(_door.transform.localPosition.x, -limitX, limitX);
            _posVisualiser.localScale = new Vector3(1, posValue, 1);



        }





    }


}