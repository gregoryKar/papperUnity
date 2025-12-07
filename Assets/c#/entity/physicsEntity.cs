


using System;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using utils;

namespace paper
{

    //! DOES
    public class physicsEntity : entity
    {


        public Rigidbody2D _rb;

        public Collider2D _Unitycol;


        public Action _imobilised, _collision; //_triggerCollision
        public Action _onDeath; //_triggerCollision
        const float _imobilisedSpeedMin = 0.1f;
        const int _imobilisedCheckCountMin = 5;
        public int _imobilisedCheckCount;


        void startCeckImobilised()
        {
            //if (_imobilised is null) return;
            invoAdvanced.infinite(checkImobilised, 0.2f);
        }
        void checkImobilised(invoAdvanced i)
        {


            if (_rb.linearVelocity.magnitude > _imobilisedSpeedMin)
                _imobilisedCheckCount = 0;
            else
            {
                _imobilisedCheckCount++;
                if (_imobilisedCheckCount == _imobilisedCheckCountMin)
                {
                    _imobilised?.Invoke();
                    i._killMe = true;
                }
            }



        }

        void OnCollisionEnter2D(Collision2D other)
        {
            //  Debug.Log("collision happended");
            _collision?.Invoke();
        }


        // optional paremeters shape for collider isTrigger
        public static physicsEntity create()
        {

            var g = new GameObject("physics entity ");
            var physics = g.AddComponent<physicsEntity>();
            physics._rb = g.AddComponent<Rigidbody2D>();
            physics._rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            physics.itinitialiseId();

            physics.startCeckImobilised();



            return physics;


        }
        public void circleCol(float radious, bool trigger = false)
        {
            _Unitycol = gameObject.AddComponent<CircleCollider2D>();
            ((CircleCollider2D)_Unitycol).radius = radious;
            _Unitycol.isTrigger = trigger;
        }
        public void boxCol(Vector2 size, bool trigger = false)
        {
            _Unitycol = gameObject.AddComponent<BoxCollider2D>();
            ((BoxCollider2D)_Unitycol).size = size;
            _Unitycol.isTrigger = trigger;
        }

        public override void kill()
        {
            _onDeath?.Invoke();
            Destroy(gameObject);
        }


    }






}
