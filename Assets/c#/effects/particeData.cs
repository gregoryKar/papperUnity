

using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace paper.effects
{




    [CreateAssetMenu(fileName = "particleData", menuName = "A_scriptablo/particleData")]//what are the  `` for ??
    public class particeData : ScriptableObject
    {

        public float _delay;
        public Sprite _sprite;
        public float _size;

        [SerializeReference]
        public graphicChange[] _changes;
        public void create(Vector2 there)
        {

            new particle(this, there);


        }

        [Button]
        public void editCreate()
        {
            if (Application.isPlaying is false) return;
            create(testTool.testPos);

        }

    }

}