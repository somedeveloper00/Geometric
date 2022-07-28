using UnityEngine;

public class LineCreator : GeoCreator
{
    protected override void Draw(Vector3 p1, Vector3 p2, float t, Color col)
    {
        Debug.DrawLine(p1, p2, col, float.MaxValue);
    }
}
