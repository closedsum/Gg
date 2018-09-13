namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public static class EGgTime
    {
        public static readonly FECgTime Update = EMCgTime.Get().Create("Update");
        public static readonly FECgTime Game = EMCgTime.Get().Create("Game");

        public static void Init() { }
    }

    public class MGgGameInstance : MCgGameInstance
    {
        public override void Init()
        {
            // Initialize EnumClassMaps
            EGgTime.Init();
            EGgCoroutineSchedule.Init();

            base.Init();

            GameObject gogs = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gogs.name       = "MGgGameState";
            GameState       = gogs.AddComponent<MGgGameState>();

            GameState.Init();

            GameObject gopc = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gopc.name = "MGgPlayerController";
            PlayerControllers.Add(gopc.AddComponent<MMfPlayerController>());
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}