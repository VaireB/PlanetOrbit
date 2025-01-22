using UnityEngine;

public class Mars : PlanetBase
{
    void Start()
    {
        Mass = 0.64171f; // Mars' approximate mass (×10^24 kg)
        Gravity = 3.71f; // Mars' surface gravity (m/s²)
        OrbitRadius = 10f; // Orbit radius in Unity units
    }

    public override void CalculateGravity()
    {
        Gravity = Mass * 0.05f; // Adjusted gravity for Unity scale
    }

    public override void StabilizeMoon(GameObject moon)
    {
        MoonBehavior moonBehavior = moon.GetComponent<MoonBehavior>();
        if (moonBehavior != null)
        {
            moonBehavior.Stabilize(this);
        }
    }
}
