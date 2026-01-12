using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using utils;
using utils.math;

namespace my3dtest
{


    public class my3dBillboard : MonoBehaviour
    {


        public Transform _limitA, _limitB;

        public float _pointDistance = 1f;
        public int _minAngle;
        public bool _isSeen;
        public float[] _angles;
        public Vector2[] _points;
        private void checkIfSeen()
        {
            bool tesmpSeen = false;


            // Vector3 dir = my3DController._inst.transform.position - transform.//position;
            //dir.y = 0;
            //dir.Normalize();

            int pointCount = (Vector3.Distance(_limitA.Vec3D_2D(), _limitB.Vec3D_2D()) / _pointDistance).round();
            pointCount = myMath.clamp(pointCount, 1, 100);
            _points = new Vector2[pointCount];
            _angles = new float[pointCount];

            for (int i = 0; i < pointCount - 1; i++)
            {
                float t = (float)i / (pointCount - 1);
                _points[i] = Vector2.Lerp(_limitA.Vec3D_2D(), _limitB.Vec3D_2D(), t);
            }

            //Vector3 charahterDir = my3DController._inst.transform.forward;

            Vector2 charachter2D = my3DController._inst.transform.Vec3D_2D();
            //new Vector2(charahterDir.x, charahterDir.z).normalized;

            Vector2 playerLookDir = my3DController._inst.transform.forward.Vec3D_2D().normalized;
            float playerLookAngle = Mathf.Atan2(playerLookDir.y, playerLookDir.x) * Mathf.Rad2Deg - 90;

            for (int i = 0; i < pointCount - 1; i++)
            {



                Vector2 dir = (_points[i] - charachter2D).normalized;
                //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                _angles[i] = Vector2.Angle(dir, playerLookDir);
                if (_angles[i] < _minAngle)
                {
                    tesmpSeen = true;//_isSeen = true;
                    //return;
                }
            }

            if (tesmpSeen != _isSeen) initiateRender();
            _isSeen = tesmpSeen;


            // float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

            // float minAngle = Mathf.Atan2(_limitA.position.x - transform.position.x, _limitA.position.z - transform.position.z) * Mathf.Rad2Deg;
            // float maxAngle = Mathf.Atan2(_limitB.position.x - transform.position.x, _limitB.position.z - transform.position.z) * Mathf.Rad2Deg;

            // angle = Mathf.Clamp(angle, minAngle, maxAngle);

            // transform.rotation = Quaternion.Euler(0, angle, 0);
        }




        private void Start()
        {

            invo.infinite(checkIfSeen, _checkSeenDelay);


            _id = new simpleId();

            _textHolder = _builboardText3D.text;
        }

        void initiateRender()
        {
            invoManager.killAll(_id);
            _builboardText3D.text = "";
            _textCounter = 0;
            invo.repeat(renderTextLetterByLetter, _textDelay, _textHolder.Length, _id, startDelay: _renderStartDelay);

        }
        void renderTextLetterByLetter()
        {
            _textCounter++;
            _builboardText3D.text = _textHolder.Substring(0, _textCounter);
            if (_textCounter > _textHolder.Length) return;


        }

        public float _textDelay, _checkSeenDelay, _renderStartDelay;
        public TMPro.TextMeshPro _builboardText3D;
      //  public TMPro.TextMeshProUGUI _builboardText;
        string _textHolder;
        int _textCounter;
        myId _id;


    }


}