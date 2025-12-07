






using Unity.Mathematics;
using UnityEngine;
using utils.math;

namespace smallArcade
{


    //[RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class arcadeEnemy : MonoBehaviour, IArcadeTarget, arcadeDamagable
    {



        public int _health;
        public void damage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                _health = 0;
                Debug.LogWarning("ENEMY DEAD");
                Destroy(gameObject);
            }

        }

        public arcadeTarget getArcadeType() => arcadeTarget.enemy;










    }



}