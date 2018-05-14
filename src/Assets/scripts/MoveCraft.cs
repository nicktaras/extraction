using UnityEngine;

// Simple Gameplay script for user control of Mothership 
// with arrow keys.

public class MoveCraft : MonoBehaviour {

	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(-x, y, 0);
		
	}
}
