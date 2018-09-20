namespace Gg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using CgCore;

    [Serializable]
    public struct S_FGgPlayerInfo
    {
        public string Character;
        public string MeshSkin;
        public string MaterialSkin;
        public string Weapon;
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
            return false;
        }
    }

    public class MGgPawn : MCgTpsPawn
    {
        #region "CVars"

        public static FCgConsoleVariableLog LogCharacterSetup = new FCgConsoleVariableLog("log.character.setup", false, "Log Character Setup", (int)ECgConsoleVariableFlag.Console);

        #endregion // CVars

        #region "Data Members"

        #region "Setup"

        public FECgCharacterState CharacterState;

	    public FECgCharacterSetup CharacterSetup;

            #endregion // Setup

            #region "Data"

        [SerializeField]
        public S_FGgPlayerInfo S_MyInfo;
        [NonSerialized]
        public FGgPlayerInfo MyInfo;

            #endregion // Data

        #endregion // Data Members

        // Use this for initialization
        void Start()
        {

        }

        public override void Init()
        {
            base.Init();

            MyInfo = new FGgPlayerInfo();

            MyInfo.Character = S_MyInfo.Character;
            MyInfo.MeshSkin = S_MyInfo.MeshSkin;
            MyInfo.MaterialSkin = S_MyInfo.MaterialSkin;
            MyInfo.Weapon = S_MyInfo.Weapon;
            MyInfo.WeaponMaterialSkin = S_MyInfo.WeaponMaterialSkin;
        }

        #region "Setup"

        public override void OnUpdate_HandleSetup()
        {
            if (CharacterState != EGgCharacterState.Setup)
                return;

            // Set Data_Character
            if (CharacterSetup == EGgCharacterSetup.SetDataCharacter)
            {
                if (bFirstSpawn || !bCacheData)
                    SetDatas();

                if (LogCharacterSetup.Log())
                {
                    FCgDebug.Log("MGgPawn.OnTick_HandleSetup: Character Setup Change: SetDataCharacter -> ApplyDataCharacer");
                }
                CharacterSetup = EGgCharacterSetup.ApplyDataCharacer;
            }
            // Apply Data_Character
            if (CharacterSetup == EGgCharacterSetup.ApplyDataCharacer)
            {
                ApplyData_Character();

                if (LogCharacterSetup.Log())
                {
                    FCgDebug.Log("MGgPawn.OnTick_HandleSetup: Character Setup Change: ApplyDataCharacer -> ApplyDataWeapon");
                }
                CharacterSetup = EGgCharacterSetup.ApplyDataWeapon;
            }
            // Apply Data_Weapon
            if (CharacterSetup == EGgCharacterSetup.ApplyDataWeapon)
            {
                ApplyData_Weapon();

                if (LogCharacterSetup.Log())
                {
                    FCgDebug.Log("MGgPawn.OnTick_HandleSetup: Character Setup Change: ApplyDataWeapon -> Finished");
                }
                CharacterSetup = EGgCharacterSetup.Finished;
            }
            // Finished
            if (CharacterSetup == EGgCharacterSetup.Finished)
            {
                if (bFirstSpawn)
                    OnFirstSpawn();

                bFirstSpawn = false;
                ++SpawnCount;
                bSpawnedAndActive = true;

                MGgPlayerState myPlayerState = null; //Cast<AMboPlayerState>(PlayerState);

                OnSetup_Finished_Event.Broadcast(myPlayerState.UniqueMappingId);
            }
            CharacterState = EGgCharacterState.Spawned;
        }

        #endregion // Setup

        #region "Data"

        public override void SetDatas()
        {
            MGgDataMapping dataMapping   = MCgDataMapping.Get<MGgDataMapping>();
            MGgPlayerState myPlayerState = (MGgPlayerState)PlayerState;

            //if (!bPlacedInWorld || !MyInfo.IsValid())
            //    MyInfo = MyPlayerState->AIData.Info;

            MyData_Character = dataMapping.LoadData<MGgData_Character>(EGgAssetType.Characters, MyInfo.Character);

            MyData_CharacterMeshSkin = dataMapping.LoadData<MGgData_CharacterMeshSkin>(EGgAssetType.CharacterMeshSkins, MyInfo.MeshSkin);
            MyData_CharacterMaterialSkin = dataMapping.LoadData<MGgData_CharacterMaterialSkin>(EGgAssetType.CharacterMaterialSkins, MyInfo.MaterialSkin);

            Data_Weapons.Clear();

            CurrentWeaponCount = 1;

            //Data_Weapons.Reserve(CurrentWeaponCount);

            for (int i = 0; i < CurrentWeaponCount; ++i)
            {
                MGgData_Weapon data = dataMapping.LoadData<MGgData_Weapon>(EGgAssetType.Weapons, MyInfo.Weapon);
                Data_Weapons.Add(data);
            }

            Data_WeaponMaterialSkins.Clear();
            //Data_WeaponMaterialSkins.Reserve(CurrentWeaponCount);

            for (int i = 0; i < CurrentWeaponCount; ++i)
            {
                MGgData_WeaponMaterialSkin data = dataMapping.LoadData<MGgData_WeaponMaterialSkin>(EGgAssetType.WeaponMaterialSkins, MyInfo.WeaponMaterialSkin);
                Data_WeaponMaterialSkins.Add(data);
            }
        }

        #endregion // Data
    }
}