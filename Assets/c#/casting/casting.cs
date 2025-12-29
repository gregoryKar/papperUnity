using System;
using UnityEngine;
using utils;

namespace paper.casting
{





    [Serializable]
    public class casting
    {



        [SerializeField] Sprite _testSprite;
        [SerializeField] Vector2 _testSize;
        public SpriteRenderer getGraphic()
        {
            var s = pools.sprite();
            s.sprite = _testSprite;
            s.transform.localScale = (Vector3)_testSize + Vector3.forward;
            return s;
        }

        [SerializeReference]
        public
        castingArea _area;

        [SerializeReference]
        public
        castingResult _result;

        //public void execute() => _result.execute();



    }





}