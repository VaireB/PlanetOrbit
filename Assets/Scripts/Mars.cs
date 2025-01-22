using UnityEngine;

public class Mars : PlanetBase
{
    public override void StabilizeMoon(GameObject moon)
    {
        MoonBehavior moonBehavior = moon.GetComponent<MoonBehavior>();
        if (moonBehavior != null)
        {
            moonBehavior.Stabilize(this); // Pass this Mars object to the moon
        }
    }
}
