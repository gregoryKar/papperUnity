


using System;
using Unity.Mathematics;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class deathFly : bodyPartAttribute, partKillable
    {
        public override void init(bodyPart part, enemy user) { }



        public float _speed;
        public float _rotateSpeed;
        public float _randomRotate;
        public physicsData _physicsData;
        public float _colliderSize;


        public void kill(bodyPart part, enemy user)
        {

            Debug.Log("FLYYYYYYY");

            var physics = physicsEntity.create();
            physics.transform.position = part.transform.position;
            physics.transform.eulerAngles = part.transform.eulerAngles;
            physics.transform.localScale = Vector3.one;

            var rend = pools.clone(part.GetComponent<SpriteRenderer>());
            rend.transform.parent = physics.transform;
            rend.transform.localPosition = Vector3.zero;
            rend.transform.localRotation = quaternion.identity;

            physics.boxCol(Vector2.one * _colliderSize);
            _physicsData.setParameters(physics._rb);
            _physicsData.setMaterial(physics._rb);

            var t = pools.trans();
            t.eulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(-_randomRotate, _randomRotate));
            Vector2 dir = t.up;
            pools.returnMe(t);

            physics._rb.linearVelocity = dir * _speed;
            physics._rb.angularVelocity = _rotateSpeed;
            if (UnityEngine.Random.Range(0f, 1f) > 0.5f) physics._rb.angularVelocity *= -1;

            void flashIt()
            {
                rend.enabled = false;
                invo.simple(() => { rend.enabled = true; }, 0.1f);
            }
            void fadeIt()
            {
                invoAdvanced.repeat((advanced) =>
                {
                    Color col = rend.color;
                    col.a -= 0.2f;
                    rend.color = col;

                    if (col.a < 0.1f)
                    {
                        advanced._killMe = true;

                        pools.returnMe(rend);
                        physics.kill();


                    }

                }, 0.1f, 10);

            }

            physics._collision += flashIt;
            physics._imobilised += fadeIt;


        }




    }

}