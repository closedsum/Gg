namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public static class EGgAssetType
    {
        public static readonly FECgAssetType Characters = EMCgAssetType.Get().Create("Characters");
        public static readonly FECgAssetType CharacterMeshSkins = EMCgAssetType.Get().Create("CharacterMeshSkins");
        public static readonly FECgAssetType CharacterMaterialSkins = EMCgAssetType.Get().Create("CharacterMaterialSkins");
        public static readonly FECgAssetType Weapons = EMCgAssetType.Get().Create("Weapons");
        public static readonly FECgAssetType WeaponMaterialSkins = EMCgAssetType.Get().Create("WeaponMaterialSkins");

        public static void Init() { }
    }
}