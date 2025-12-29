using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using utils;
using utils.colliders;
using utils.math;

namespace paper
{


    public class backroundItem : MonoBehaviour, ITrans, ICollider
    {



        public Transform getTrans() => transform;
        public myCollider _col;

        HashSet<int2> myPoints;
        SpriteRenderer _rend;
        private void Start()
        {
            _col.setTransAndOnwer(transform, this);
            myPoints = backroundManager.inst.colliderToPoints(_col);
            //Debug.LogError(" Debug.LogError( "+myPoints.Count);
            _rend = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {
            if (myPoints.Overlaps(backroundManager.inst._occupationPoints))
            {
                _rend.changeA(0.5f);
                transform.eulerAngles = Vector3.forward * 15;

            }
            else _rend.changeA(1f);
        }

        public myCollider GetCollider() => _col;

    }

}