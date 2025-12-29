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


        public enum pointSeperationMethod
        {
            edjesFullStep,
            edjesHalfStep,
            noEdjeStep
        }

        
        
        // example when from 0 to 1 ,   3 points =>
        // 0,0.5,1  or 0.25 , 0.5 , 0.75  or the other with halfEdjeStep

    }
    }