


using System;
using UnityEngine;

namespace paper.attacks
{


    [Serializable]
    public class attackResult
    {
        [SerializeField] string name;
        public void sayName() { Debug.Log("attackResult name is: " + name); }


    }




}