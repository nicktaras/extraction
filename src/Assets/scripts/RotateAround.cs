using UnityEngine;

// Class to apply rotation around a chosen object.
// in this game we use this to rotate the camera 
// around the centre of the stage.

public class RotateAround : MonoBehaviour {

    public Transform target; // targer to rotate around
    private float speedMod = 0.2f; // speed
    private Vector3 point; // point to rotate around.

    void Start()
    {
        point = target.transform.position; //get target's coords
        transform.LookAt(point);//makes the camera look to it
    }

    void Update()
    {
        // makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 10 * Time.deltaTime * speedMod);
    }
}

 