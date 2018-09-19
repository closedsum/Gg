namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif // UNITY_EDITOR

    using CgCore;

    public class MGgData_Weapon : MCgData_ProjectileWeapon
    {
        #region "Stats"

        [SerializeField]
        public S_FGgData_Weapon_FireMode S_FireMode;
        [NonSerialized]
        public FGgData_Weapon_FireMode FireMode;

        public override FCgData_Weapon_FireMode GetFireModeClass(FECgWeaponFireMode fireMode) { return FireMode; }

        public override bool UseFakeProjectile(FECgWeaponFireMode fireMode)
        {
            return FireMode.Firing.bUseFake;
        }

        public override MCgData_Projectile GetData_Projectile(FECgWeaponFireMode fireMode, bool isCharged = false)
        {
            return isCharged ? FireMode.Firing.ChargeData.Get() : FireMode.Firing.Data.Get();
        }

        public override string GetMuzzleBone(FECgWeaponFireMode fireMode, int index = 0)
        {
            return FireMode.FXs.GetMuzzleBone(index);
        }

        [SerializeField]
        public int MaxAmmo;

        public override string GetMaxAmmoMemberName() { return "MaxAmmo"; }

        public override int GetMaxAmmo()
        {
            return MaxAmmo;
        }

        /** Flag for allowing the recharging of ammo over time */
        [SerializeField]
        public bool bRechargeAmmo;
        /** Flag for allowing the recharging of ammo over time */
        [SerializeField]
        public bool bRechargeAmmoDuringFire;

        /** Time after firing until recharge starts */
        [SerializeField]
        public float RechargeStartupDelay;

        public override string GetRechargeStartupDelayMemberName() { return "RechargeStartupDelay"; }
        public override float GetRechargeStartupDelay(){ return RechargeStartupDelay; }

        /** Time to recharge / refresh 1 ammo */
        [SerializeField]
        public float RechargeSecondsPerAmmo;

        public override string GetRechargeSecondsPerAmmoMemberName() { return "RechargeSecondsPerAmmo"; }
        public override float GetRechargeSecondsPerAmmo(){ return RechargeSecondsPerAmmo; }

        [SerializeField]
        public float ReloadTime;

        public override string GetReloadTimeMemberName() { return "ReloadTime"; }
        public override float GetReloadTime(){ return ReloadTime; }

        [SerializeField]
        public float EquipTime;

        #endregion // Stats

        #region "Mesh"

        [SerializeField]
        public bool bMesh;

        public override bool UseMesh()
        {
            return bMesh;
        }

        [SerializeField]
        public S_FCgMesh S__Mesh;
        [NonSerialized]
        public FCgMesh _Mesh;

        public override Mesh GetMesh()
        {
            return _Mesh.Get();
        }

        #endregion // Mesh

        #region "Anims"

        #endregion // Anims

        #region "FX"

        #endregion // FX

        #region "Sounds"

        #endregion // Sounds

        public override void Init()
        {
#if UNITY_EDITOR
            // FireMode
            {
                // Aiming
                {
                    // bFireOnRelease
                    FireMode.Firing.bFireOnRelease = S_FireMode.Firing.bFireOnRelease;
                    // bChargeFire
                    FireMode.Firing.bChargeFire = S_FireMode.Firing.bChargeFire;
                    // MaxChargeFireTime
                    FireMode.Firing.MaxChargeFireTime = S_FireMode.Firing.MaxChargeFireTime;
                    // ForceReleaseChargeFireTime
                    FireMode.Firing.ForceReleaseChargeFireTime = S_FireMode.Firing.ForceReleaseChargeFireTime;
                    // ChargeFireDamageMultiplier
                    FireMode.Firing.ChargeFireDamageMultiplier = S_FireMode.Firing.ChargeFireDamageMultiplier;
                    // ChargeFireSpeedMultiplier
                    FireMode.Firing.ChargeFireSpeedMultiplier = S_FireMode.Firing.ChargeFireSpeedMultiplier;
                    // bFullAuto
                    FireMode.Firing.bFullAuto = S_FireMode.Firing.bFullAuto;
                    // ProjectilesPerShot
                    FireMode.Firing.ProjectilesPerShot = S_FireMode.Firing.ProjectilesPerShot;
                    // TimeBetweenProjectilesPerShot
                    FireMode.Firing.TimeBetweenProjectilesPerShot = S_FireMode.Firing.TimeBetweenProjectilesPerShot;
                    // TimeBetweenShots
                    FireMode.Firing.TimeBetweenShots = S_FireMode.Firing.TimeBetweenShots;
                    // TimeBetweenAutoShots
                    FireMode.Firing.TimeBetweenAutoShots = S_FireMode.Firing.TimeBetweenAutoShots;
                    // bHitscan
                    FireMode.Firing.bHitscan = S_FireMode.Firing.bHitscan;
                    // bHitscanUseRadius
                    FireMode.Firing.bHitscanUseRadius = S_FireMode.Firing.bHitscanUseRadius;
                    // bHitscanSimulateProjectileDuration
                    FireMode.Firing.bHitscanSimulateProjectileDuration = S_FireMode.Firing.bHitscanSimulateProjectileDuration;
                    // ObstaclePenetrations
                    FireMode.Firing.ObstaclePenetrations = S_FireMode.Firing.ObstaclePenetrations;
                    // PawnPenetrations
                    FireMode.Firing.PawnPenetrations = S_FireMode.Firing.PawnPenetrations;
                    // LocationDamageModifiers
                    if (S_FireMode.Firing.LocationDamageModifiers != null)
                    {
                        int count = S_FireMode.Firing.LocationDamageModifiers.Count;

                        for (int i = 0; i < count; ++i)
                        {
                            FireMode.Firing.LocationDamageModifiers.Add(new FCgLocationDamageModifier());
                            FireMode.Firing.LocationDamageModifiers[i].Bone       = S_FireMode.Firing.LocationDamageModifiers[i].Bone;
                            FireMode.Firing.LocationDamageModifiers[i].Multiplier = S_FireMode.Firing.LocationDamageModifiers[i].Multiplier;
                        }
                    }
                    // bUseFake
                    FireMode.Firing.bUseFake = S_FireMode.Firing.bUseFake;
                    // Data
                    {
                        MCgData_Projectile data = AssetDatabase.LoadAssetAtPath<MCgData_Projectile>(S_FireMode.Firing.Data.Data.Path);
                        FireMode.Firing.Data.Data.SetAsset(data);
                    }
                    // ChargeData
                    {
                        MCgData_Projectile data = AssetDatabase.LoadAssetAtPath<MCgData_Projectile>(S_FireMode.Firing.ChargeData.Data.Path);
                        FireMode.Firing.ChargeData.Data.SetAsset(data);
                    }
                }
                // Animation
                {
                    // bLoopFireAnim
                    FireMode.Animation.bLoopFireAnim = S_FireMode.Animation.bLoopFireAnim;
                    // FireAnim
                    FireMode.Animation.FireAnim = S_FireMode.Animation.FireAnim;
                    // bScaleFireAnim
                    FireMode.Animation.bScaleFireAnim = S_FireMode.Animation.bScaleFireAnim;
                }
                // Aiming
                {
                    // bHoming
                    FireMode.Aiming.bHoming = S_FireMode.Aiming.bHoming;
                    // HomingAccelerationMagnitude
                    FireMode.Aiming.HomingAccelerationMagnitude = S_FireMode.Aiming.HomingAccelerationMagnitude;
                    // bSpread
                    FireMode.Aiming.bSpread = S_FireMode.Aiming.bSpread;
                    // MinSpread
                    FireMode.Aiming.MinSpread = S_FireMode.Aiming.MinSpread;
                    // MaxSpread
                    FireMode.Aiming.MaxSpread = S_FireMode.Aiming.MaxSpread;
                    // SpreadAddedPerShot
                    FireMode.Aiming.SpreadAddedPerShot = S_FireMode.Aiming.SpreadAddedPerShot;
                    // SpreadRecoveryRate
                    FireMode.Aiming.SpreadRecoveryRate = S_FireMode.Aiming.SpreadRecoveryRate;
                    // FiringSpreadRecoveryDelay
                    FireMode.Aiming.FiringSpreadRecoveryDelay = S_FireMode.Aiming.FiringSpreadRecoveryDelay;
                    // MovingSpreadBonus
                    FireMode.Aiming.MovingSpreadBonus = S_FireMode.Aiming.MovingSpreadBonus;
                }
                // FXs
                {
                    // MuzzleFXs
                    if (S_FireMode.FXs.MuzzleFXs != null)
                    {
                        int count = S_FireMode.FXs.MuzzleFXs.Count;

                        for (int i = 0; i < count; ++i)
                        {
                            FireMode.FXs.MuzzleFXs.Add(new FCgFxElement());
                            FireMode.FXs.MuzzleFXs[i].Particle = S_FireMode.FXs.MuzzleFXs[i].Particle;
                            FireMode.FXs.MuzzleFXs[i].Particle_LoadFlags = S_FireMode.FXs.MuzzleFXs[i].Particle_LoadFlags;
                            FireMode.FXs.MuzzleFXs[i].Priority = S_FireMode.FXs.MuzzleFXs[i].Priority;
                            FireMode.FXs.MuzzleFXs[i].LifeTime = S_FireMode.FXs.MuzzleFXs[i].LifeTime;
                            FireMode.FXs.MuzzleFXs[i].DeathTime = S_FireMode.FXs.MuzzleFXs[i].DeathTime;
                            FireMode.FXs.MuzzleFXs[i].Scale = S_FireMode.FXs.MuzzleFXs[i].Scale;
                            FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance1P = S_FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance1P;
                            FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance1PSq = S_FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance1PSq;
                            FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance3P = S_FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance3P;
                            FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance3PSq = S_FireMode.FXs.MuzzleFXs[i].DrawDistances.Distance3PSq;
                            FireMode.FXs.MuzzleFXs[i].Bone = S_FireMode.FXs.MuzzleFXs[i].Bone;
                            FireMode.FXs.MuzzleFXs[i].Location = S_FireMode.FXs.MuzzleFXs[i].Location;
                            FireMode.FXs.MuzzleFXs[i].Rotation = S_FireMode.FXs.MuzzleFXs[i].Rotation;
                        }
                    }
                }
                // Sounds
                {
                    // FireSound
                    FireMode.Sounds.FireSound.Sound = S_FireMode.Sounds.FireSound.Sound;
                    FireMode.Sounds.FireSound.Sound_LoadFlags = S_FireMode.Sounds.FireSound.Sound_LoadFlags;
                    FireMode.Sounds.FireSound.SoundType = EMCgSoundType.Get().GetSafeEnum(S_FireMode.Sounds.FireSound.SoundType.name);
                    FireMode.Sounds.FireSound.Priority = S_FireMode.Sounds.FireSound.Priority;
                    FireMode.Sounds.FireSound.bSpatialize = S_FireMode.Sounds.FireSound.bSpatialize;
                    FireMode.Sounds.FireSound.Duration = S_FireMode.Sounds.FireSound.Duration;
                    FireMode.Sounds.FireSound.bLooping = S_FireMode.Sounds.FireSound.bLooping;
                    FireMode.Sounds.FireSound.VolumeMultiplier = S_FireMode.Sounds.FireSound.VolumeMultiplier;
                    FireMode.Sounds.FireSound.PitchMultiplier = S_FireMode.Sounds.FireSound.PitchMultiplier;
                    FireMode.Sounds.FireSound.Bone = S_FireMode.Sounds.FireSound.Bone;
                    // bLoopFireSound
                    FireMode.Sounds.bLoopFireSound = S_FireMode.Sounds.bLoopFireSound;
                    // FireLoopSound
                    FireMode.Sounds.FireLoopSound.Sound = S_FireMode.Sounds.FireLoopSound.Sound;
                    FireMode.Sounds.FireLoopSound.Sound_LoadFlags = S_FireMode.Sounds.FireLoopSound.Sound_LoadFlags;
                    FireMode.Sounds.FireLoopSound.SoundType = EMCgSoundType.Get().GetSafeEnum(S_FireMode.Sounds.FireLoopSound.SoundType.name);
                    FireMode.Sounds.FireLoopSound.Priority = S_FireMode.Sounds.FireLoopSound.Priority;
                    FireMode.Sounds.FireLoopSound.bSpatialize = S_FireMode.Sounds.FireLoopSound.bSpatialize;
                    FireMode.Sounds.FireLoopSound.Duration = S_FireMode.Sounds.FireLoopSound.Duration;
                    FireMode.Sounds.FireLoopSound.bLooping = S_FireMode.Sounds.FireLoopSound.bLooping;
                    FireMode.Sounds.FireLoopSound.VolumeMultiplier = S_FireMode.Sounds.FireLoopSound.VolumeMultiplier;
                    FireMode.Sounds.FireLoopSound.PitchMultiplier = S_FireMode.Sounds.FireLoopSound.PitchMultiplier;
                    FireMode.Sounds.FireLoopSound.Bone = S_FireMode.Sounds.FireLoopSound.Bone;
                    // FireFinishSound
                    FireMode.Sounds.FireFinishSound.Sound = S_FireMode.Sounds.FireFinishSound.Sound;
                    FireMode.Sounds.FireFinishSound.Sound_LoadFlags = S_FireMode.Sounds.FireFinishSound.Sound_LoadFlags;
                    FireMode.Sounds.FireFinishSound.SoundType = EMCgSoundType.Get().GetSafeEnum(S_FireMode.Sounds.FireFinishSound.SoundType.name);
                    FireMode.Sounds.FireFinishSound.Priority = S_FireMode.Sounds.FireFinishSound.Priority;
                    FireMode.Sounds.FireFinishSound.bSpatialize = S_FireMode.Sounds.FireFinishSound.bSpatialize;
                    FireMode.Sounds.FireFinishSound.Duration = S_FireMode.Sounds.FireFinishSound.Duration;
                    FireMode.Sounds.FireFinishSound.bLooping = S_FireMode.Sounds.FireFinishSound.bLooping;
                    FireMode.Sounds.FireFinishSound.VolumeMultiplier = S_FireMode.Sounds.FireFinishSound.VolumeMultiplier;
                    FireMode.Sounds.FireFinishSound.PitchMultiplier = S_FireMode.Sounds.FireFinishSound.PitchMultiplier;
                    FireMode.Sounds.FireFinishSound.Bone = S_FireMode.Sounds.FireFinishSound.Bone;
                }
            }

            // _Mesh
            {
                Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(S__Mesh._Mesh.Path);
                _Mesh._Mesh.SetAsset(mesh);
            }
#endif // #if UNITY_EDITOR
        }
    }
}
