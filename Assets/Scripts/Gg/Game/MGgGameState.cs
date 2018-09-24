namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    #region "Enums"

    public static class EGgGameState
    {
        public static void Init() { }
    }

    #endregion // Enums

    public class MGgGameState : MCgGameState
    {
        #region "Data Members"

        [FCgReadOnly]
        public MGgPlayerController Player;

        #endregion // Data Members

        public override void Init()
        {
            base.Init();

            GameObject gopc = MonoBehaviour.Instantiate(FCgManager_Prefab.Get().EmptyGameObject);
            gopc.name = "MGgPlayerController";
            PlayerControllers.Add(gopc.AddComponent<MGgPlayerController>());

            Player = (MGgPlayerController)PlayerControllers[0];

            Player.Index = 0;
            Player.Init();

            ICgManager_Projectile.Init(typeof(FCgManager_Projectile));
            ICgManager_Projectile.Get().TypeMap.Add(EGgProjectileType.Bullet, typeof(MGgProjectile));
            ICgManager_Projectile.Get().CreatePool(EGgProjectileType.Bullet, 10);
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (MCgPawn p in PlayerPawns)
            {
                p.OnUpdate(deltaTime);
            }
        }
    }
}