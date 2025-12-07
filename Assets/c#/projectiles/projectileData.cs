
using paper.motion;
using Sirenix.OdinInspector;
using UnityEngine;
using utils;
using utils.colliders;

namespace paper.projectiles
{


    [CreateAssetMenu(fileName = "projectileData", menuName = "A_scriptablo/projectileData")]//what are the  `` for ??
    public class projectileData : ScriptableObject
    {

        [SerializeReference]
        public motionProjectileBase _motion;
       
        public myCollider _col;
        public Sprite _sprite;
        public float _size;

        [SerializeReference]
        public projectileResult[] _resultArray;





        public Projectile create(Vector2 pos, Vector2 dir) =>
            Projectile.create(this, pos, dir);


        [Button]
        public void editCreate()
        {

            if (Application.isPlaying is false) return;
            var p = create(testTool.testPos, testTool.testDir);

            int counter = 0;
            invoAdvanced.repeat
          ((advanced) =>
            {
                if (p == null || p.gameObject == null)
                    advanced._killMe = true;

                counter++;
                if (counter > 3)
                {
                    p.kill();
                    advanced._killMe = true;
                }

            }, 1, 10);// per 1 sec 10 times

        }


    }





}