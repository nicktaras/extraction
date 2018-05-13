using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public static int aliensSaved = 0;
    public static int aliensLost = 0;
    public Text score;
    public float countDownTime = 180f;

	void OnEnable()
	{
		SaveAlien.DispatchAlienSavedEvent += alienSavedScoreUpdate;
        SaveAlien.DispatchAlienKilledEvent += alienKilledScoreUpdate;
	}

	void OnDisable()
	{
		SaveAlien.DispatchAlienSavedEvent -= alienSavedScoreUpdate;
        SaveAlien.DispatchAlienKilledEvent -= alienKilledScoreUpdate;
	}

    void alienKilledScoreUpdate()
    {
        aliensLost++;
    }

	void alienSavedScoreUpdate()
	{
        aliensSaved++;
	}

	// Use this for initialization
	void Start () {

		aliensSaved = 0;
	    aliensLost = 0;
        score.text = "Lives Saved: " + aliensSaved.ToString() + " / Lives Lost: " + aliensLost.ToString() + " / Time Left: 199s";

    }

	// Update is called once per frame
	void Update () {

		score.text = "Lives Saved: " + aliensSaved.ToString() + " / Lives Lost: " + aliensLost.ToString() + " / Time Left: " + countDownTime.ToString() + "s";

		countDownTime -= Time.deltaTime;

		if (countDownTime <= 0.0f)
		{
			Application.LoadLevel("EndGame");
		}

	}

}
