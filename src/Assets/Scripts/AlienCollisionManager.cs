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

    // Dying Animation.
    public float countDownTime = 3;
    public bool AlienKilledFlag = false;

    void OnCollisionEnter(Collision col)
    {
        // Collect Alien with Beam
        // TODO Move this to Beam collider.
        if (col.gameObject.tag == "Beam")
        {
            this.gameObject.GetComponent<Alien>().isSaved = true;
            this.gameObject.GetComponent<Alien>().isAllowedToMove = false;

            GameObject bot = this.gameObject.transform.Find("xbot").gameObject;
            bot.GetComponent<BotAnimator>().alienSaved();

        }

		// Beam has successfully collected Alien
		// TODO Move this to Beam collider.
		if(col.gameObject.tag == "AlienSavedCheckPoint") 
        {
            Destroy(this.gameObject);
            DispatchAlienSavedEvent();
        }

        // Destroy the alien
        // TODO Move this to explosion collider?
        if (col.gameObject.tag == "Explosion"){

            // If they have not been Saved they die.
            if (!this.gameObject.GetComponent<Alien>().isSaved)
            {

                DispatchAlienKilledEvent();

                Debug.Log("Alien Killed");

                gameObject.GetComponent<Alien>().isSaved = false;
                gameObject.GetComponent<Alien>().isAllowedToMove = false;

                GameObject bot = this.gameObject.transform.Find("xbot").gameObject;
                bot.GetComponent<BotAnimator>().alienKilled();

                Debug.Log("Alien Killed");

                AlienKilledFlag = true;

            }
        }

    }

    void Update (){

        if (AlienKilledFlag == true)
        {
            countDownTime -= Time.deltaTime;

        }

		if (countDownTime <= 0.0f)
		{
			Destroy(this.gameObject);
		}

    }

}
