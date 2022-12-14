using System.Collections;

using UnityEditor;

using UnityEngine;

public class LineMove : GeoMove
{
    public float length = 2;
    
    Vector3 origin => transform.parent?.position ?? Vector3.zero;

    protected override void DrawGizmo()
    {
        Handles.color = color;
        Handles.DrawLine(origin + transform.forward * length / 2, origin - transform.forward * length / 2, thickness * 1.5f);
        Handles.Label(origin + transform.up * length * 0.2f, $"l: {length} d: {duration}", LabelStyle);
    }

    public override void GUpdate(float time)
    {
        var t = time > duration / 2f ? duration - time : time;
        t /= duration / 2f;
        transform.localPosition = Vector3.Lerp(origin + Vector3.forward * length / 2f, origin - Vector3.forward * length / 2f, t);
    }
}
