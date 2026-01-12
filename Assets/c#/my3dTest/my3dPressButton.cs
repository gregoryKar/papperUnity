

using UnityEngine;
using utils;

namespace my3dtest
{




    public class my3dPressButton :  my3DInteractableBase
    {


        [SerializeField] Vector3 _moveValue;


        [SerializeField] float _stayDownDelay, _lookSizeMult;


        Vector3 _originalPos, _originalSize;
        bool _moving;
        void Start()
        {
            _originalPos = transform.position;
            _originalSize = transform.localScale;
        }

        // void OnMouseUp()
        // {

        // }

        void getBackUp()
        {
            _moving = false;
            transform.position = _originalPos;
        }




        // void OnMouseEnter()
        // {
           
        // }
        // void OnMouseExit()
        // {
         
        // }



        protected override void onLookAt()
        {
             transform.localScale = _lookSizeMult * _originalSize;
        }

        protected override void onLookAway()
        {
              transform.localScale = _originalSize;
        }

        protected override void onPress()
        {
            if (_moving) return;
            _moving = true;

            transform.position += _moveValue;
            invo.simple(getBackUp, _stayDownDelay);
        }
    }
}