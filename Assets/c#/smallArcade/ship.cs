




using Unity.Mathematics;
using UnityEngine;
using utils.math;

namespace smallArcade
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class ship : MonoBehaviour, IArcadeTarget, arcadeDamagable
    {


        [SerializeField] shipData _data;
        [SerializeField] Collider2D _pistaCollider;
        [SerializeField] Transform gun;
        Collider2D _shipCollider;
        Rigidbody2D _rb;





        //int2 _lastInput; //_lastInput = input;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _shipCollider = GetComponent<Collider2D>();

            _health = _data._shipHealth;
        }
        void Update()
        {
            _data._shipPhysics.setParameters(_rb);

            move();
            shoot();



        }

        void move()
        {
            if (_shipCollider.IsTouching(_pistaCollider) is false)
            {
                transform.posSameZ(_pistaCollider.transform.position);
                _rb.linearVelocity = Vector2.zero;
                _rb.angularVelocity = 0;
            }

            int move = 0;
            int turn = 0;

            if (Input.GetKey(KeyCode.W)) move = 1;
            if (Input.GetKey(KeyCode.S)) move = -1;
            if (Input.GetKey(KeyCode.A)) turn = -1;
            if (Input.GetKey(KeyCode.D)) turn = 1;

            Vector2 force = transform.up * move * _data.speedForce;
            float torque = turn * _data._turnForce;



            _rb.AddForce(force);
            _rb.AddTorque(-torque);


        }
        void shoot()
        {

            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            myMath.LookAt2D_chatGtp(gun, mousePos);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                arcadeManager.shoot(arcadeTarget.enemy, gun.position, gun.up, _data._bulletSpeed, _data._bulletDamage);

            }

        }
        int _health;
        public void damage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                _health = 0;
                Debug.LogError("SHIP DEAD");
            }

        }

        public arcadeTarget getArcadeType() => arcadeTarget.player;



    }




}