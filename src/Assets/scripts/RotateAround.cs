using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public Transform target;

	//void Start () {}

	//void Update () {
        //transform.LookAt(target);
        //transform.Translate(Vector3.right * Time.deltaTime);
	//}

    private float speedMod = 0.2f;//a speed modifier
    private Vector3 point; //the coord to the point where the camera looks at

    void Start()
    {
        point = target.transform.position; //get target's coords
        transform.LookAt(point);//makes the camera look to it
    }

    void Update()
    {
        //makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 10 * Time.deltaTime * speedMod);
    }
}

 