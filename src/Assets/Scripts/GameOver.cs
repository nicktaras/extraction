using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text results;

	// Use this for initialization
	void Awake () {

        int score = GameManager.aliensSaved - GameManager.aliensLost;
        string resultFeedBack = "";

		if (score < -100)
		{
			resultFeedBack = "Who's side are you on son. A lot of innocent lives were lost out there today.";
		}
		if (score > -50)
		{
			resultFeedBack = "You did well, but we lost quite a few innocent lives out there today!";
		}
        if (score > -30)
        {
           resultFeedBack = "Well done, you have made the people of this planet proud!";
        }
		if (score > 0)
		{
			resultFeedBack = "Well done, incredible job out there today!";
		}
		
		results.text = resultFeedBack + "\n\n / Lives Saved: " + GameManager.aliensSaved.ToString() +  "\n / Lives Lost: " + GameManager.aliensLost.ToString() + "\n / Time Left: 0.000s";
	}
	
}
