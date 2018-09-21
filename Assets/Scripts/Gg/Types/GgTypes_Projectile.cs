namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public static class EGgProjectileType
    {
        public static readonly FECgProjectileType Bullet = EMCgProjectileType.Get().Create("Bullet");

        public static void Init() { }
    }
}