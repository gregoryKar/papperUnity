

using System.Collections.Generic;
using paper;
using Unity.Mathematics;
using UnityEngine;

namespace smallManagement
{





    public class managementMain : MonoBehaviour
    {



        static managementMain instForbidden;
        public static managementMain inst
        {
            get
            {
                if (instForbidden == null)
                    instForbidden = new GameObject("MANAGEMENT MAIN").AddComponent<managementMain>();
                return instForbidden;
            }
        }
        private void Start()
        {
            instForbidden = this;
        }


        List<liftBox> _boxes = new();
        public static void add(liftBox box) => inst._boxes.Add(box);
        public static void remove(liftBox box) => inst._boxes.Remove(box);

        public static liftBox boxThere(Vector2 pos, liftBox ignore = null) => inst.boxThereLocal(pos, ignore);
        liftBox boxThereLocal(Vector2 pos, liftBox ignore = null)
        {

            //bool ignoreEmpty = (ignore == null);  ignoreEmpty &&
            for (int i = 0; i < _boxes.Count; i++)
            {

                if (_boxes[i] == ignore) continue;

                if (math.abs(_boxes[i].transform.position.x - pos.x) < _boxes[i]._size.x / 2f) return _boxes[i];
            }

            return null;
        }




        public gameobjectPool _bulletPool;
        public gameobjectPool _caliberPool;





    }

}