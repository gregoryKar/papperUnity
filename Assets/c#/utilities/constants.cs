using System;
using System.Collections.Generic;
using UnityEngine;




namespace utils
{


    public class constants : MonoBehaviour
    {
        static constants inst;
        private void Awake() => inst = this;




        public static Color neutralColor = Color.gray;
        public static Color possitiveColor = Color.green;
        public static Color negativeColor = Color.red;

        [SerializeField] Sprite _square;
        public static Sprite square => inst._square;



    }
}