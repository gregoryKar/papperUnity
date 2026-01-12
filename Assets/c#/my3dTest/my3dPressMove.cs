

using UnityEngine;

namespace my3dtest
{




    public class my3dPressMove : my3DInteractableBase
    {


        [SerializeField] Vector3 _moveValue;
        bool _moved;

        protected override void onPress()
        {
            if(_moved)return;
            _moved = true;

            transform.position += _moveValue;
        }



    }
}