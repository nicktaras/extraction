using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO this should be updated to AlienCollisionManager
public class SaveAlien : MonoBehaviour {
    
	public delegate void AlienSaved();
	public static event AlienSaved DispatchAlienSavedEvent;

	public delegate void AlienKilled();
	public static event AlienKilled DispatchAlienKilledEvent;

    void OnCollisionEnter(Collision col)
    {
        // Collect Alien with Beam
        if (col.gameObject.tag == "Beam")
        {
            gameObject.GetComponent<Alien>().isSaved = true;
            gameObject.GetComponent<Alien>().isAllowedToMove = false;
			//GameObject ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
            //ChildGameObject1.GetComponent<Renderer>().enabled = true;
        }

        // Beam has successfully collected Alien
        if(col.gameObject.tag == "AlienSavedCheckPoint") 
        {
            Destroy(this.gameObject);
            DispatchAlienSavedEvent();
        }

        // TODO animation for killed?
        if (col.gameObject.tag == "Explosion"){
            Destroy(this.gameObject);
            DispatchAlienKilledEvent();
        }

    }

}
