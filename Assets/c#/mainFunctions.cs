

using utils;

namespace paper
{


    public static class mainFunctions
    {

        public static void kill(object item)
        {
            if (item is IHaveId registered) registered.getId().killAll();
            if (item is IKillable kilo) kilo.kill();

        }


    }













}