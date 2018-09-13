namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    #region "Enums"

    public enum EGgGameEvent_Game : byte
    {
        StartMoveForward,
        StopMoveForward,
        StartMoveBackward,
        StopMoveBackward,
        StartJump,
        StopJump,
        StartFire,
        StopFire,
        MAX,
    }

    public static class FEGgGameEvent_Game_Helper
    {
        public static EGgGameEvent_Game ToType(FECgGameEvent e)
        {
            if (e == EGgGameEvent.StartMoveForward) return EGgGameEvent_Game.StartMoveForward;
            if (e == EGgGameEvent.StopMoveForward) return EGgGameEvent_Game.StopMoveForward;
            if (e == EGgGameEvent.StartMoveBackward) return EGgGameEvent_Game.StartMoveBackward;
            if (e == EGgGameEvent.StopMoveBackward) return EGgGameEvent_Game.StopMoveBackward;
            if (e == EGgGameEvent.StartJump) return EGgGameEvent_Game.StartJump;
            if (e == EGgGameEvent.StopJump) return EGgGameEvent_Game.StopJump;
            if (e == EGgGameEvent.StartFire) return EGgGameEvent_Game.StartFire;
            if (e == EGgGameEvent.StopFire) return EGgGameEvent_Game.StopFire;
            return EGgGameEvent_Game.MAX;
        }
    }

    #endregion // Enums

    public class MGgPlayerController : MCgPlayerController
    {
    }
}
