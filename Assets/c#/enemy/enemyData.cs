
using Sirenix.OdinInspector;
using UnityEngine;

namespace paper
{


    [CreateAssetMenu(fileName = "enemyData", menuName = "A_scriptablo/enemyData", order = -1000)]//what are the  `` for ??
    public class enemyData : ScriptableObject
    {

        [SerializeReference]
        public enemyMove _move;
        public Sprite _sprite;



        // [SerializeReference]
        // public enemyAttribute[] _attributes;



        public void create()
        {

            var enm = new enemy(this);
            // enm._move = (enemyMove)_move.clone();

            if (_move is IneedClone clone)  enm._move = (enemyMove)clone.clone();
            else enm._move = _move;

            if (enm._move is IneedInit _init) _init.init();
        }
            
        [Button]
        public void editCrate()
        {

            if (Application.isPlaying is false) return;
            create();

        }


    }





}