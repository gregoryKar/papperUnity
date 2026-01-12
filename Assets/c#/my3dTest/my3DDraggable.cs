

using UnityEngine;
using UnityEngine.Events;
using utils;


namespace my3dtest
{


    public class my3DDraggable : MonoBehaviour
    {



        Rigidbody _rb;
        Collider _col;
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<Collider>();
            enabled = false;
        }



        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {

                enabled = false;
                stopDragg();
            }
        }
        [SerializeField] float _dragGoUp = 1f;

        void stopDragg()
        {

            _rb.isKinematic = false;
            _col.enabled = true;
            _rb.useGravity = true;
            transform.parent = null;
            _rb.WakeUp();

        }
        void OnMouseDown()
        {
            //_rb.MovePosition(_rb.position + Vector3.up * _dragGoUp);
           transform.position += Vector3.up * _dragGoUp;

            enabled = true;
            _rb.isKinematic = true;
            // _rb.useGravity = false;
            _rb.useGravity = false;
            _rb.Sleep();
            _col.enabled = false;

            transform.parent = my3DController._inst.transform;
        }








    }

}