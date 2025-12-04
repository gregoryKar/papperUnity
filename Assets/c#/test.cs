


using System.Collections.Generic;
using paper.effects;
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
        }


        [SerializeField] readonly List<enemy> _enemies = new();

        public static void add(enemy enm)
        {
            instance._enemies.Add(enm);
        }

        public particeData _particle;

        public float spawnDelay;
        void Start()
        {
            invo.infinite(() =>
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _particle.create(mouse);
            }, spawnDelay);
        }
        void Update()
        {
            foreach (var enm in _enemies)
            {
                enm._move.Move(enm);
                if(enm._move.isInRange(enm))
                {
                    enm._move.i
                }
            }



        }




    }





}