
using UnityEngine;
using utils;

namespace paper
{


    public class bodyPart : MonoBehaviour, IKillable
    {

        [SerializeReference]
        public bodyPartAttribute[] _attributes;

        public void init(enemy user)
        {
            user._parts.Add(this);
            foreach (var attribute in _attributes)
            {
                attribute.init(this, user);
            }
        }

        public void kill()
        {
            foreach (var item in _attributes) { mainFunctions.kill(item); }

        }


    }

}