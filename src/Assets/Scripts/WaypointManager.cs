using UnityEngine;
using System.Linq; // contains an orderby utility method.

// With the definition of waypoints with a tag name this class will 
// allow for gameobjects to navigate from one to another until it reaches the length.

public class WaypointManager : MonoBehaviour {

    public string tagName; // Tag name of waypoints 

    // Constructor
	class WayPointController
	{
		public GameObject[] objects; // array to assign objects to
		public bool[] checkList;     // array to store checklist of which waypoints have been visited
		public int currentIndex;     // currently found index in object array

        // assign index 0
		public WayPointController()
		{
			currentIndex = 0;
		}
	}

	// create new instance of wayPointController
	WayPointController wayPointController = new WayPointController();

    // get waypoint by index
	public GameObject getCurrentWayPoint()
	{
        if (wayPointController.currentIndex > -1)
        {
            return wayPointController.objects[wayPointController.currentIndex];
        } else {
        gameObject.GetComponent<Alien>().isAllowedToMove = false; // TECH DEBT!
            return wayPointController.objects[0];
        }
	}

    // Find the length of way points and build an array of them.
	void initialiseWayPointCheckList()
	{
		int _lengthOfWayPoints = wayPointController.objects.Length;
		wayPointController.checkList = new bool[_lengthOfWayPoints];
		int _index = 0;

        // set each waypoint checklist to false (not visited)
		foreach (GameObject objectByTagName in wayPointController.objects)
		{
			wayPointController.checkList[_index] = false;
			_index++;
		}

	}

    // Change flag when a checkpoint is reached
	void setWayPointFlag(bool _hasReachedWayPoint)
	{
		wayPointController.checkList[wayPointController.currentIndex] = _hasReachedWayPoint;
	}

    // Define the next waypoint
	void setNextSequencialWayPoint()
	{
		if (!(wayPointController.currentIndex >= wayPointController.checkList.Length - 1))
		{
			wayPointController.checkList[wayPointController.currentIndex] = false;
			wayPointController.currentIndex++;
		}
	}

    // Check if all waypoints are visited
	bool allWayPointsVisited()
	{
		int _lengthOfWayPoints = wayPointController.objects.Length;
		int _index = 0;
		int _visitedLength = 0;

		foreach (GameObject objectByTagName in wayPointController.objects)
		{
			if (wayPointController.checkList[_index] == true)
			{
				_visitedLength++;
			}
			_index++;
		}

		bool _allVisited = (_visitedLength == wayPointController.objects.Length);

		return _allVisited;

	}

    // when waypoint is reached
	bool wayPointReached(GameObject _target)
	{

		bool _wayPointReached = false;

		float distance = (transform.position - _target.transform.position).sqrMagnitude;

		if (distance <= 0.001)
		{
			_wayPointReached = true;
		}

		return _wayPointReached;

	}

    // sort waypoints by name a-z
	void Start()
	{
        wayPointController.objects = GameObject.FindGameObjectsWithTag(tagName).OrderBy(go => go.name).ToArray();
		initialiseWayPointCheckList();
	}

    // As the other Script MoveTowards animates aliens towards the way point
    // We check if the waypoint is met, where if true we can look for the next if less than length.
	void Update()
	{

		if (wayPointController.checkList[wayPointController.currentIndex] == false)
		{

			GameObject _target = wayPointController.objects[wayPointController.currentIndex];

			bool _hasReachedWayPoint = wayPointReached(_target);

			if (_hasReachedWayPoint == true)
			{
				setWayPointFlag(_hasReachedWayPoint);
                setNextSequencialWayPoint();
                    
			}

		}

	}

}