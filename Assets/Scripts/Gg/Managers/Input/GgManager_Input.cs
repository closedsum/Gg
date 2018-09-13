namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class FGgManager_Input : FCgManager_Input
    {
        #region "Data Members"

            #region "Actions"

        public FCgInput_Action MoveForward;
        public FCgInput_Action MoveBackward;
        public FCgInput_Action Jump;
        public FCgInput_Action Fire;

        #endregion // Actions

        #region "Game Events"

        public List<FCgGameEventDefinition> GameEventDefinitions_Game;

            #endregion // Game Events

        #endregion // Data Members

        public FMtManager_Input() : base()
        {
            // Define Actions
            {
                // MoveForward
                DefineInputActionValue(ref MoveForward, EGgInputAction.MoveForward, EGgInputActionMap.Game.Value);
            }

            // Define GameEvent Definitions
            SetupGameEventDefinitions_Game();

            BindInputs();
        }

        private void SetupGameEventDefinitions_Game()
        {
            GameEventDefinitions_Game = new List<FCgGameEventDefinition>();

            // Definitions, GameEvent, Action, Event
                // MoveForward -> StartMoveForward
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StartMoveForward, EGgInputAction.MoveForward, ECgInputEvent.FirstPressed);
                // MoveForward -> StopMoveForward
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StopMoveForward, EGgInputAction.MoveForward, ECgInputEvent.FirstReleased);
                // MoveBackward -> StartMoveBackward
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StartMoveBackward, EGgInputAction.MoveBackward, ECgInputEvent.FirstPressed);
        }

        protected override void BindInputs()
        {
            base.BindInputs();

            // MoveForward
            BindInputAction(KeyCode.D, MoveForward);
        }
    }
}
