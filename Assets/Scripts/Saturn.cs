using UnityEngine;

public class Saturn : PlanetBase
{
    void Start()
    {
        Mass = 568f; // Saturn's approximate mass (×10^24 kg)
        Gravity = 10.44f; // Saturn's surface gravity (m/s²)
        OrbitRadius = 50f; // Orbit radius in Unity units
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
