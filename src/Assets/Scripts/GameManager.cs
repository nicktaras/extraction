using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int aliensSaved = 0;
    //public Text Mytext;

	void OnEnable()
	{
		SaveAlien.DispatchAlienSavedEvent += alienSavedScoreUpdate;
	}

	void OnDisable()
	{
		SaveAlien.DispatchAlienSavedEvent -= alienSavedScoreUpdate;
	}

	void alienSavedScoreUpdate()
	{
        aliensSaved++;
	}

	// Use this for initialization
	void Start () {
		//Text.GetComponent<Text>().text = "Score: " + aliensSaved.ToString();
		Transform child = transform.Find("Mytext");
		Text t = child.GetComponent<Text>();
        t.text = "Yoyoyoyo";
    }

	
	// Update is called once per frame
	void Update () {}

}
