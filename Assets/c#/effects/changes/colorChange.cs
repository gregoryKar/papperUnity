using System;
using UnityEngine;

namespace paper.effects
{

    //NEED SYSTEM THAT HOLDS CHANGES AND RESETS like holds i have this this this and sets sprite acordingly and then remove any change you want and calculate .. not localy set reset .. they are dependant of each other
    // like changes of all 1 material .. .. its not set material period .. ..
    // like scale changes as well..

    [Serializable]
    public class colorChange : graphicChange
    {

        public Color _set;

        public override void apply(graphicBase graphic) =>
        graphic.setColor(_set);
      

        public override graphicChange duplicate() => new colorChange { _set = _set };



    }

}