


using System;
using paper.animation;
using UnityEngine;
using utils;

namespace paper
{

    [Serializable]
    public class bodyPartRotate : bodyPartAttribute, IHaveId
    {

        public float _speed;

        myId _id;
        public myId getId() => _id;


        public override void init(bodyPart part, enemy user)
        {
            _id = new myId();

            Debug.Log("INIT ROTATE" + _id._id);


            invo.infinite(() =>
            { part.transform.eulerAngles += Vector3.forward * _speed * Time.deltaTime; }, 0 , _id);
        }

    }

}