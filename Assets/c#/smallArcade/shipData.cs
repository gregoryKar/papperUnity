




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
        public int _shipHealth;

        public int _bulletDamage;
        public float _bulletSpeed;





    }




}