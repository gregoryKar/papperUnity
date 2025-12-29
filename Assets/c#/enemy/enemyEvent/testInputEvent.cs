



using System;
using UnityEngine;

namespace paper
{

    [Serializable]
    public class testInputEvent : enemyEventBase
    {



        [SerializeField] public KeyCode _key;
        protected override bool triggerInternal(enemy enm, enemyEventBase enmEvent) => _key == ((testInputEvent)enmEvent)._key;



        protected override bool sameTypeInternal(enemyEventBase enmEvent) => enmEvent is testInputEvent;



    }



}