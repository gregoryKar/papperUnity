

using System;
using paper.motion;
using UnityEngine;
using utils;
using utils.colliders;


namespace paper.projectiles
{

    [Serializable]
    public class Projectile : entity, ICollider
    {
        public projectileData _data;

        SpriteRenderer _rend;
        [SerializeReference]
        public motionBase _motion;


        public myCollider _col;
        public myCollider GetCollider() => _col;



        public static Projectile create(projectileData data, Vector2 pos, Vector2 dir)
        {

            var g = new GameObject("projectile " + data.name);
            var p = g.AddComponent<Projectile>();
            var t = g.transform;

            p.itinitialiseId();

            p._data = data;

            p._rend = pools.sprite();
            p._rend.sprite = data._sprite;
            p._rend.name = "rend : " + data.name;
            p._rend.transform.parent = t;
            p._rend.transform.localPosition = Vector3.zero;

            t.position = pos;
            t.localScale = new Vector3(data._size, data._size, 1);

            p._col = data._col.cloneMe(t, p);

            if (data._motion is motionProjectileBase pm)
                p._motion = pm.createShoot(t, dir);
            else Debug.LogError("NO PROJECTILE MOTION IN PROJECTILE == " + data.name);


            test.add(p);//projectile
            return p;
        }



        public override void kill()
        {
            //pools.returnMe(_trans);
            getId().killAll();
            pools.returnMe(_rend);

            _col.kill();
            _motion.kill();

            test.remove(this);
            Destroy(gameObject);

        }


    }
}