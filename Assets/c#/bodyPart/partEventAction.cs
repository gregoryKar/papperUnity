


using System;
using UnityEngine;
using utils;
using utils.math;

namespace paper
{

    [Serializable]
    public class partEventAction : partAttribute, partEventListener
    {



        [Space(15)]
        [Header("_action")]
        [SerializeReference] partActionBase _action;
        [Space(15)]
        [Header("_event")]
        [SerializeReference] enemyEventBase _enmEvent;
        public override void init(bodyPart part, enemy user) { }

        //partEventAction
        public void invoke(bodyPart part, enemy user, enemyEventBase myEvent)
        {
            if (_enmEvent == null)
            {

                Debug.LogError("NULL EVENT enm= " + user.name + " part: " + part.name);
                return;
            }
            if (_enmEvent.trigger(user, myEvent) is false) return;


            Debug.LogError("Attempt cast partEventAction");
            _action?.cast(part, user);
        }
    }

}