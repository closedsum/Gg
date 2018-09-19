namespace Gg
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    public class MGgDataMapping : MCgDataMapping
    {
        #region "Data Members"

        public List<MGgData_Weapon> Weapons;
        public Dictionary<string, MGgData_Weapon> Weapons_Map;

        public List<MGgData_WeaponMaterialSkin> WeaponMaterialSkins;
        public Dictionary<string, MGgData_WeaponMaterialSkin> WeaponMaterialSkins_Map;

        #endregion // Data Members

        protected override void Init_Internal()
        {
            base.Init_Internal();

            GenerateMaps(true);
        }

        public override void GenerateMaps(bool initialize = false)
        {
            // Weapons
            GenerateMap<MGgData_Weapon>(EGgAssetType.Weapons, ref Weapons, ref Weapons_Map, true);
            // WeaponMaterialSkins
            GenerateMap<MGgData_WeaponMaterialSkin>(EGgAssetType.WeaponMaterialSkins, ref WeaponMaterialSkins, ref WeaponMaterialSkins_Map, true);
        }
    }
}
