

using System;
using System.Collections.Generic;
using paper.motion;
using UnityEngine;
using utils;
using utils.colliders;


namespace paper
{

    [Serializable]
    public partial class enemy : entity, ICollider
    {

        [HideInInspector]
        public Transform _trans;
        [SerializeReference]

        public int _health;

        public myCollider _col;
        public myCollider GetCollider() => _col;



        [HideInInspector]
        public bool _inRange;
        [SerializeReference]
        public motionBase _motion;


        public List<bodyPart> _parts = new();
        public List<enemyCondition> _conditions = new();





        public static enemy create(enemyData data)
        {

            var g = Instantiate(data._preffab);
            var enm = g.GetComponent<enemy>();
            g.name = "enemy " + data.name;

            enm.itinitialiseId();

            var t = g.transform;


            enm._trans = g.transform;
            //enm._rend = pools.sprite();
            // enm._rend.sprite = data._sprite;
            // enm._rend.transform.localScale = Vector3.one * data._size;
            // enm._rend.name = "rend : " + data.name;
            // enm._rend.transform.parent = t;
            // enm._rend.transform.localPosition = Vector3.zero;

            test.add(enm);

            enm._col = data._Col.cloneMe(t, enm);

            enm._motion = data._motion.createClone(t);

            enm._health = data._startHealth;

            enm.addParts();

            return enm;



        }


        public void editInitialise()
        {


            name += "__EDIT INITIALISED";

            itinitialiseId();




            _trans = transform;


            test.add(this);

            _col = _col.cloneMe(_trans, this);

            _motion = _motion.createClone(_trans);

            //_health = data._startHealth;

            addParts();

            Debug.LogWarning("EDIT INITIALISED ENEMY");

        }


        void addParts()
        {


            for (int i = 0; i < transform.childCount; i++)
            {
                var t = transform.GetChild(i);
                if (t.TryGetComponent<bodyPart>(out var part)) part.init(this);


            }


        }

        public void damage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                _health = 0;
                kill();
            }
        }


        public override void kill()
        {
            invoManager.killAll(getId());

            _col.kill();
            _motion.kill();

            test.remove(this);

            foreach (var part in _parts)
            {
                mainFunctions.kill(part);
                // Debug.Log("part name = " + part.name);
                // foreach (var attribute in part._attributes)
                // {
                //     Debug.Log("attribute name = " + part.name);
                //     if (attribute is partKillable kill) kill.kill(part, this);
                // }

            }

            Destroy(gameObject);
        }


    }
}