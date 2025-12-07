using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using utils.colliders;
using paper.projectiles;
using paper;


public class collisionHandler : MonoBehaviour
{


    // just assume that first one is bullt for now..
    public void handleCollisionsGroup(List<(myCollider, myCollider)> array)
    {
        foreach (var item in array)
        {
            handleCollision(item.Item1, item.Item2);
        }
    }
    void handleCollision(myCollider a, myCollider b)
    {

        if (a._owner is not Projectile proj) return;
        if (b._owner is not enemy enm) return;

        foreach (var result in proj._data._resultArray)
        {
            result.cast(enm);
        }

        proj.kill();

    }



}


