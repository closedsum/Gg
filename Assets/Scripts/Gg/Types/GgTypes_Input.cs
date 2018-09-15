namespace Gg
{
    using CgCore;

    public static class EGgInputAction
    {
        // Game
        public static readonly FECgInputAction MoveForward = EMCgInputAction.Get().Create("MoveForward");
        public static readonly FECgInputAction MoveBackward = EMCgInputAction.Get().Create("MoveBackward");
        public static readonly FECgInputAction Jump = EMCgInputAction.Get().Create("Jump");
        public static readonly FECgInputAction Fire = EMCgInputAction.Get().Create("Fire");
        // GameMenu
        public static readonly FECgInputAction OpenCloseGameMenu = EMCgInputAction.Get().Create("OpenCloseGameMenu");

        public static void Init() { }
    }

    public static class EGgInputActionMap
    {
        public static readonly FECgInputActionMap Menu = EMCgInputActionMap.Get().Create("Menu");
        public static readonly FECgInputActionMap Game = EMCgInputActionMap.Get().Create("Game");
        public static readonly FECgInputActionMap GameMenu = EMCgInputActionMap.Get().Create("GameMenu");
    }

    public static class EGgGameEvent
    {
        // Game
        public static readonly FECgGameEvent StartMoveForward = EMCgGameEvent.Get().Create("StartMoveForward");
        public static readonly FECgGameEvent StopMoveForward = EMCgGameEvent.Get().Create("StopMoveForward");
        public static readonly FECgGameEvent StartMoveBackward = EMCgGameEvent.Get().Create("StartMoveBackward");
        public static readonly FECgGameEvent StopMoveBackward = EMCgGameEvent.Get().Create("StopMoveBackward");
        public static readonly FECgGameEvent StartJump = EMCgGameEvent.Get().Create("StartJump");
        public static readonly FECgGameEvent StopJump = EMCgGameEvent.Get().Create("StopJump");
        public static readonly FECgGameEvent StartFire = EMCgGameEvent.Get().Create("StartFire");
        public static readonly FECgGameEvent StopFire = EMCgGameEvent.Get().Create("StopFire");
        // GameMenu
        public static readonly FECgGameEvent OpenCloseGameMenu = EMCgGameEvent.Get().Create("OpenCloseGameMenu");
    }
}