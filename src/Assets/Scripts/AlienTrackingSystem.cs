using UnityEngine;
using System.Collections;
public class AlienTrackingSystem : MonoBehaviour
{
	// The target marker.
	private Transform target;
    public GameObject[] alienTargets;

	// Angular speed in radians per sec.
	public float speed;

    void FindTarget() {

        // Create Array of available targets.
        alienTargets = GameObject.FindGameObjectsWithTag("Alien");

        if(alienTargets.Length > 0) {
            AssignTarget();
        }

    }

    void AssignTarget()
    {
        int targetIndex = Random.Range(0, alienTargets.Length -1);
        target = alienTargets[targetIndex].transform;
    }

	void Update()
	{

        if (target != null)
        {

            Vector3 targetDir = target.position - transform.position;
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

        } else {

            FindTarget();

        }

	}
}

