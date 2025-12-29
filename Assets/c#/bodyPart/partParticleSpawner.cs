


using System;
using paper.animation;
using paper.effects;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partParticleSpawner : partAttribute
    {



        //myId _id;
        //public myId getId() => _id;
        [SerializeField] particeData _particle;
        [SerializeField] Vector2 _offset;
        [SerializeField] bool _offsetDirectionAdjusted;
        [SerializeField] float _cooldown;



        public override void init(bodyPart part, enemy user)
        {

            invo.infinite(() =>
            {
                Vector2 pos = part.transform.vek2();
                if (_offsetDirectionAdjusted)
                {

                    Vector2 dir = part.transform.up;

                    pos.x += _offset.x * dir.x;
                    pos.y += _offset.y * dir.y;

                }
                else pos += _offset;

                _particle.create(pos);

            }, _cooldown, user.getId());
        }



    }

}