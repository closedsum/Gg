namespace Gg
{
    using CgCore;

    public static class EGgCharacterState
    {
        public static readonly FECgCharacterState Setup = EMCgCharacterState.Get().Create("Setup");
        public static readonly FECgCharacterState Spawned = EMCgCharacterState.Get().Create("Spawned");

        public static void Init() { }
    }

    public static class EGgCharacterSetup
    {
        public static readonly FECgCharacterSetup SetDataCharacter = EMCgCharacterSetup.Get().Create("Set Data_Character");
        public static readonly FECgCharacterSetup ApplyDataCharacer = EMCgCharacterSetup.Get().Create("Apply Data_Character");
        public static readonly FECgCharacterSetup ApplyDataWeapon = EMCgCharacterSetup.Get().Create("Apply Data Weapon");
        public static readonly FECgCharacterSetup Finished = EMCgCharacterSetup.Get().Create("Finish");

        public static void Init() { }
    }
}