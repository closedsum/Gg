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

        public FGgManager_Input() : base()
        {
            // Define Actions
            {
                // MoveForward
                DefineInputActionValue(ref MoveForward, EGgInputAction.MoveForward, EGgInputActionMap.Game.Value);
                // MoveBackward
                DefineInputActionValue(ref MoveBackward, EGgInputAction.MoveBackward, EGgInputActionMap.Game.Value);
                // Jump
                DefineInputActionValue(ref Jump, EGgInputAction.Jump, EGgInputActionMap.Game.Value);
                // Fire
                DefineInputActionValue(ref Fire, EGgInputAction.Fire, EGgInputActionMap.Game.Value);
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
                // MoveBackward -> StopMoveBackward
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StopMoveBackward, EGgInputAction.MoveBackward, ECgInputEvent.FirstReleased);
                // Jump -> StartJump
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StartJump, EGgInputAction.Jump, ECgInputEvent.FirstPressed);
                // Jump -> StopJump
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StopJump, EGgInputAction.Jump, ECgInputEvent.FirstReleased);
                // Fire -> StartFire
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StartFire, EGgInputAction.Fire, ECgInputEvent.FirstPressed);
                // Fire -> StopFire
            CreateGameEventDefinitionSimple(GameEventDefinitions_Game, EGgGameEvent.StopFire, EGgInputAction.Fire, ECgInputEvent.FirstReleased);
        }

        protected override void BindInputs()
        {
            base.BindInputs();

            // MoveForward
            BindInputAction(KeyCode.D, MoveForward);
            // MoveBackward
            BindInputAction(KeyCode.A, MoveBackward);
            // Jump
            BindInputAction(KeyCode.W, Jump);
            // Fire
            BindInputAction(KeyCode.Space, Fire);
        }
    }
}
