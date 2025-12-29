

using paper;
using UnityEngine;

namespace smallManagement
{





    public class lifter : MonoBehaviour
    {

        public float _speed;
        Rigidbody2D _rb;
        public PhysicsShape2D _unityShape;
        [SerializeField] SpriteRenderer _mark;
        private void Start() => _rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {

            motion();
            lifting();

        }

        void motion()
        {
            int direction = 0;

            if (testInput.right) direction = 1;
            else if (testInput.left) direction = -1;
            else return;

            int rotation = 0;
            if (direction == -1) rotation = 180;
            transform.eulerAngles = new Vector3(0, rotation, 0);


            _rb.MovePosition(_rb.position + Vector2.right * _speed * direction * Time.deltaTime);
            // transform.position += Vector3.right * _speed * direction * Time.deltaTime;

        }




        bool _lifting;
        liftBox _liftingNow;

        void lifting()
        {

            var box = managementMain.boxThere(transform.position, ignore: _liftingNow);
           //Debug.Log("box null " + box == null);

            if (_lifting is false)
            {


                _mark.enabled = box != null;
                if (box == null) return;

                _mark.color = Color.green;
                if (Input.GetKeyDown(KeyCode.E) is false) return;

                _lifting = true;
                box.transform.parent = transform;
                box.transform.position += Vector3.up * 0.2f;
                _liftingNow = box;



            }
            else
            {


                _mark.enabled = true;
                if (box == null) _mark.color = Color.green;
                else _mark.color = Color.red;




                if (Input.GetKeyDown(KeyCode.E) is false) return;

                _lifting = false;
                _liftingNow.transform.parent = null;
                _liftingNow.transform.position += Vector3.down * 0.2f;

                _liftingNow = null;


            }




        }



    }



}