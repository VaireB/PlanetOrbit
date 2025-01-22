using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public GameObject marsPrefab;
    public GameObject saturnPrefab;
    public GameObject moonPrefab;

    void Start()
    {
        // Create Mars and its moons
        GameObject mars = Instantiate(marsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        mars.name = "Mars";

        GameObject phobos = Instantiate(moonPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        phobos.name = "Phobos";
        GameObject deimos = Instantiate(moonPrefab, new Vector3(7, 0, 0), Quaternion.identity);
        deimos.name = "Deimos";

        PlanetBase marsBase = mars.GetComponent<PlanetBase>();

        // Stabilize Mars moons
        phobos.GetComponent<MoonBehavior>().Stabilize(marsBase);
        deimos.GetComponent<MoonBehavior>().Stabilize(marsBase);

        // Create Saturn and its moons
        GameObject saturn = Instantiate(saturnPrefab, new Vector3(20, 0, 0), Quaternion.identity);
        saturn.name = "Saturn";

        GameObject titan = Instantiate(moonPrefab, new Vector3(27, 0, 0), Quaternion.identity);
        titan.name = "Titan";
        GameObject rhea = Instantiate(moonPrefab, new Vector3(30, 0, 0), Quaternion.identity);
        rhea.name = "Rhea";

        PlanetBase saturnBase = saturn.GetComponent<PlanetBase>();

        // Stabilize Saturn moons
        titan.GetComponent<MoonBehavior>().Stabilize(saturnBase);
        rhea.GetComponent<MoonBehavior>().Stabilize(saturnBase);
    }
}
