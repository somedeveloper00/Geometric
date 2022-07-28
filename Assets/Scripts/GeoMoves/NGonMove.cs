using System.Collections;

using UnityEditor;

using UnityEngine;

public class NGonMove : GeoMove
{
    [Min(3)]
    public int sides = 3;

    [Min(0)]
    public float radius;

    private Vector3[] points;

    
    private void OnValidate() => UpdatePoints();
    private void Start() => UpdatePoints();


    private void OnDrawGizmos()
    {
        if(!Application.isPlaying)
            UpdatePoints();
        
        Handles.color = color;
        for (int i = 0; i < points.Length; i++)
        {
            var p = points[i];
            var next = points[(i + 1) % points.Length];
            Handles.DrawLine(p, next, thickness);
        }
        Handles.Label(transform.position + transform.up * radius * 0.2f, $"r: {radius} d: {duration}", LabelStyle);
    }

    public override void GUpdate(float time)
    {
        float inc = duration / sides;
        var low_index = (int)Mathf.Floor(time / inc);
        var high_index = (low_index + 1) % sides;
        var t = (time - low_index * inc) / inc;
        transform.position = Vector3.Lerp(points[low_index], points[high_index], t);
    }

    private void UpdatePoints()
    {
        points = new Vector3[sides];
        for (int i = 0; i < sides; i++)
        {
            float angle = i * 2 * Mathf.PI / sides;
            var p = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            points[i] = transform.parent.TransformPoint(p);
        }
    }
}
