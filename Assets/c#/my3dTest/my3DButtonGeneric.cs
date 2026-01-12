

using UnityEngine;
using UnityEngine.Events;
using utils;


namespace my3dtest
{


    public class my3DButtonGeneric : MonoBehaviour
    {

        public UnityEvent _onClick;
        Vector3 _originalSize;
        [SerializeField] float _lookSizeMult = 1.2f;
        [SerializeField] float _invissibleDuration;

        void Start()
        {
            _originalSize = transform.localScale;
        }

        void OnMouseUp()
        {
            _onClick.Invoke();

            gameObject.SetActive(false);
            invo.simple(() => { gameObject.SetActive(true); }, _invissibleDuration);
        }

        void OnMouseEnter()
        {
            transform.localScale = _lookSizeMult * _originalSize;
        }
        void OnMouseExit()
        {
            transform.localScale = _originalSize;
        }





    }

}