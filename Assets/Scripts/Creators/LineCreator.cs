using UnityEngine;

public class LineCreator : GeoCreator
{
    protected override void Draw(Vector3 p1, Vector3 p2, float maxTime, Color col)
    {
        Debug.DrawLine(p1, p2, col, float.MaxValue);
    }
}
