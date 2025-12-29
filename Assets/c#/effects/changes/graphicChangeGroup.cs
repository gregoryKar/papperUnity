using System;
using UnityEngine;

namespace paper.effects
{

    [Serializable]
    public class graphicChangeGroup : graphicChange
    {

        [SerializeReference]
        public graphicChange[] _changes;


        public override void apply(graphicBase graphic)
        {
            foreach (var item in _changes)
            {
                item.apply(graphic);
            }
        }

        public override graphicChange duplicate()
        {
            var group = new graphicChangeGroup();
            group._changes = new graphicChange[_changes.Length];

            for (int i = 0; i < _changes.Length; i++)
            {
                group._changes[i] = _changes[i].duplicate();
            }
            return group;

        }




        //public abstract void applyInternal(IRend rend);
    }
}