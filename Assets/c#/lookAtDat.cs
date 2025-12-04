using UnityEngine;

namespace paper
{



    class lookAtDatClass
    {





        void classTypeComparison(enemyCondition a, enemyCondition b)
        {


            var sameA = new imobilise();
            var sameB = new imobilise();

            //! IT WOULD NOT RETURN TRUE IF ONE WAS THE BASE CLASS

            if (sameA.GetType() == sameB.GetType()) Debug.Log("will give true");
            if (sameA is imobilise && sameB is imobilise) Debug.Log("will give true");

            // var notSameA = new imobilise();
            // var notSameB = new imobilise();



        }


        void testInterfacesLogic(IGraphic grahic)
        {

            //In C#, the . operator (member access) has higher precedence than type cast (IRend).




            (grahic as IRend).getRend();
            ((IRend)grahic).getRend();
            //!(IRend)grahic.getRend();




        }








    }












}