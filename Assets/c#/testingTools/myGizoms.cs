

using System.Collections.Generic;
using UnityEngine;
using utils.math;

namespace paper
{




    public class myGizmos : MonoBehaviour
    {


        static myGizmos instForbidden;
        static myGizmos inst
        {
            get
            {
                if (instForbidden == null)
                {
                    var gameObject = new GameObject("myGizmos");
                    instForbidden = gameObject.AddComponent<myGizmos>();
                }
                return instForbidden;
            }

        }

        List<myGizmoLine> _lines = new();
        public static void add(myGizmoLine line) => inst._lines.Add(line);


        void OnDrawGizmos()
        {
            int counter = _lines.Count - 1;
            while (counter > -1 && _lines.Count > 0)
            {

                Gizmos.DrawLine(_lines[counter]._trans.position
                , _lines[counter]._trans.position + (Vector3)_lines[counter]._direction * _lines[counter]._distance);

                if (_lines[counter]._keepAlive is false) _lines.RemoveAt(counter);
                counter--;
            }
        }






    }




}