namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgData_CharacterMeshSkin : MCgData_CharacterMeshSkin
    {
        public override void Init()
        {
            S_AssetType.Name = EGgAssetType.CharacterMeshSkins.Name;

            base.Init();
        }
    }
}
