using UnityEngine;

public abstract class PlanetBase : MonoBehaviour
{
    public float Mass; // Planet's mass
    public float Gravity; // Gravitational force multiplier
    public float OrbitRadius; // Average orbit radius for moons

    public abstract void CalculateGravity();
    public abstract void StabilizeMoon(GameObject moon);
}
