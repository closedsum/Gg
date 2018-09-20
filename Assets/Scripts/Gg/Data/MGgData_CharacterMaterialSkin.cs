namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgData_CharacterMaterialSkin : MCgData_CharacterMaterialSkin
    {
        public override void Init()
        {
            S_AssetType.Name = EGgAssetType.CharacterMaterialSkins.Name;

            base.Init();
        }
    }
}