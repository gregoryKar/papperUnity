


using System;
using paper.animation;
using UnityEngine;
using utils;

namespace paper
{

    [Serializable]
    public class bodyPartRotate : partAttribute, IHaveId
    {

        public float _speed;

        simpleId _id;
        public simpleId getId() => _id;


        public override void init(bodyPart part, enemy user)
        {
            _id = new simpleId();

            //Debug.Log("INIT ROTATE" + _id._id);


            invo.infinite(() =>
            { part.transform.eulerAngles += Vector3.forward * _speed * Time.deltaTime; }, 0 , _id);
        }

    }

}