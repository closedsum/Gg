using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CgCore;
using Gg;

public static class FCgEnumClassLinker
{
    public static void Init()
    {
        EGgGameInstanceState.Init();
        EGgTime.Init();
        EGgCoroutineSchedule.Init();
        EGgAssetType.Init();
        EGgInputAction.Init();

        EGgWeaponState.Init();
        EGgWeaponSlot.Init();
        EGgWeaponFireMode.Init();
        EGgData_Weapon_FireMode.Init();
    }
}
