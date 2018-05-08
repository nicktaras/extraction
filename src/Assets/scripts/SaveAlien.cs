using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAlien : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Save Aliens - This should trigger a 
    // 'beam me up scotty' animation... :)
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Alien")
        {
            Destroy(col.gameObject);
        }
    }
}
