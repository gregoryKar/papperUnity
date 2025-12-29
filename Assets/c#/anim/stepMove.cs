


using System;
using UnityEngine;
using utils;
using utils.math;

namespace paper.animation
{

    [Serializable]
    public class stepMove : anim
    {


        //! YOU USE THEIR ID IF NULL THE CREATE YOUR OWN ID .. 
        //! YOU THOUGHT I WOULD SPAWN A KILLING CHAIN WHERE EVERY PART 
        //! AGAIN STARTS KILLING SAME ID .. .. 

        Vector2 _startPos;
        [SerializeField] Vector2 _extra;

        public override void play(object target, simpleId id = null)//Transform trans
        {
            if (id == null) id = _idLocal = new simpleId();


            //Debug.Log("init anim" );
            if (target is not ITrans transformInterface) return;
            Transform trans = transformInterface.getTrans();



            invo.simple(() =>
            {
                trans.posSameZ(_startPos + _extra, local: true);

            }, 0f, id: id);
        }
        public override void loop(object target, simpleId id)
        {

            if (id == null) id = _idLocal = new simpleId();


            if (target is not ITrans transformInterface) return;
            Transform trans = transformInterface.getTrans();


            bool state = false;

            invoAdvanced.infinite((invaki) =>
           {
               trans.posSameZ(_startPos + (state ? _extra : Vector2.zero), local: true);
               //    trans.localPosition = _startPos + (state ? _extra : Vector2.zero);

               //Debug.Log("change state:" + state);

               state = !state;
               invaki.setDelay(state ? _duration : _wait);

           }, _duration, id: id);
        }


    }

}