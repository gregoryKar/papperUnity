
using System.Collections.Generic;
using UnityEngine;


namespace smallArcade
{



    public enum arcadeTarget
    {
        player, enemy
    }

    public interface arcadeDamagable
    {
        public void damage(int amount);
    }
    public interface IArcadeTarget
    {
        public arcadeTarget getArcadeType();
    }

    public class arcadeManager : MonoBehaviour
    {

        static arcadeManager inst;
        void Awake() => inst = this;
        private void Update()
        {
            checkBulltesOutside();
        }

        [SerializeField] GameObject _bulletPreffab;

        public static void shoot(arcadeTarget target, Vector2 pos, Vector2 dir, float speed, int damage) =>
             inst.shootLocal(target, pos, dir, speed, damage);
        void shootLocal(arcadeTarget target, Vector2 pos, Vector2 dir, float speed, int damage)
        {
            var bull = Instantiate(_bulletPreffab).GetComponent<arcadeBullet>();
            bull.shootMe(target, pos, dir, speed, damage);

        }

        public Collider2D _gameArea;
        List<Collider2D> _bulletColliders = new();
        void checkBulltesOutside()
        {

            for (int i = _bulletColliders.Count - 1; i > 0; i--)
            {
                if (_bulletColliders[i] == null ||
                _bulletColliders[i].IsTouching(_gameArea) is false)
                {
                    if (_bulletColliders[i] != null)
                        Destroy(_bulletColliders[i].gameObject);
                    _bulletColliders.RemoveAt(i);


                }

                if (_bulletColliders.Count == 0) break;
            }

        }
        public static void addBulletCollider(Collider2D bulletCol)
        {
            inst._bulletColliders.Add(bulletCol);
        }




    }







}