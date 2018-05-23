using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimator : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Running");
    }

    public void alienSaved () 
    {
        anim.Play("T-Pose");
    }

	public void alienKilled ()
	{
        anim.Play("Dying Backwards");
	}

	void Update () {}
}
