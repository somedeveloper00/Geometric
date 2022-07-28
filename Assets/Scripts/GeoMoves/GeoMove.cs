using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class GeoMove : MonoBehaviour
{
    public float duration = 2;
    public float thickness = 2;
    public Color color;
    
    private void OnValidate()
    {
        if(color == Color.clear)
            color = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 1);
        transform.localPosition = Vector3.zero;
    }

    [NonSerialized]
    private GUIStyle _labelStyle = null;
    
    protected GUIStyle LabelStyle
    {
        get
        {
            if (_labelStyle == null) 
            {
                _labelStyle = new GUIStyle(EditorStyles.label);
                var col = new Color(color.r + 0.3f, color.g + 0.3f, color.b + 0.3f, color.a + 0.3f);
                _labelStyle.active.textColor = col;
                _labelStyle.normal.textColor = col;
            }

            return _labelStyle;
        }
    }

    public abstract void GUpdate(float time);
}