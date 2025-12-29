


using System;
using paper.effects;
using utils;

namespace paper.animation
{

    // color arnim
    // motion anim
    // size anim

    // wait ?? for sequence
    // duration yep yep 
    // size and color by default change on end as well ?? 

    [Serializable]
    public abstract class anim : IKillable, IHaveId
    {

        public simpleId _idLocal;
        public float _duration;
        public float _wait;
        public abstract void play(object target, simpleId id);
        public abstract void loop(object target, simpleId id); //???

        public virtual void kill() => _idLocal.killAll();
        public simpleId getId() => _idLocal;

    }

}