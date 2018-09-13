namespace Gg
{
    using CgCore;

    public static class EGgCoroutineSchedule
    {
        public static readonly FECgCoroutineSchedule Game = EMCgCoroutineSchedule.Get().Create("Game");

        public static void Init()
        {
            ECgCoroutineSchedule.Init();
        }
    }
}