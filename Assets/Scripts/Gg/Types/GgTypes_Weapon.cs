namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public static class EGgWeaponState
    {
        public static readonly FECgWeaponState Idle = EMCgWeaponState.Get().Create("Idle");
        public static readonly FECgWeaponState Firing = EMCgWeaponState.Get().Create("Firing");
        public static readonly FECgWeaponState Reloading = EMCgWeaponState.Get().Create("Reloading");

        public static void Init() { }
    }

    public static class EGgWeaponSlot
    {
        public static readonly FECgWeaponSlot Weapon1 = EMCgWeaponSlot.Get().Create("Weapon1");

        public static void Init() { }
    }

    public static class EGgWeaponFireMode
    {
        public static readonly FECgWeaponFireMode Primary = EMCgWeaponFireMode.Get().Create("Primary");

        public static void Init() { }
    }

    public static class EGgWeaponSound
    {
        public static readonly FECgWeaponSound Fire = EMCgWeaponSound.Get().Create("Fire");

        public static void Init() { }
    }

    public static class EGgData_Weapon_FireMode
    {
        public static readonly FECgData_Weapon_FireMode Firing = EMCgData_Weapon_FireMode.Get().Create("Firing");
        public static readonly FECgData_Weapon_FireMode Animation = EMCgData_Weapon_FireMode.Get().Create("Animation");
        public static readonly FECgData_Weapon_FireMode Aiming = EMCgData_Weapon_FireMode.Get().Create("Aiming");
        public static readonly FECgData_Weapon_FireMode FXs = EMCgData_Weapon_FireMode.Get().Create("FXs");
        public static readonly FECgData_Weapon_FireMode Sounds = EMCgData_Weapon_FireMode.Get().Create("Sounds");

        public static void Init() { }
    }

    public static class EGgWeaponGrip
    {
        public static readonly FECgWeaponGrip Default = EMCgWeaponGrip.Get().Create("Default");

        public static void Init() { }
    }

    public static class EGgWeaponOwner
    {
        public static readonly FECgWeaponOwner Character = EMCgWeaponOwner.Get().Create("Character");

        public static void Init() { }
    }

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

    public class FGgData_Weapon_FireMode : FCgData_Weapon_FireMode
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
