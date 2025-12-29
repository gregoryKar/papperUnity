


using paper;
using UnityEngine;

namespace smallManagement
{



    public class liftBox : MonoBehaviour
    {


        public PhysicsShape2D _unityShape;
        public Vector2 _size;

        private void Start() {
            managementMain.add(this);
        }



    }



}