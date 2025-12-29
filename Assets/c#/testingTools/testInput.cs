

using UnityEngine;

namespace paper
{





    public class testInput : MonoBehaviour
    {

        // struct inputStruct
        // {
        //     public bool down, downNow, upNow;

        // }

        static testInput _instForbidden;
        static testInput _inst
        {
            get
            {
                if (_instForbidden == null)
                    _instForbidden = new GameObject("testInput").AddComponent<testInput>();
                return _instForbidden;
            }

        }

        bool _up, _down, _left, _right;
        bool _space;
        private void Update()
        {
            _up = _down = _left = _right = false;
            _space = false;

            _up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            _down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            _left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            _right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

            _space = Input.GetKey(KeyCode.Space) ;


        }


        public static bool up => _inst._up;
        public static bool down => _inst._down;
        public static bool left => _inst._left;
        public static bool right => _inst._right;
       
        public static bool space => _inst._space;




    }



}