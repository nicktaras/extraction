using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAlien : MonoBehaviour {
    
	public delegate void AlienSaved();
	public static event AlienSaved DispatchAlienSavedEvent;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void goToMotherShip () {
        
    }

    // Save Aliens - This should trigger a 
    // 'beam me up scotty' animation... :)
    void OnCollisionEnter(Collision col)
    {
        // Collect Alien with Beam
        if (col.gameObject.tag == "Beam")
        {
            gameObject.GetComponent<Alien>().isSaved = true;
            gameObject.GetComponent<Alien>().isAllowedToMove = false;
			GameObject ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
            ChildGameObject1.GetComponent<Renderer>().enabled = true;
        }

        // Beam has successfully collected Alien
        if(col.gameObject.tag == "AlienSavedCheckPoint") 
        {
            Destroy(this.gameObject);
            DispatchAlienSavedEvent();
        }
    }

}
