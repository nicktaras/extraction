using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {

	public GameObject bullet;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;             // How long between each spawn. 

	void Start()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("Fire", spawnTime, spawnTime);
	}

	void Fire()
	{

        Instantiate(bullet, this.transform.position, this.transform.rotation);

	}

}


