using UnityEngine;

public abstract class GeoCreator : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public float time;

    [SerializeField] public GeoMove p1, p2;
    [SerializeField] public float duration = 9999;
    [Range(0, 1)]
    [SerializeField] public float colorTransparency = 0.1f;
    [SerializeField] public int speed = 1;
    [SerializeField] public float step = 0.1f;

    private float maxTime;
    private Color color;

    private void Start()
    {
        maxTime = LCM(p1.duration, p2.duration);
        color.a = colorTransparency;
    }

    private void Update()
    {
        for (int i = 0; i < speed; i++)
        {
            if (time >= maxTime) return;

            // draw with Creator
            Draw(p1.transform.position, p2.transform.position, time / maxTime, color);

            // move dots
            p1.GUpdate(time % p1.duration);
            p2.GUpdate(time % p2.duration);

            time += step;
            if (time > maxTime) time = maxTime;
            color.r = Mathf.Sin(time);
            color.g = Mathf.Cos(time);
            color.b = Mathf.Sin(time * 2) + Mathf.Cos(time / 2f);
        }
    }

    protected abstract void Draw(Vector3 p1, Vector3 p2, float t, Color col);

    public static float LCM(float a, float b)
    {
        if (a * b <= 0)
        {
            Debug.LogWarning("values should be greater than zero");
            return 0;
        }


        // a is greater
        if (a < b)
        {
            (a, b) = (b, a);
        }

        float A = a, B = b;

        while (A % B != 0)
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
