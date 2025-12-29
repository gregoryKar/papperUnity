


using System;
using paper.animation;
using UnityEngine;
using utils;

namespace paper
{

    [Serializable]
    public class partRotateStep : partAttribute, IHaveId
    {

        public float _step, _cooldown;


        simpleId _id;
        public simpleId getId() => _id;


        public override void init(bodyPart part, enemy user)
        {
            _id = new simpleId();

            //Debug.Log("INIT ROTATE" + _id._id);


            invo.infinite(() =>
            { part.transform.eulerAngles += Vector3.forward * _step ; }, _cooldown, _id);
        }

    }

}