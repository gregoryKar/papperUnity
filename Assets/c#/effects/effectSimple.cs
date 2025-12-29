using System;
using UnityEngine;
using utils;

namespace paper.effects
{


    [Serializable]
    public class effectSimple : 
    effectBase
    {

        [SerializeReference] public graphicChange _effe;
        public float _duration;
        public override void cast(object graphic)
        {
            //  Debug.Log("effectSimple cast");
            // _effe.apply(graphic);
            // invo.simple(() => { _effe.reverse(graphic); }, _duration);
        }
        //public override void getCoodown()=>



    }

}