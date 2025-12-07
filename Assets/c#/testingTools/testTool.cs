
using paper.projectiles;
using UnityEngine;


namespace paper
{


    public class testTool : MonoBehaviour
    {


        static testTool _inst;
        private void Awake()
        {
            if (_inst != null)
            {
                Debug.Log("DOUBLE testTool name == " + name);
                return;
            }
            _inst = this;
        }

        private void Start()
        {
            _testItem.init(transform);
        }

        [SerializeReference]
        public testAttributeBase _testItem;

        public static Vector3 testPos => _inst.transform.position;
        public static Vector3 testDir => _inst.transform.up;



    }

}
