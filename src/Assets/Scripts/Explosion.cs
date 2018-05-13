using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    // 1.5 seconds 
    public float countDownTime = 0.5f;
    	
	void Update () {

        countDownTime -= Time.deltaTime;

		transform.localScale += new Vector3(0.009F, 0.009F, 0.009F);

		if (countDownTime <= 0.0f)
		{
			timerEnded();
		}
	}

	void timerEnded()
	{
		Destroy(this.gameObject);
	}
}
