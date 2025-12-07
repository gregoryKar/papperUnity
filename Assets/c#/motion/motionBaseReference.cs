


using UnityEngine;

namespace paper.motion
{


    //: ITrans
    // public abstract Transform getTrans();

    public class MotionBaseReference : motionBase
    {


        public motionData _data;

        public override motionBase createClone(Transform t)
          => _data._motion.createClone(t);


        public override void process(float delta) { }

        //     public override motionBase create(Transform trans) =>
        //    _data._motion.create(trans);


    }



}