

using System;
using System.Collections.Generic;
using paper.attacks;
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
        public int _maxHealth;

        public myCollider _col;
        public myCollider GetCollider() => _col;

        [SerializeReference]
        public enemyAttack _attack;



        [HideInInspector]
        public bool _inRangeBool;
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

            enm._maxHealth = enm._health;

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

            enm.addAllPartsMain(enm._trans);

            return enm;



        }

        public void editInitialise()
        {


            name += "__EDIT INITIALISED";

            itinitialiseId();




            _trans = transform;

            _maxHealth = _health;


            test.add(this);

            _col = _col.cloneMe(_trans, this);

            _motion = _motion.createClone(_trans);

            //_health = data._startHealth;

            addAllPartsMain(transform);

            Debug.LogWarning("EDIT INITIALISED ENEMY");

        }

        //TO THIS AND TO ALL CHILDREN RECURSIVELY

        public void addAllPartsMain(Transform target)
        {
            addPartSingle_FORBIDDEN(target);
            addChildParts_FORBIDDEN(target);
        }
        public void removePart(bodyPart part)
        {
            _parts.Remove(part);
        }
        void addPartSingle_FORBIDDEN(Transform target)
        {

            if (target.TryGetComponent<bodyPart>(out var partMe))
            {
                partMe.init(this);
            }



        }
        void addChildParts_FORBIDDEN(Transform target)
        {
            if (target.childCount == 0) return;
            for (int i = 0; i < target.childCount; i++)
            {
                var t = target.GetChild(i);
                if (t.TryGetComponent<bodyPart>(out var part))
                {
                    part.init(this);
                }
                addChildParts_FORBIDDEN(t);
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
            else invokeAttributeEvent(new damageEvent() { _damageAmount = amount });

        }




        public void invokeAttributeEvent(enemyEventBase enmEvent)
        {

            int counter = _parts.Count - 1;
            while (counter > -1 && _parts.Count > 0)
            {
                _parts[counter].invokeEvent(this, enmEvent);
                counter--;

            }


            // Debug.Log("part name = " + part.name);
            // foreach (var attribute in part._attributes)
            // {
            //     Debug.Log("attribute name = " + part.name);
            //     if (attribute is partKillable kill) kill.kill(part, this);
            // }


        }
        public override void kill()

        {

            invokeAttributeEvent(new deathEvent());

            foreach (var part in _parts)
            {
                mainFunctions.kill(part);
            }

            getId().killAll();

            _col.kill();
            _motion.kill();

            test.remove(this);

            Destroy(gameObject);
        }

    }
}