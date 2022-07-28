using System;

using UnityEditor;

using UnityEngine;
using UnityEngine.XR;

[CustomEditor(typeof(GeoCreator))]
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

        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));

        var p1 = serializedObject.FindProperty("p1");
        var p2 = serializedObject.FindProperty("p2");
        var time = serializedObject.FindProperty("time");
        var speed = serializedObject.FindProperty("speed");
        var step = serializedObject.FindProperty("step");
        var color = serializedObject.FindProperty("color");

        using (new GUILayout.HorizontalScope())
        {
            p1.isExpanded = EditorGUILayout.Foldout(p1.isExpanded, "P1", true);
            EditorGUILayout.PropertyField(p1, GUIContent.none);
        }
        if (p1.isExpanded)
        {
            if (p1.objectReferenceValue != null)
            {
                CreateCachedEditor(p1.objectReferenceValue, null, ref _p1Editor);
                _p1Editor.OnInspectorGUI();
            }
        }

        using (new GUILayout.HorizontalScope())
        {
            p2.isExpanded = EditorGUILayout.Foldout(p2.isExpanded, "P2", true);
            EditorGUILayout.PropertyField(p2, GUIContent.none);
        }
        if (p2.isExpanded)
        {
            if (p2.objectReferenceValue != null)
            {
                CreateCachedEditor(p2.objectReferenceValue, null, ref _p2Editor);
                _p2Editor.OnInspectorGUI();
            }
        }

        if (p1.objectReferenceValue != null && p2.objectReferenceValue != null)
        {
            EditorGUILayout.PropertyField(color);
            time.floatValue = EditorGUILayout.Slider("T", time.floatValue, 0, GeoCreator.LCM(tar.p1.duration, tar.p2.duration));
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.PropertyField(step);
        }
        serializedObject.ApplyModifiedProperties();
    }
}