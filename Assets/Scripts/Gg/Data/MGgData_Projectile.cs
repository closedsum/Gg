namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgData_Projectile : MCgData_Projectile
    {
        #region "Data Members"

            #region "Stats"

        public FECgProjectileType ProjectileType;

        public float LifeTime;

            #endregion // Stats

            #region "Movement"

        public float InitialSpeed;
        public float MaxSpeed;
        public float GravityMultiplier;
        public float ForwardAcceleration;

            #endregion // Movement

            #region "Mesh"

        public Mesh _Mesh;

            #endregion // Mesh

            #region "Transform"

        public FCgTransform _Transform;

            #endregion // Transform

            #region "Collider"

        public bool bCollider;

        public FCgColliderPreset ColliderPreset;

        public bool bRigidbody;

        public FCgRigidbodyPreset RigidbodyPreset;

            #endregion // Collider

        #endregion // Data Members

        public override void Init()
        {
            S_AssetType.Name = EGgAssetType.Projectiles.Name;

            base.Init();
        }

        #region "Stats"

        public override FECgProjectileType GetProjectileType(){ return ProjectileType; }

        public override float GetLifeTime() { return LifeTime; }

        #endregion // Stats

        #region "Movement"

        public override float GetInitialSpeed() { return InitialSpeed; }

        public override float GetMaxSpeed() { return MaxSpeed; }

        public override float GetGravityMultiplier() { return GravityMultiplier; }

        public override float GetForwardAcceleration() { return ForwardAcceleration; }

        #endregion // Movement

        #region "Mesh"

        public override Mesh GetMesh(ECgViewType viewType){ return _Mesh; }

        #endregion // Mesh

        #region "Transform"

        public override FCgTransform GetTransform() { return _Transform; }

        #endregion // Transform

        #region "Collision"

        public override bool UseCollider() { return bCollider; }

        public override FCgColliderPreset GetColliderPreset() { return ColliderPreset; }

        public override float GetSphereRadius() { return ColliderPreset.SphereInfo.Radius; }

        public override bool UseRigidbody() { return bRigidbody; }

        public override FCgRigidbodyPreset GetRigidbodyPreset() { return RigidbodyPreset; }

        #endregion // Collision
    }
}