using System;
using UnityEngine;
using utils;
using utils.math;

namespace paper.effects
{


    [Serializable]
    public class effectLoopRandomiser : effectBase
    {

        [SerializeReference] public graphicChange _effe;
        public float _duration;
        public int _durationRandom;

        public float _cooldown;
        public int _cooldownRandom;


        public override void cast(object graphic)
        {

            bool doneEffect = false;

            invoAdvanced.infinite((invaki) =>
            {
                if (doneEffect is false)
                {
              //      _effe.apply(graphic);
                    invaki.setDelay(getDuration());
                }
                else
                {
                  //  _effe.reverse(graphic);
                    invaki.setDelay(getCoodown());
                }

                doneEffect = !doneEffect;

            }, 0);
        }

        public float getCoodown() => _cooldown + myRandom.dirPercent(_cooldown, _cooldownRandom);
        public float getDuration() => _duration + myRandom.dirPercent(_duration, _durationRandom);



    }



}