using UnityEngine;

public class AlienManager : MonoBehaviour
{
	public GameObject alienMale;                // GameObject Prefab to create from.
	public GameObject alienFemale;              // GameObject Prefab to create from.
	public float spawnTime = 3f;                // How long between each spawn.
	public Transform[] spawnPoints;             // An array of the spawn points this enemy can spawn from.
    public string WayPointTags;                 // Which waypoints to apply

	void Start()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    GameObject GetAlienType() {
        
		int randomSelectAlienType = Random.Range(0, 2);

		if (randomSelectAlienType == 0)
		{
			return alienMale;
		}
		
		return alienFemale;

    }

	void Spawn()
	{

        // Get / Set Alien Male / Female Prefab.
        GameObject alien = GetAlienType();

        // Get Waypoint Manager Script from Alien
        WaypointManager waypointManager = alien.GetComponent<WaypointManager>();

        // TO INVESTIGATE
        waypointManager.tagName = WayPointTags;

        // Choose a random way point to spawn from
        int spawnPointIndex = Random.Range(0, spawnPoints.Length - 1);

        // instantiate alien from spawn point
        Instantiate(alien, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

	}
}    