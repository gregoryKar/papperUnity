



using System;
using utils;

namespace paper.effects
{
    [Serializable]
    public abstract class graphicChange
    {

        public simpleId _id;
        public abstract void apply(graphicBase graphic);
        public abstract graphicChange duplicate();


    }
}