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
        public string Weapon;
        public string WeaponMaterialSkin;
    }

    public class FGgPlayerInfo
    {
        public string Character;
        public string Weapon;
        public string WeaponMaterialSkin;

        public bool IsValid()
        {
            return false;
        }
    }

    public class MGgPawn : MCgPlayerPawn
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

            // TODO: Move to SetDatas
            MyInfo.Character = S_MyInfo.Character;
            MyInfo.Weapon = S_MyInfo.Character;
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
    }
}