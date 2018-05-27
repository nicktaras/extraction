using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    // instance of UI button
    public Button btn;

    // Add click listener
	void Start()
	{
		Button StartButton = btn.GetComponent<Button>();
		StartButton.onClick.AddListener(StartGame);
	}

    void ResetScore() {
		GameManager.aliensSaved = 0;
		GameManager.aliensLost = 0;
    }

    // upon click start game
    void StartGame ()
    {
        ResetScore();
        Application.LoadLevel("Game");    
    }
	
}
