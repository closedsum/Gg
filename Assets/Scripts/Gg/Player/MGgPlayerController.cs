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
        #region "Constants"

        public static readonly byte EGG_GAME_EVENT_GAME_MAX = (byte)EGgGameEvent_Game.MAX;

        #endregion // Constants

        #region "Data Members"

        public MGgPawn Pawn;

        #endregion // Data Members

        public override void Init()
        {
            base.Init();
        }

        // Use this for initialization
        void Start()
        {
            Init();

            // PlayerState
            GameObject gops = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gops.name       = "MGgPlayerState";
            PlayerState     = gops.AddComponent<MGgPlayerState>();

            PlayerState.Init();

            // Manager Input
            Manager_Input = new FGgManager_Input();

            Manager_Input.CurrentInputActionMap = EGgInputActionMap.Game.Value;

            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StartMoveForward
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StopMoveForward
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StartMoveBackward
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StopMoveBackward
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StartJump
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StopJump
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StartFire
            GameEventInfoPriorityList.Add(new FCgGameEventInfo()); // StopFire
        }

        protected override void PostProcessInput(float deltaTime)
        {
            base.PostProcessInput(deltaTime);

            FGgManager_Input manager = (FGgManager_Input)Manager_Input;

            manager.PostProcessInput(deltaTime);

            FCgInputFrame inputFrame = manager.CurrentInputFrame;
            // Reset PriorityList
            foreach (FCgGameEventInfo info in GameEventInfoPriorityList)
            {
                info.Reset();
            }

            // Process GameEventDefinitions
            foreach (FCgGameEventDefinition def in manager.GameEventDefinitions_Game)
            {
                def.Sentence.ProcessInput(inputFrame);

                if (def.Sentence.Completed)
                {
                    EGgGameEvent_Game e                      = FEGgGameEvent_Game_Helper.ToType(def.Event);
                    GameEventInfoPriorityList[(byte)e].Event = def.Event;
                }
            }
            // Process QueuedGameEvents
            foreach (FCgGameEventInfo info in manager.QueuedGameEventInfosForNextFrame)
            {
                FECgGameEvent _event = info.Event;
                EGgGameEvent_Game e  = FEGgGameEvent_Game_Helper.ToType(_event);

                GameEventInfoPriorityList[(byte)e].Event = _event;
            }

            // Add events to Local SnapShot
            MGgPlayerState myPlayerState = (MGgPlayerState)PlayerState;
            //myPlayerState.CurrentSnapShot.Reset();

            for (byte i = 0; i < EGG_GAME_EVENT_GAME_MAX; ++i)
            {
                FCgGameEventInfo info = GameEventInfoPriorityList[i];

                if (!info.IsValid())
                   continue;

               myPlayerState.CurrentSnapShot.AddGameEvent(info.Event);
            }

            FGgSnapShot_Player snapShot   = (FGgSnapShot_Player)myPlayerState.CurrentSnapShot;
            snapShot.CurrentMousePosition = manager.CurrentMousePosition;

            //myPlayerState.ProcessCurrentLocalSnapShot(deltaTime);

            manager.ClearQueuedGameEvents();
        }
    }
}
