


using System.Collections.Generic;
using paper.effects;
using paper.motion;
using paper.projectiles;
using Sirenix.OdinInspector;
using UnityEngine;
using utils;

namespace paper
{



    public class test : MonoBehaviour
    {


        public static test instance;



        private void Awake()
        {
            instance = this;
            //Debug.Log("test instance " + myTime.now);
        }


        [SerializeReference] public readonly List<enemy> _enemies = new();
        [SerializeReference] readonly List<Projectile> _projectiles = new();
        [SerializeReference] readonly List<motionBase> _motions = new();

        public static void add(enemy enm) =>
            instance._enemies.Add(enm);
        public static void remove(enemy enm) =>
     instance._enemies.Remove(enm);

        public static void add(Projectile proj) =>
            instance._projectiles.Add(proj);
        public static void remove(Projectile proj) =>
    instance._projectiles.Remove(proj);


        public static void add(motionBase move) =>
            instance._motions.Add(move);
        public static void remove(motionBase move) =>
            instance._motions.Remove(move);


        public particeData _particle;

        public float spawnDelay;
        public bool testParticle;
        void Start()
        {


            if (testParticle is false) return;
            invo.infinite(() =>
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _particle.create(mouse);
            }, spawnDelay);
        }
        void Update()
        {
            float delta = Time.deltaTime;

            foreach (var motion in _motions)
            {
                if (motion._canMove != true) continue;
                motion.process(delta);
            }

            if (Input.GetKeyDown(KeyCode.Space))//! EDIR
            {
                foreach (var enm in _enemies)
                {
                    enm.invokeAttributeEvent(new testInputEvent() { _key = KeyCode.Space });
                }
            }

            foreach (var enm in _enemies)
            {
                if (enm._inRangeBool) continue;

                if (enm.inRange is false) continue;

                //! FOR EDIT enm._trans.position += Vector3.right * 10;
                //new enemyCondition here somehow
                enm._inRangeBool = true;
                enm._motion._canMove = false;
                //Debug.LogError("I SET MOVE TO FALSE == "+  enm._motion._canMove);
                enm._attack?.beginAttack(enm);
                enm.invokeAttributeEvent(new rangeReachedEvent());

            }





        }



    }
}


