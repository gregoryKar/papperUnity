
using UnityEngine;
using System;


//! A SINGLE MENTION SO FAR OF ENGINE TIME VARIABLE
//! ALL OTHER GET TO THIS .. YOU WANT TO CHANGE IT 
//! CHANGE ONE LINE AND DONE .. .. 

namespace utils
{

    public class myTime : IComparable<myTime>
    {

        public myTime(float after = 0) { _time = Time.timeSinceLevelLoad; }

        float _time;//! FLOAT DECIDED

        public static float now => Time.timeSinceLevelLoad;


        public void setNow() => _time = now;
        public void setNow(float after) => _time = now + after;


        public bool passed(float time) => time > now;
        public static bool passedGlobal(float time) => time > now;


        //public bool before(myTime other) => _time < other._time;
        public static void sayTime() => Debug.Log("NOW=" + now);

        public int CompareTo(myTime other)
        {
            return _time.CompareTo(other._time);
        }








    }

}