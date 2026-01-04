

using UnityEngine;
using utils.math;

namespace my3dtest
{


    public class my3DPressMe : MonoBehaviour
    {

        public bool materialWay;
        public bool gizoWay;
        Renderer r;
        Material originalMat;
        public Material highlightMat;

        void Awake()
        {
            r = GetComponent<Renderer>();
            originalMat = r.material;
        }

        bool highlightForbidden = false;
        bool previousHighlightValue;
        public bool highlight
        {

            get
            {
                return highlightForbidden;
            }
            set
            {
                highlightForbidden = value;
                setHighlight();
                previousHighlightValue = value;
            }

        }
        void setHighlight()
        {

            if (previousHighlightValue == highlight) return;
            if (materialWay)
            {
                r.material = highlight ? highlightMat : originalMat;

            }


        }




        public Vector3 force;
        public int forceRandom;
        public float upForceBase;
        public Vector3 torque;
        public int torqueRandom;
        
        public void pressMe()
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb == null) return;

            Vector3 forceTemp = Vector3.zero;
            forceTemp.x = myRandom.dirPercent(forceTemp.x, forceRandom);
            forceTemp.y = myRandom.dirPercent(forceTemp.y, forceRandom);
            forceTemp.z = myRandom.dirPercent(forceTemp.z, forceRandom);

            forceTemp.y += upForceBase;

            rb.AddForce(forceTemp);

            Vector3 torqueTemp = Vector3.zero;
            torqueTemp.x = myRandom.dirPercent(torque.x, torqueRandom);
            torqueTemp.y = myRandom.dirPercent(torque.y, torqueRandom);
            torqueTemp.z = myRandom.dirPercent(torque.z, torqueRandom);

            rb.AddTorque(torqueTemp);




        }


        void OnDrawGizmos()
        {
            if (gizoWay is false) return;
            if (highlight is false) return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, Vector3.one * 1.2f);
        }



    }

}