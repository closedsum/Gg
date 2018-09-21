namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgProjectile : MCgProjectile
    {
        #region "Interface"

        public override void Init(int index, object e)
        {
            base.Init(index, e);

            bMeshComponent = true;
            bCollider = true;
            ColliderShape = ECgCollisionShape.Sphere;
            bRigidbody = true;
        }

        #endregion // Interface
    }
}