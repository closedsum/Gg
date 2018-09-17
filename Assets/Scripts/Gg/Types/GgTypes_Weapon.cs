namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    [Serializable]
    public struct S_FGgData_Weapon_FireMode
    {
        [SerializeField]
        public S_FCgData_Weapon_FireMode_Firing Firing;
        [SerializeField]
        public S_FCgData_Weapon_FireMode_Animation Animation;
        [SerializeField]
        public S_FCgData_Weapon_FireMode_Aiming Aiming;
        [SerializeField]
        public S_FCgData_Weapon_FireMode_FXs FXs;
        [SerializeField]
        public S_FCgData_Weapon_FireMode_Sounds Sounds;
    }

    public class FGgData_Weapon_FireMode
    {
        public FCgData_Weapon_FireMode_Firing Firing;

        public FCgData_Weapon_FireMode_Animation Animation;

        public FCgData_Weapon_FireMode_Aiming Aiming;

        public FCgData_Weapon_FireMode_FXs FXs;

        public FCgData_Weapon_FireMode_Sounds Sounds;

        public FGgData_Weapon_FireMode()
        {
            Firing = new FCgData_Weapon_FireMode_Firing();
            Animation = new FCgData_Weapon_FireMode_Animation();
            Aiming = new FCgData_Weapon_FireMode_Aiming();
            FXs = new FCgData_Weapon_FireMode_FXs();
            Sounds = new FCgData_Weapon_FireMode_Sounds();
        }
    }
}
