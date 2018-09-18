namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public static class EGgAssetType
    {
        public static readonly FECgAssetType Weapons = EMCgAssetType.Get().Create("Weapons");

        public static void Init() { }
    }
}