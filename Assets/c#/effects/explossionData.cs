

using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using utils;
using utils.math;

namespace paper.effects
{




    [CreateAssetMenu(fileName = "explossionData", menuName = "A_scriptablo/explossionData")]
    public class explossionData : ScriptableObject
    {



        [SerializeField] Sprite _triangleSprite, _squareSprite;
        [SerializeField] Vector2 _triangleX, _triangleY;
        [SerializeField] float _triangleRandomSize;




        [Space(20)]
        [SerializeField] int _amount;
        [SerializeField] int _randomPoisitioning;
        [SerializeField] float _offsetAdjust;
        [SerializeField] Vector2 _size;
        [SerializeField] float _heightSizeMultiply;
        [SerializeField] float _lifeTime;
        [SerializeField] int _sizeRandomAjdust;
        [SerializeField]
        constants.pointSeperationMethod _method;
        [SerializeField] float _outlineSize;

        [Space(20)]
        [SerializeField] float _goUpAfter;
        [SerializeField] float _upAmount;


        public void create(Vector2 there)
        {



            var points = myFunctions.spreadPoints(_amount, _method, _randomPoisitioning);



            for (int i = 0; i < points.Length; i++)
            { points[i] *= 180; points[i] -= 90; }



            for (int i = 0; i < _amount; i++)
            {
                var s = pools.sprite();
                s.sprite = _triangleSprite;
                Vector3 size = _size;
                size.x += myMath.randomDirPercent(size.x, _sizeRandomAjdust);
                size.y += myMath.randomDirPercent(size.y, _sizeRandomAjdust);
                size += (Vector3)Vector2.one * _heightSizeMultiply * size.y;
                size.z = 1;
                s.transform.localScale = size;


                Vector2 dir = myMath.angleToVec(points[i]);
                Debug.Log("dir " + dir + " points[i] " + points[i]);
                s.transform.position =
                there + dir * _offsetAdjust * _size.y;

                // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // s.transform.rotation = Quaternion.Euler(0, 0, angle);
                myMath.rotate(s.transform, dir);

                var clone = pools.clone(s);
                clone.transform.parent = s.transform;
                clone.transform.localPosition = new Vector3(0, 0, 0.1f);
                clone.transform.localScale = Vector3.one * _outlineSize;
                clone.transform.localRotation = quaternion.identity;
                clone.color = Color.black;


                invo.simple(() => { s.transform.goUp(_upAmount); }, _goUpAfter);
                invo.simple(() => { pools.returnMe(clone); pools.returnMe(s); }, _lifeTime);



            }

        }


        [Button]
        public void editCreate()
        {
            if (Application.isPlaying is false) return;
            create(testTool.testPos);
        }


        [Space(20)]
        [SerializeField] float[] testPoints;
        [Button]
        public void testPointGeneration(int amount, int random, constants.pointSeperationMethod method)
        {
            testPoints = myFunctions.spreadPoints(amount, method, random);




        }

        [Button]
        void testAngleToDegree(Transform test, int angle)
        {

            Vector2 dir = myMath.angleToVec(angle);
            Debug.Log("dir " + dir);
            if (test != null) myMath.rotate(test, dir);

        }


    }

}