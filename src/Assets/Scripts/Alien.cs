/* Alien (UNITY C#)
/* Alien (UNITY C#)
* 
* Alien: 
* 
* A Class to manage the state of an Alien whilst on stage.
* 
*/

using UnityEngine;

public class Alien : MonoBehaviour
{

    /* 
     Public Vars
     Game Idea: Dispatch isSaved event for a short period of time (bonus save event)
    */

	public bool isAllowedToMove = false; // alien cannot move until true
	public bool isSaved = false;         // when the alien has been saved 

    // Alien Constructor
	public class AlienManager
	{
		public GameObject wayPointTarget;
	}

	// Create instance of AlienManager
	private AlienManager alien = new AlienManager();

	void Start()
	{
		isAllowedToMove = true;
	}

    // When Moving Aliens will make their way towards
    // their specified waypoint object.
	void move()
	{

		// Create reference to WaypointManager Class
		WaypointManager _WayPointManager = GetComponent<WaypointManager>();

        // Define Current waypoint
		alien.wayPointTarget = _WayPointManager.getCurrentWayPoint();

		// Create reference to MoveTowards Class
		MoveTowards _moveTowards = GetComponent<MoveTowards>();

		// Apply target to MoveTowards Class
		_moveTowards.moveToTarget(alien.wayPointTarget);

	}

    // When an alien is saved
    // TODO The mothership should beam the alien up / set move to false in this class.
	void saved()
	{
		MoveTowards _moveTowards = GetComponent<MoveTowards>();
		GameObject AlienSavedCheckPoint = GameObject.Find("AlienSavedCheckPoint");
		_moveTowards.speed = 4;
		_moveTowards.moveToTarget(AlienSavedCheckPoint);
	}

	void Update()
	{

		if (isAllowedToMove)
		{

			move();

		}

        // TODO Remove when mothership saves with beam.
		if (isSaved)
		{

			saved();

		}

	}
}