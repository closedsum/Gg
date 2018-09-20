namespace Gg
{
    using System;

    using UnityEngine;

    [Serializable]
    public struct S_FGgPlayerInfo
    {
        [SerializeField]
        public string Character;
        [SerializeField]
        public string MeshSkin;
        [SerializeField]
        public string MaterialSkin;
        [SerializeField]
        public string Weapon;
        [SerializeField]
        public string WeaponMaterialSkin;
    }

    public class FGgPlayerInfo
    {
        public string Character;
        public string MeshSkin;
        public string MaterialSkin;
        public string Weapon;
        public string WeaponMaterialSkin;

        public bool IsValid()
        {
            if (Weapon == "") { return false; }
            if (WeaponMaterialSkin == "") { return false; }
            return true;
        }

        public void Copy(FGgPlayerInfo from)
        {
            Character = from.Character;
            MeshSkin = from.MeshSkin;
            MaterialSkin = from.MaterialSkin;
            Weapon = from.Weapon;
            WeaponMaterialSkin = from.WeaponMaterialSkin;
        }
    }

    public class FGgPlayerData
    {
        #region "Data Members"

        public FGgPlayerInfo Info;

        #endregion // Data Members

        public FGgPlayerData()
        {
            Info = new FGgPlayerInfo();
        }

        public bool IsValid()
        {
            if (!Info.IsValid())
                return false;
            return true;
        }
    }
}