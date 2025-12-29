
using System;

namespace paper
{

    [Serializable]
    public abstract class partActionBase
    {

        public abstract void cast(bodyPart part, enemy enm);
    }

}