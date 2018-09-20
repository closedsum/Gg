namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgData_Character : MCgData_Character
    {
        public override void Init()
        {
            S_AssetType.Name = EGgAssetType.Characters.Name;

            base.Init();
        }
    }
}