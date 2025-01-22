using UnityEngine;

public class Saturn : PlanetBase
{
    public override void StabilizeMoon(GameObject moon)
    {
        MoonBehavior moonBehavior = moon.GetComponent<MoonBehavior>();
        if (moonBehavior != null)
        {
            moonBehavior.Stabilize(this); // Pass this Saturn object to the moon
        }
    }
}
