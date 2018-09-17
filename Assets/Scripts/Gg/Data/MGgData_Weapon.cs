namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;

    using CgCore;

    public class MGgData_Weapon : MCgData_ProjectileWeapon
    {
        #region "Stats"

        [SerializeField]
        public S_FGgData_Weapon_FireMode S_FireMode;
        [NonSerialized]
        public FGgData_Weapon_FireMode FireMode;

        #endregion // Stats

    }
}
