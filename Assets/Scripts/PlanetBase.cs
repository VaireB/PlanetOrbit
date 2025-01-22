using UnityEngine;

public abstract class PlanetBase : MonoBehaviour
{
    public float Mass; // Planet's mass for gravitational calculations

    // Method to calculate gravitational force on a moon
    public Vector3 CalculateGravitationalForce(Transform moonTransform, float gravitationalConstant)
    {
        Vector3 directionToMoon = moonTransform.position - transform.position;
        float distance = directionToMoon.magnitude;

        // Avoid division by zero
        if (distance < 0.1f) distance = 0.1f;

        // Gravitational force: F = G * M / r²
        return directionToMoon.normalized * (gravitationalConstant * Mass / (distance * distance));
    }

    // Abstract method for moon stabilization (implementation may vary by planet)
    public abstract void StabilizeMoon(GameObject moon);
}
