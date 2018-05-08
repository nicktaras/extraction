
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaypointManager : MonoBehaviour {

    public string tagName;

	class WayPointController
	{
		public GameObject[] objects;
		public bool[] checkList;
		public string tagName;
		public int currentIndex;

		public WayPointController()
		{
			currentIndex = 0;
		}
	}

	WayPointController wayPointController = new WayPointController();

	public GameObject getCurrentWayPoint()
	{
        return wayPointController.objects[wayPointController.currentIndex];
	}

    // Find the length of way points and build an array of them.
	void initialiseWayPointCheckList()
	{
		int _lengthOfWayPoints = wayPointController.objects.Length;
		wayPointController.checkList = new bool[_lengthOfWayPoints];
		int _index = 0;

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

	void Start()
	{
		wayPointController.tagName = tagName;
        wayPointController.objects = GameObject.FindGameObjectsWithTag(wayPointController.tagName).OrderBy(go => go.name).ToArray();
        Debug.Log(wayPointController.objects[0].name + wayPointController.objects.Length);
		initialiseWayPointCheckList();
	}

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