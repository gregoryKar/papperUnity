




using UnityEngine;
using utils;

namespace smallManagement
{






    [CreateAssetMenu(fileName = "managementData", menuName = "A_Management/managementData", order = -1000)]//what are the  `` for ??
    public class managementData : ScriptableObject
    {

        public float _caliberStartSpeed;
        public float _caliberStartRotSpeed;
        public Vector2 _cacliberStartDir;
        public float _shootCooldown;
        public float _bulletSpeed;



    }




}