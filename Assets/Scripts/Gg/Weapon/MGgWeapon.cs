namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgWeapon : MCgWeapon
    {
        void Awake()
        {
        }

        // Use this for initialization
        void Start()
        {
        }

        public override void Init()
        {
            base.Init();

            FiringDataFireMode = EGgData_Weapon_FireMode.Firing;
            AnimationDataFireMode = EGgData_Weapon_FireMode.Animation;
            AimingDataFireMode = EGgData_Weapon_FireMode.Aiming;
            SoundsDataFireMode = EGgData_Weapon_FireMode.Sounds;

            CurrentState = EGgWeaponState.Idle;
            LastState    = CurrentState;

            IdleState = EGgWeaponState.Idle;

            PrimaryFireMode = EGgWeaponFireMode.Primary;

            FiringState = EGgWeaponState.Firing;
            FireSound = EGgWeaponSound.Fire;

            ReloadingState = EGgWeaponState.Reloading;

            InitMultiValueMembers();
        }
    }
}
