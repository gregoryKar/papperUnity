
using paper.motion;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using utils.colliders;

namespace paper
{


    [CreateAssetMenu(fileName = "enemyData", menuName = "A_scriptablo/enemyData", order = -1000)]//what are the  `` for ??
    public class enemyData : ScriptableObject
    {


        public GameObject _preffab;

        [SerializeReference]
        public motionBase _motion;
        //[SerializeReference]
        public myCollider _Col;
        public float _range; // should be in data
        public int _startHealth; // should be startHealth in data
        //public Sprite _sprite;
        //public float _size;



        // [SerializeReference]
        // public enemyAttribute[] _attributes;



        public void create()
        {
            enemy.create(this);
        }

        [Button]
        public void editCreate()
        {
            if (Application.isPlaying is false) return;
            create();

        }


    }





}