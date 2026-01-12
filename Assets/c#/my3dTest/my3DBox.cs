using UnityEngine;

namespace my3dtest
{


    public class my3DBox : MonoBehaviour
    {


        my3DVida[] _vides;

        private void Start()
        {

            _vides = transform.GetComponentsInChildren<my3DVida>();
            foreach (var item in _vides)
            {
                item._onSolved += checkSolved;
            }

        }
        void checkSolved()
        {

            foreach (var item in _vides)
            {
                if (!item._solved)
                    return;
            }

            Debug.Log("All Vida Solved!");

        }



    }


}