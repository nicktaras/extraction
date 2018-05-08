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
    
	public class AlienManager
	{
		public GameObject wayPointTarget;
		public bool isAllowedToMove;

		public AlienManager(bool _isAllowedToMove)
		{
			isAllowedToMove = _isAllowedToMove;
		}

		public AlienManager()
		{
			isAllowedToMove = false;
		}
	}

	public AlienManager alien = new AlienManager(false);

	void Start()
	{
		alien.isAllowedToMove = true;
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

	void Update()
	{

        if (alien.isAllowedToMove)
		{

			move();

		}

	}

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.tag);

    //    //if (col.gameObject.tag == "Beam")
    //    //{
    //    //    Destroy(col.gameObject);
    //    //}
    //}

}