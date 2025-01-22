using UnityEngine;

public class MoonBehavior : MonoBehaviour
{
    public Vector3 Velocity; // Moon's velocity
    private Transform planet; // Reference to the planet
    private float gravitationalConstant = 1f; // Adjustable gravitational constant

    private LineRenderer orbitLine; // LineRenderer for orbit visualization
    private int orbitResolution = 100; // Number of points on the orbit line

    void Start()
    {
        // Ensure the LineRenderer is initialized in Start
        InitializeOrbitLine();
    }

    void Update()
    {
        if (planet != null)
        {
            // Calculate direction and distance
            Vector3 directionToPlanet = (planet.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, planet.position);

            // Avoid division by zero
            if (distance < 0.1f) // Arbitrary small threshold to avoid issues
            {
                Debug.LogWarning("Moon is too close to the planet! Adjusting position...");
                distance = 0.1f;
            }

            // Gravitational force: F = G * M / r²
            Vector3 gravitationalForce = directionToPlanet * gravitationalConstant * planet.GetComponent<PlanetBase>().Mass / (distance * distance);

            // Update velocity with gravitational force
            Velocity += gravitationalForce * Time.deltaTime;

            // Update position based on velocity
            transform.position += Velocity * Time.deltaTime;

            // Update orbit line
            UpdateOrbitLine(distance);
        }
    }

    public void Stabilize(PlanetBase planetBase)
    {
        planet = planetBase.transform;

        // Calculate initial orbital velocity
        Vector3 directionToPlanet = (transform.position - planet.position).normalized;
        float distance = Vector3.Distance(transform.position, planet.position);
        float orbitalSpeed = Mathf.Sqrt(gravitationalConstant * planetBase.Mass / distance);

        // Set velocity perpendicular to the direction to the planet
        Velocity = Vector3.Cross(directionToPlanet, Vector3.up) * orbitalSpeed;

        // Initialize the orbit line
        UpdateOrbitLine(distance);
    }

    private void InitializeOrbitLine()
    {
        if (orbitLine == null)
        {
            orbitLine = gameObject.AddComponent<LineRenderer>();
            orbitLine.startWidth = 0.05f;
            orbitLine.endWidth = 0.05f;
            orbitLine.loop = true; // Make the line loop to form a circle
            orbitLine.useWorldSpace = true;
            orbitLine.material = new Material(Shader.Find("Sprites/Default")) { color = Color.white };
        }
    }

    private void UpdateOrbitLine(float orbitRadius)
    {
        if (orbitLine == null)
        {
            Debug.LogError("LineRenderer is not initialized!");
            return;
        }

        // Set the number of points for the orbit line
        orbitLine.positionCount = orbitResolution;

        // Calculate points on the circular path
        for (int i = 0; i < orbitResolution; i++)
        {
            float angle = i * 2 * Mathf.PI / orbitResolution;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * orbitRadius;
            orbitLine.SetPosition(i, planet.position + offset);
        }
    }
}
