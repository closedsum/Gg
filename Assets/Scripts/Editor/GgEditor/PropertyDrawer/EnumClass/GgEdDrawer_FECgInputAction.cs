namespace GgEditor
{
    using UnityEditor;
    using UnityEngine;

    using CgEditor;
    using CgCore;
    using Gg;

    [CustomPropertyDrawer(typeof(FECgInputAction))]
    public class FGgEdDrawer_FECgInputAction : FCgEdDrawer_EnumClass<EMCgInputAction, FECgInputAction, byte>
    {
        static FGgEdDrawer_FECgInputAction()
        {
            EGgInputAction.Init();
        }
        /*
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
        }
        */
    }
}