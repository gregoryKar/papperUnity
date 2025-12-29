




using UnityEngine;
using utils;

namespace smallArcade
{






    [CreateAssetMenu(fileName = "shipData", menuName = "A_Arcade/shipData", order = -1000)]//what are the  `` for ??
    public class shipData : ScriptableObject
    {
        
        


        public float speedForce;
        public float _turnForce;
        public physicsData _shipPhysics;
        
        [Space(15)]
        public int _shipHealth;

        [Space(15)]
        public int _bulletDamage;
        public float _bulletSpeed;
        public float _shootCooldown;





    }




}