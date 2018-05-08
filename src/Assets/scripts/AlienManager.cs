﻿using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject alien;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public string WayPointTags;             // Which waypoints to apply

	void Start()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // get alien waypoint manager class
        WaypointManager waypointManager = alien.GetComponent<WaypointManager>();

        waypointManager.tagName = WayPointTags;

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(alien, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

	}
}    