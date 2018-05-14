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

    // upon click start game
    void StartGame ()
    {
        Application.LoadLevel("Game");    
    }
	
}
