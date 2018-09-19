namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif // #if UNITY_EDITOR
    using CgCore;

    public class MGgData_WeaponMaterialSkin : MCgData_WeaponMaterialSkin
    {
        [SerializeField]
        S_FCgListMaterial S_Materials;
        [NonSerialized]
        FCgListMaterial Materials;

        public override List<Material> GetMaterials() { return Materials.Get(); }

        public override void Init()
        {
            S_AssetType.Name = EGgAssetType.WeaponMaterialSkins;

            base.Init();
#if UNITY_EDITOR
            if (S_Materials.Materials.Paths != null)
            {
                foreach (string path in S_Materials.Materials.Paths)
                {
                    Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
                    TCgAssetRef<Material> assetRef = new TCgAssetRef<Material>();
                    assetRef.SetAsset(mat);
                    Materials.Materials.Add(assetRef);
                }
            }
#endif // #if UNITY_EDITOR
        }
    }
}
