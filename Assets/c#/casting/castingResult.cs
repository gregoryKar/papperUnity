using System;
using paper.projectiles;
using UnityEngine;


namespace paper.casting
{


    [Serializable]
    public class castingResult
    {

        [SerializeReference] projectileData _projectile;
        [SerializeField] Vector2 _dir;
        public void execute(Vector2 pos)
        {
            _projectile.create(pos, _dir);
            Debug.Log("EXECUTED castingResult");
        }



    }






}