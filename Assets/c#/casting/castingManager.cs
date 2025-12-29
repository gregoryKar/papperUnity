using System;
using UnityEngine;
using utils;
using utils.math;


namespace paper.casting
{



    public class castingManager : MonoBehaviour
    {

        [SerializeReference] casting _testCasting;
        Transform _castingGraphicFather;


        void Update()
        {

            if (_phase == castingPhase.none)
            {

                if (Input.GetKeyDown(KeyCode.Space)) startTargetPhase();


            }
            else if (_phase == castingPhase.targeting)
            {

                if (Input.GetKeyDown(KeyCode.Mouse0)) exetuceCasting();
                else if (Input.GetKeyDown(KeyCode.Mouse1)) cancelTargetPhase();
                else processTargeting();

            }

        }



        castingPhase _phase;
        enum castingPhase
        {
            none, targeting
        }



        void startTargetPhase()
        {
            _castingGraphicFather = new GameObject("casting graphic").transform;
            var s = _testCasting.getGraphic();
            s.transform.parent = _castingGraphicFather;
            s.transform.localPosition = Vector3.zero;

            _phase = castingPhase.targeting;

        }

        Vector2 _tempPos;//remove later..
        void processTargeting()
        {


            _testCasting._area.processPotition(myFunctions.mousePos(), out Vector2 pos, out bool acceptable);

            _castingGraphicFather.posSameZ(pos);
            _tempPos = pos;




        }

        void killTargetGraphic() => Destroy(_castingGraphicFather.gameObject);

        void cancelTargetPhase()
        {
            killTargetGraphic();
            _phase = castingPhase.none;
        }
        void exetuceCasting()
        {
            killTargetGraphic();
            _testCasting._result.execute(_tempPos);
            _phase = castingPhase.none;

        }


    }






}