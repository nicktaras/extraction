/* Alien (UNITY C#)
/* Alien (UNITY C#)
* 
* Alien:
* 
* USE:
* - To orchestrate the Alien ai.
* - This class has waypoints and move towards classes.
* 
* PARAMS:
* - tagName of way point to use
* 
* TEST: 
* tbc
* 
* AUTHOR: 
* Nicholas Taras
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

	public bool isAllowedToMove = false;
	public bool isSaved = false;
    public bool isKilled = false;

	public class AlienManager
	{
		public GameObject wayPointTarget;

	}

	private AlienManager alien = new AlienManager();

	void Start()
	{
		isAllowedToMove = true;
	}

	bool wayPointReached(GameObject _target)
	{

		Vector3 currentPosition = transform.position;

		bool _wayPointReached = false;

		float distance = (currentPosition - _target.transform.position).sqrMagnitude;

		// Close to Target - Adjust for precision.
		if (distance < Random.Range(1, 2))
		{
			_wayPointReached = true;
		}

		return _wayPointReached;

	}

	void move()
	{

		// Apply for sequential waypoints.
		WaypointManager _WayPointManager = GetComponent<WaypointManager>();
		alien.wayPointTarget = _WayPointManager.getCurrentWayPoint();

		MoveTowards _moveTowards = GetComponent<MoveTowards>();
		_moveTowards.moveToTarget(alien.wayPointTarget);

	}

	void saved()
	{
		MoveTowards _moveTowards = GetComponent<MoveTowards>();
		GameObject AlienSavedCheckPoint = GameObject.Find("AlienSavedCheckPoint");
		_moveTowards.speed = 4;
		_moveTowards.moveToTarget(AlienSavedCheckPoint);
	}

    void killed(){
        
    }

	void Update()
	{

		if (isAllowedToMove)
		{

			move();

		}

		if (isSaved)
		{

			saved();

		}

		if (isKilled)
		{

			killed();

		}

	}
}