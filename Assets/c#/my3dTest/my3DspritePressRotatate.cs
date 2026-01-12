using UnityEngine;

namespace my3dtest
{




    public class my3dSpritePressRotate : MonoBehaviour
    {


        [SerializeField] int _rotationValue;
        [SerializeField] Transform _rotateItem;

        bool _isOnForbidden;
        bool _isOn
        {
            set
            {
                _isOnForbidden = value;
                _rotateItem.localEulerAngles = _isOn ? new Vector3(0, 0, _rotationValue) : Vector3.zero;
            }
            get { return _isOnForbidden; }
        }

        private void OnMouseUp()
        {
            _isOn = !_isOn;
        }

          void OnMouseEnter()
        {
           // transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            transform.position += Vector3.up * 0.3f;
        }
        void OnMouseExit()
        {
          //  transform.localScale = Vector3.one;
            transform.position -= Vector3.up * 0.3f;
        }


    }
}