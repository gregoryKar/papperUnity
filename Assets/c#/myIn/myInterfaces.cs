

using UnityEngine;

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
}