namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class FGgSnapShot_Player : FCgSnapShot_Player
    {
        #region "Data Members"

        public Vector3 CurrentMousePosition;

        #endregion // Data Members

        public FGgSnapShot_Player() : base()
        {
        }

        public override void Reset()
        {
            base.Reset();

            CurrentMousePosition = Vector3.zero;
        }
    }


    public class MGgPlayerState : MCgPlayerState
    {
        public override void Init()
        {
            base.Init();
        }
    }
}