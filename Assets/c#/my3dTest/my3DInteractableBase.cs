

using UnityEngine;
using UnityEngine.Events;
using utils;


namespace my3dtest
{


    public class my3DInteractableBase : MonoBehaviour
    {


        public bool _interactable = true;

        public void lookAt()
        {
            if (!_interactable) return;
            onLookAt();
        }
        public void lookAway()
        {
            if (!_interactable) return;
            onLookAway();
        }
        public void press()
        {
            if (!_interactable) return;
            onPress();
        }
        public void hold()
        {
            if (!_interactable) return;
            onHold();
        }



        protected virtual void onLookAt() { }
        protected virtual void onLookAway() { }
        protected virtual void onPress() { }
        protected virtual void onHold() { }

    }

}