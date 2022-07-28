using UnityEditor;
using UnityEngine;

public class CircleMove : GeoMove
{
    public float radius = 1;

    private void OnDrawGizmos()
    {
        var origin = transform.parent?.position ?? Vector3.zero;
        
        Handles.color = color;
        Handles.DrawWireDisc(origin, transform.up, radius, thickness);
        Handles.Label(
            origin + transform.right * (1.2f * radius) + transform.up * (radius * 0.1f), 
            $"r: {radius} d: {duration}", LabelStyle);
    }

    public override void GUpdate(float time)
    {
        var t = (time) / duration * Mathf.PI * 2;
        transform.localPosition = new Vector3(Mathf.Cos(t) * radius, 0, Mathf.Sin(t) * radius);
    }
}