




using Unity.Mathematics;
using UnityEngine;
using utils.math;

namespace smallArcade
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class arcadeBullet : MonoBehaviour
    {

        public arcadeTarget _target;
        public int _damage;
        public int _ZZZ;

        public void shootMe(arcadeTarget target, Vector2 pos, Vector2 dir, float speed, int damage)
        {
            _target = target;
            _damage = damage;
            Vector3 position = pos;
            position.z = _ZZZ;

            transform.position = position;
           //yMath.LookAt2D_chatGtp(transform, dir);
            myMath.LookAtDir2D_chatGtp(transform, dir);
            //Debug.Log("rot = " + transform.eulerAngles);

            GetComponent<Rigidbody2D>().linearVelocity = dir * speed;

            arcadeManager.addBulletCollider(GetComponent<Collider2D>());



        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            arcadeDamagable dmg = other.GetComponent<arcadeDamagable>();
            IArcadeTarget type = other.GetComponent<IArcadeTarget>();

            if (dmg == null || type == null) return;
            if (type.getArcadeType() != _target) return;

            Debug.Log("arcade collision detected");

            dmg.damage(_damage);
            Destroy(gameObject);
        }






    }



}