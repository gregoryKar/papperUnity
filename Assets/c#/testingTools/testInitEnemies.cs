


using System;

using UnityEngine;
using utils;

namespace paper.projectiles
{

    [Serializable]
    public class testInitEnemies : testAttributeBase
    {


[SerializeReference]
        public shape _shape;
        public override void init(Transform _trans)
        {
            Vector2 pos = _trans.position;


            //get that is shape ..
            var allEnemies = UnityEngine.Object.FindObjectsByType<enemy>(FindObjectsSortMode.None);

            foreach (var item in allEnemies)
            {
                Vector2 otherPos = item.transform.position;
                if (_shape.Intersects(item._col._shape, pos, otherPos))
                {
                    item.editInitialise();
                }
            }

        }


    }





}