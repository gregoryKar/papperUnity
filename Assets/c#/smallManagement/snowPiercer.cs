

using paper;
using UnityEngine;

namespace smallManagement
{





    public class snowPiercer : MonoBehaviour
    {

        public float _speed;
        public float _shoverUpMove;
        float _shovelStartPos;
        public Transform _shovel;


        Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _shovelStartPos = _shovel.localPosition.y;
        }
        private void FixedUpdate()
        {


            move();
            checlShovelUp();



        }

        void move()
        {
            int direction;

            if (testInput.right) direction = 1;
            else if (testInput.left) direction = -1;
            else return;

            int rotation = 0;
            if (direction == -1) rotation = 180;
            transform.eulerAngles = new Vector3(0, rotation, 0);

            _rb.MovePosition(_rb.position + Vector2.right * _speed * direction * Time.deltaTime);
            // transform.position += Vector3.right * _speed * direction * Time.deltaTime;

        }

        //bool _shovelUp;
        void checlShovelUp()
        {

            Vector3 pos;
            if (Input.GetKey(KeyCode.E))//&& _shovelUp is false
            {
                //_shovelUp = true;

                pos = _shovel.localPosition;
                pos.y = _shoverUpMove;
                _shovel.localPosition = pos;

            }
            else //if (_shovelUp)
            {
                //_shovelUp = false;
                pos = _shovel.localPosition;
                pos.y = _shovelStartPos;
                _shovel.localPosition = pos;

            }
        }

    }



}