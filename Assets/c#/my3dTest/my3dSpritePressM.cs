using UnityEngine;

namespace my3dtest
{




    public class my3dSpritePressMe : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultColor = spriteRenderer.color;
            _isOn = false;
        }
        Color defaultColor;
        [SerializeField] Color pressedColor;

        bool _isOnForbidden;
        bool _isOn
        {
            set
            {
                _isOnForbidden = value;
                spriteRenderer.color = _isOn ? pressedColor : defaultColor;
            }
            get { return _isOnForbidden; }
        }

        void OnMouseUp()
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