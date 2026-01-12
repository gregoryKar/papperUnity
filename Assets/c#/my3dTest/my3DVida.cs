


using System;
using UnityEngine;

namespace my3dtest
{


    public class my3DVida : my3DInteractableBase
    {

        [SerializeField] float _solveDuration;
        [SerializeField] float _rotateSpeed = 1f, _moveSpeed;

        float _value;

        public bool _solved;

        public Action _onSolved;


        protected override void onHold()
        {

            _value += Time.deltaTime;
            if (_value >= _solveDuration)
            {
                _interactable = false;
                _solved = true;
                _onSolved?.Invoke();

                gameObject.SetActive(false);

            }
            //transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);

            transform.position += transform.up * _moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

        }



    }



}
