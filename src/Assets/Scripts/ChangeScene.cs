//To use this example, attach this script to an empty GameObject.
//Create two buttons (Create>UI>Button). Next, click your empty GameObject in the Hierarchy and click and
//drag each of your Buttons from the Hierarchy to the Your Button and "Your Second Button" fields in the Inspector.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public Button btn;

	// Use this for initialization
	void Start()
	{
		Button StartButton = btn.GetComponent<Button>();

		//Calls the TaskOnClick method when you click the Button
		StartButton.onClick.AddListener(StartGame);

	}

    void StartGame ()
    {
        Application.LoadLevel("Game");    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
