namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    #region "Enums"

    public static class EGgTime
    {
        public static readonly FECgTime Menu = EMCgTime.Get().Create("Menu");
        public static readonly FECgTime Game = EMCgTime.Get().Create("Game");

        public static void Init() { }
    }

    public static class EGgGameInstanceState
    {
        public static readonly FECgGameInstanceState OnBoard = EMCgGameInstanceState.Get().Create("OnBoard");
        public static readonly FECgGameInstanceState Menu = EMCgGameInstanceState.Get().Create("Menu");
        public static readonly FECgGameInstanceState Game = EMCgGameInstanceState.Get().Create("Game");

        public static void Init() { }
    }

    #endregion // Enums

    public class MGgGameInstance : MCgGameInstance
    {
        #region "Data Members"

        public MGgPlayerController Player;

        #endregion // Data Members

        public override void Init()
        {
            // Initialize EnumClassMaps
            EGgGameInstanceState.Init();
            EGgTime.Init();
            EGgCoroutineSchedule.Init();

            CurrentState = EGgGameInstanceState.OnBoard;

            base.Init();

            GameObject gogs = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gogs.name       = "MGgGameState";
            GameState       = gogs.AddComponent<MGgGameState>();

            GameState.Init();

            GameObject gopc = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gopc.name       = "MGgPlayerController";
            PlayerControllers.Add(gopc.AddComponent<MGgPlayerController>());

            Player = (MGgPlayerController)PlayerControllers[0];

            Player.Init();
        }

        // Use this for initialization
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            FCgManager_Time.Get().Update(ECgTime.Update);

            // Run Coroutines from previous frame
            FCgCoroutineScheduler.Get().Update(ECgCoroutineSchedule.Update, FCgManager_Time.Get().GetDeltaTime(ECgTime.Update));

            // OnBoard
            if (CurrentState == EGgGameInstanceState.OnBoard)
                OnUpdate_OnBoard();
            // Menu
            else
            if (CurrentState == EGgGameInstanceState.Menu)
                OnUpdate_Menu();
            // Game
            else
            if (CurrentState == EGgGameInstanceState.Game)
                OnUpdate_Game();
        }

        protected void OnUpdate_OnBoard()
        {
            CurrentState = EGgGameInstanceState.Menu;
        }

        protected void OnUpdate_Menu()
        {
            FCgManager_Time.Get().Update(EGgTime.Menu);

            float deltaTime = FCgManager_Time.Get().GetDeltaTime(EGgTime.Menu);

            // Get Input

        }

        protected void OnUpdate_Game()
        {

        }
    }
}