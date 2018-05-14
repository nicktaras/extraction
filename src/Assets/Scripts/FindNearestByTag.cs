/* FindNearestByTag (UNITY C#)
* 
*/

//using UnityEngine;

// Script not in use for this game.

//public class FindNearestByTag : MonoBehaviour
//{

//	GameObject _closestObject;
//	Transform _transform;
//	string _tagName;

//	public GameObject getNearestObjectByTag(Transform _transform, string _tagName)
//	{

//		GameObject[] objectsByTagName;
//		objectsByTagName = GameObject.FindGameObjectsWithTag(_tagName);

//		Vector3 currentPosition = _transform.position;

//		_closestObject = GameObject.FindGameObjectsWithTag(_tagName)[0];

//		float closestDistance = Mathf.Infinity;

//		foreach (GameObject objectByTagName in objectsByTagName)
//		{
//			float distance = (currentPosition - objectByTagName.transform.position).sqrMagnitude;
//			if (distance < closestDistance)
//			{
//				closestDistance = distance;
//				_closestObject = objectByTagName;
//			}
//		}

//		return _closestObject;

//	}

//}