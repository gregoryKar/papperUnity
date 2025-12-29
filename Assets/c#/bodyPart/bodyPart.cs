
using UnityEngine;
using utils;

namespace paper
{


    public class bodyPart : MonoBehaviour, IKillable, ITrans
    {

        [SerializeReference]
        public partAttribute[] _attributes;
        enemy _user;

        public Transform getTrans() => transform;


        public virtual void init(enemy user)
        {
            _user = user;
            user._parts.Add(this);
            foreach (var attribute in _attributes)
            {
                attribute.init(this, user);
            }
        }

        public void kill()
        {
            
            foreach (var item in _attributes)
            {
                mainFunctions.kill(item);
            }

        }
        public void killIndependant()
        {

            _user.removePart(this);
            kill();
            gameObject.SetActive(false);


        }



        public void invokeEvent(enemy enm, enemyEventBase enmEvent)
        {

            foreach (var item in _attributes)
            {
                //Debug.LogError("death partEventListener in ALL attributs");
                //Debug.Log(item.GetType());
                if (item is partEventListener listener)
                {
                    //Debug.LogError("death partEventListener FOUND");
                    //Debug.LogError("found listener");

                    listener.invoke(this, enm, enmEvent);


                }
            }
        }

    }

}