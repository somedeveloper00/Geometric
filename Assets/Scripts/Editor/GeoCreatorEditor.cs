using System;

using Codice.CM.Common;

using UnityEditor;

using UnityEngine;
using UnityEngine.XR;

using static UnityEditor.Graphs.Styles;

[CustomEditor(typeof(GeoCreator), true)]
public class GeoCreatorEditor : Editor
{
    private Editor _p1Editor;
    private Editor _p2Editor;
    private GeoCreator tar;

    private void OnEnable()
    {
        tar = target as GeoCreator;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        base.OnInspectorGUI();
        
        var p1 = serializedObject.FindProperty("p1");
        var p2 = serializedObject.FindProperty("p2");
        var time = serializedObject.FindProperty("time");

        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            if (p1.objectReferenceValue != null)
            {
                if(_p1Editor == null)
                    CreateCachedEditor(p1.objectReferenceValue, null, ref _p1Editor);
                _p1Editor.OnInspectorGUI();
            }
        }

        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            if (p2.objectReferenceValue != null)
            {
                if(_p2Editor == null)
                    CreateCachedEditor(p2.objectReferenceValue, null, ref _p2Editor);
                _p2Editor.OnInspectorGUI();
            }
        }

        if (p1.objectReferenceValue != null && p2.objectReferenceValue != null)
        {
            time.floatValue = EditorGUILayout.Slider("T", time.floatValue, 0, GeoCreator.LCM(tar.p1.duration, tar.p2.duration));
        }

        serializedObject.ApplyModifiedProperties();
    }
}