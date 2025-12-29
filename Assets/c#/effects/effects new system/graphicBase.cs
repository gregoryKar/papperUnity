



using System;
using System.Collections.Generic;
using UnityEngine;
using utils;
using utils.math;

namespace paper.effects
{
    [Serializable]
    public abstract class graphicBase
    {

        protected myId _id;
        protected List<graphicChange> _effects = new();


        protected Color _startColor;
        protected Vector2 _startSize;
        protected Vector2 _startPos;
        protected float _startRot;


        protected abstract void takeStartData();
        protected abstract void resetStartData();



        public void apply(graphicChange change)
        {
            var newChange = change.duplicate();
            newChange._id = new();
            newChange.apply(this);
            _effects.Add(newChange);

        }
        public void applyDuration(graphicChange change, float duration)
        {
            var newChange = change.duplicate();
            newChange._id = new();
            _effects.Add(newChange);
            newChange.apply(this);

            invo.simple(() => { removeChange(newChange._id); }, duration, _id);
        }
        void removeChange(simpleId removeId)
        {

            bool found = false;
            for (int i = _effects.Count - 1; i > -1; i--)
            {
                if (_effects[i]._id == removeId)
                {
                    _effects.RemoveAt(i);
                    found = true;
                    break;
                }
            }

            Debug.LogError("removeChange "+ found);
            if (found is false) UnityEngine.Debug.LogError("NOT FOUND ID TO REMOVE EFFE");
            else refreshGraphics();
        }
        public void refreshGraphics()
        {
            //if (_effects.Count == 0) return;

            resetStartData();

            foreach (var item in _effects)
            {
                item.apply(this);
            }

        }




        public abstract void setColor(Color col);
        public abstract void setSize(Vector2 size);
        public abstract void addSize(Vector2 size);
        public abstract void setRotation(float rotation);
        public abstract void addRotation(float rotation);
        public abstract void addPosition(Vector2 pos);



    }




}