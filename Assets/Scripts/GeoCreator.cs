using System;
using UnityEngine;

public class GeoCreator : MonoBehaviour
{
    public GeoMove p1, p2;
    public float duration = 9999;
    public Color color = Color.green;
    public float time;
    public int speed = 1;
    public float step = 0.1f;

    private float maxTime;

    private void Start()
    {
        maxTime = LCM(p1.duration, p2.duration);
    }

    private void Update()
    {
        for (int i = 0; i < speed; i++)
        {
            if (time >= maxTime) return;
            Debug.DrawLine(p1.transform.position, p2.transform.position, color, duration);
            p1.GUpdate(time % p1.duration);
            p2.GUpdate(time % p2.duration);

            time += step;
            if (time > maxTime) time = maxTime;
            color.r = Mathf.Sin(time);
            color.g = Mathf.Cos(time);
            color.b = Mathf.Sin(time * 2) + Mathf.Cos(time / 2f);
        }
    }

    public static float LCM(float a, float b)
    {
        if (a * b <= 0)
            throw new Exception("values should be greater than zero");
        
        // a is greater
        if (a < b)
        {
            (a, b) = (b, a);
        }

        float A = a, B = b;
        
        while(A % B != 0)
        {
            B += b;
            if (A < B)
            {
                // A should be greater
                (A, B) = (B, A);
                (a, b) = (b, a);
            }

            if (B > 9999)
                return 0;
        }

        return A;
    }
}
