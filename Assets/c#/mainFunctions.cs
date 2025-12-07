

using utils;

namespace paper
{


    public static class mainFunctions
    {

        public static void kill(object item)
        {
            if (item is IHaveId registered) invoManager.killAll(registered.getId());
            if (item is IKillable kilo) kilo.kill();

        }


    }













}