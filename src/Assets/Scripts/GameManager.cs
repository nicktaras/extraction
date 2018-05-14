using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The GameManager controls how the game unfolds.
// This includes managing the score and when the game should end.
// TODO Move display

public class GameManager : MonoBehaviour {

    // Public Static (Global vars)
    // These are referenced from the other scenes within the Game.
    // TODO Review how a singleton class should be truely developed in Unity.
    public static int aliensSaved = 0; // aliens saved during game
    public static int aliensLost = 0;  // aliens lost during game

    // Refernce to score.
    public Text score;                  // Reference to Text object in Scene
    private float countDownTime = 180f; // Time left in seconds

    // subscribe for when aliens are saved or killed
	void OnEnable()
	{
		AlienCollisionManager.DispatchAlienSavedEvent += alienSavedScoreUpdate;
        AlienCollisionManager.DispatchAlienKilledEvent += alienKilledScoreUpdate;
	}

	// unsubscribe for when aliens are saved or killed
	void OnDisable()
	{
		AlienCollisionManager.DispatchAlienSavedEvent -= alienSavedScoreUpdate;
        AlienCollisionManager.DispatchAlienKilledEvent -= alienKilledScoreUpdate;
	}

    // when alien is killed
    void alienKilledScoreUpdate()
    {
        aliensLost++;
    }

    // when alien is saved
	void alienSavedScoreUpdate()
	{
        aliensSaved++;
	}

    // reset lives 
	void Start () {

		aliensSaved = 0;
	    aliensLost = 0;
        score.text = "Lives Saved: " + aliensSaved.ToString() + " / Lives Lost: " + aliensLost.ToString() + " / Time Left: 199s";

    }

	// update score and reduce time
	void Update () {

		score.text = "Lives Saved: " + aliensSaved.ToString() + " / Lives Lost: " + aliensLost.ToString() + " / Time Left: " + countDownTime.ToString() + "s";

		countDownTime -= Time.deltaTime;

		if (countDownTime <= 0.0f)
		{
			Application.LoadLevel("EndGame");
		}

	}

}
