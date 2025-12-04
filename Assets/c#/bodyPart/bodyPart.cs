
using UnityEngine;

namespace paper
{


    public class bodyPart : MonoBehaviour
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

    }

}