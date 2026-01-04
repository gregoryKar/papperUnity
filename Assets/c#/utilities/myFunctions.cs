





using System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using utils.math;
//using utils.colliders;

namespace utils
{


    public static class myFunctions
    {


        public static Vector2 mousePos()
        {

            Vector2 pos = Input.mousePosition;
            return Camera.main.ScreenToWorldPoint(pos);

        }



        public static float[] spreadPoints(int count
        , constants.pointSeperationMethod method
        , int randomPercent = 0
         )
        {

            float[] values = new float[count];

            float step = 0, startStep = 0;

            switch (method)
            {
                case constants.pointSeperationMethod.edjesFullStep:
                    step = 1f / (values.Length + 1);
                    startStep = step;
                    break;

                case constants.pointSeperationMethod.edjesHalfStep:
                    step = 1f / (values.Length);
                    startStep = step / 2f;
                    break;

                case constants.pointSeperationMethod.noEdjeStep:
                    if (values.Length == 1)
                    { Debug.LogError("DIVISSION 0 ERROR"); return null; }

                    step = 1f / (values.Length - 1);
                    startStep = 0f;
                    break;


            }



            for (int i = 0; i < values.Length; i++)
            {
                //float steps = values.Length + 1;

                values[i] = startStep + i * step; /// steps;
                values[i] += step * (myRandom.dir(randomPercent) / 100f);
            }

            return values;






        }

        public static void drawCube(Vector3 pos, float size, Color col = default, float duration = -1)
        {

            if (col == default) col = Color.white;
            if (duration < 0) duration = 0.03f;

            void draw(int2 startPos, Vector2 dir)
            {
                Vector3 tempStart = pos + new Vector3(startPos.x, startPos.y, 0) * size / 2f;
                Vector3 tempEnd = tempStart + (Vector3)dir * size;
                Debug.DrawLine(tempStart, tempEnd, col, duration);
            }

            draw(new int2(-1, 1), Vector2.right);
            draw(new int2(1, 1), Vector2.down);
            draw(new int2(1, -1), Vector2.left);
            draw(new int2(-1, -1), Vector2.up);

        }

        public static void drawCube(Transform trans, float size, Color col = default, float duration = -1) => drawCube(trans.position, size, col, duration);





    }
}