using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages and dispatches events when objects collide with the alien.
public class AlienCollisionManager : MonoBehaviour {

    // Alien saved or killed events
    // TODO Move event tirggers to correct classes with TODO's below.

	public delegate void AlienSaved();
	public static event AlienSaved DispatchAlienSavedEvent;

	public delegate void AlienKilled();
	public static event AlienKilled DispatchAlienKilledEvent;

    void OnCollisionEnter(Collision col)
    {
        // Collect Alien with Beam
        // TODO Move this to Beam collider.
        if (col.gameObject.tag == "Beam")
        {
            gameObject.GetComponent<Alien>().isSaved = true;
            gameObject.GetComponent<Alien>().isAllowedToMove = false;
        }

		// Beam has successfully collected Alien
		// TODO Move this to Beam collider.
		if(col.gameObject.tag == "AlienSavedCheckPoint") 
        {
            Destroy(this.gameObject);
            DispatchAlienSavedEvent();
        }

        // Destroy the alien
        // TODO Move this to explosion collider
        if (col.gameObject.tag == "Explosion"){
            Destroy(this.gameObject);
            DispatchAlienKilledEvent();
        }

    }

}
