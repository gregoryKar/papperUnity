using System;
using UnityEngine;

namespace paper.effects
{


    [Serializable]
    public class effectMixer : effectBase
    {


        public effectBase[] _effects;


        public override void cast(object graphic)
        {
            foreach (var item in _effects)
            {
                item.cast(graphic);
            }
        }
        //public override void getCoodown()=>



    }

}