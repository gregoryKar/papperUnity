

using System;
using System.Collections.Generic;
using UnityEngine;

namespace paper
{

    [Serializable]
    public partial class enemy
    {
        //public int health = 100;
        [HideInInspector]
        public Transform _trans;
        [SerializeReference]

        public float _range;
        public enemyMove _move;
        public List<bodyPart> _parts = new();
        public List<enemyCondition> _conditions = new();

        public enemy(enemyData data)
        {
            var obj = new GameObject(data.name);
            _trans = obj.transform;
            obj.AddComponent<SpriteRenderer>().sprite = data._sprite;

            test.add(this);
        }


    }
}