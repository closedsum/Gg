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
        #region "Constants"

        public static readonly int AUTO_ASSIGN_CONTROLLER = -1;
        public static readonly int INDEX_NONE = -1;

        #endregion // Constants

        #region "Data Members"

        // TODO: Move into GameState
        [FCgReadOnly]
        public MGgPlayerController Player;

        #endregion // Data Members

        public override void Init()
        {
            // Initialize EnumClassMaps
            FCgEnumClassLinker.Init();

            CurrentState = EGgGameInstanceState.OnBoard;

            base.Init();

            // TODO: Look into streaming between Menu and Game

            GameObject gogs = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gogs.name       = "MGgGameState";
            GameState       = gogs.AddComponent<MGgGameState>();

            GameState.Init();

            // TODO: Move into GameState
            GameObject gopc = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gopc.name       = "MGgPlayerController";
            PlayerControllers.Add(gopc.AddComponent<MGgPlayerController>());

            Player = (MGgPlayerController)PlayerControllers[0];

            Player.Index = 0;
            Player.Init();

            // TODO: Move to OnBoarding in Game
            SetupExisting_Pawns();
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
            FCgManager_Time.Get().Update(EGgTime.Game);

            float deltaTime = FCgManager_Time.Get().GetDeltaTime(EGgTime.Game);

            GameState.OnUpdate(deltaTime);
        }

        protected void SetupExisting_Pawns()
        {
            // Players
            MGgPawn[] pawns = FindObjectsOfType<MGgPawn>();

            foreach (MGgPawn p in pawns)
            {
                // Auto Possess
                if (p.bAutoPossess)
                {
                    bool possessed = false;

                    // Auto Assign Controller
                    if (p.ControllerIndex <= AUTO_ASSIGN_CONTROLLER)
                    {
                        foreach (MCgPlayerController pc in PlayerControllers)
                        {
                            if (pc.Pawn != null)
                            {
                                pc.Possess(p);

                                possessed = true;
                                break;
                            }
                        }

                        if (!possessed)
                        {
                            FCgDebug.LogWarning("MGgGameInstance.AutoPossessPawns: Failed to AutoPossess Pawn: " + p.name + " of type: " + p.GetType().ToString());
                        }
                    }
                    // Search for controller with matching index
                    else
                    {
                        if (p.ControllerIndex >= PlayerControllers.Count)
                        {
                            FCgDebug.LogWarning("MGgGameInstance.AutoPossessPawns: Failed to AutoPossess Pawn: " + p.name + " of type: " + p.GetType().ToString() + ". No PlayerController found with index: " + p.ControllerIndex);
                        }
                        else
                        {
                            int index = p.ControllerIndex;

                            if (PlayerControllers[index].Pawn != null)
                            {
                                FCgDebug.LogWarning("MGgGameInstance.AutoPossessPawns: Failed to AutoPossess Pawn: " + p.name + " of type: " + p.GetType().ToString());
                                FCgDebug.LogWarning("MGgGameInstance.AutoPossessPawns: PlayerController with index: " + index + " is already possessing Pawn: " + PlayerControllers[index].Pawn.name);
                            }
                            else
                            {
                                PlayerControllers[index].Possess(p);
                            }
                        }
                    }
                }

                p.bPlacedInWorld = true;

                p.Init();
            }
        }
    }
}