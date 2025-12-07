


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


        static test instance;

        private void Awake()
        {
            instance = this;
            Debug.Log("test instance " + myTime.now);
        }


        [SerializeReference] readonly List<enemy> _enemies = new();
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
                if (motion._canMove is false) continue;
                motion.process(delta);
            }

            foreach (var enm in _enemies)
            {
                if (enm._inRange) continue;

                if (enm.inRange)
                {
                    //new enemyCondition here somehow
                    enm._motion._canMove = false;
                }
            }





        }




    }





}