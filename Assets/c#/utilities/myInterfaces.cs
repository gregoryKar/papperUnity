

using UnityEngine;
using utils;

namespace paper
{

    public interface IneedClone { public object clone(); }
    public interface IneedInit { public void init(); }



    public interface IGraphic { }
    public interface IRend : IGraphic
    {
        public SpriteRenderer getRend();

    }
    public interface ITrans : IGraphic
    {
        public Transform getTrans();

    }

    public interface IDamagable { public void damage(int amount); }
    public interface IKillable { public void kill(); }

    public interface IHaveId { public myId getId(); }


}