﻿using UnityEngine;

public class MoveTowardsBeam : MonoBehaviour
{

	public float speed;
	public float RotationSpeed = 1;

	void Start()
	{
        randomiseSpeed();
	}

    public void randomiseSpeed(){
		float speedA = speed - 0.2F;
		float speedB = speed + 0.2F;
		speed = Random.Range(speedA, speedB);
    }

    // TODO Animate alien to center of beam - then up :) 
	public void moveToTarget(GameObject _target)
	{
    		
        float step = speed * Time.deltaTime;

        // move object towards beam...
        Vector3 test = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

        transform.position = test;

        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);

		//find the vector pointing from our position to the target
		Vector3 _direction = (_target.transform.position - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		Quaternion _lookRotation = Quaternion.LookRotation(_direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

	}

}
