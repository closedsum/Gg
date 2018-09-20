namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    #region "Enums"


    #endregion // Enums

    public class MGgGameState : MCgGameState
    {

        public override void Init()
        {
            base.Init();


        }

        public override void OnUpdate(float deltaTime)
        {
            MGgGameInstance gameInstance = MCgGameInstance.Get<MGgGameInstance>();



            foreach (MCgPawn p in gameInstance.PlayerPawns)
            {

            }
        }
    }
}