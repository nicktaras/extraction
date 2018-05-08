using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCraft : MonoBehaviour {

    //Vector3 pos;
    //GameObject objectToMove;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        transform.Translate(-x, y, 0);
		
	}
}


 //void Update()
 //{
 //     Ball_Rigid.AddForce (new Vector3 (-10 * Speed , 0 , 0));
 
 //     if(Input.GetKeyDown(KeyCode.LeftArrow))
 //     {
 //          pos = new Vector3(transform.position.x , transform.position.y , transform.position.z - 1.0f));
 //     }
 
 //     if(Input.GetKeyDown(KeyCode.RightArrow))
 //     {
 //        pos = new Vector3(transform.position.x , transform.position.y , transform.position.z + 1.0f));
 //     }
 //     objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, pos, Speed * Time.deltaTime);
 //}