using UnityEngine;
using System.Collections;
public class AlienTrackingSystem : MonoBehaviour
{
	// The target marker.
	private Transform target;
    private bool targetAcquired = false;
    public GameObject[] alienTargets;

	// Angular speed in radians per sec.
	public float speed;

    void FindTarget() {

        alienTargets = GameObject.FindGameObjectsWithTag("Alien");

        if (alienTargets != null || alienTargets != null && target == null)
        {
            int targetIndex = Random.Range(0, alienTargets.Length);
            target = alienTargets[targetIndex].transform;
        }

        if (target != null)
        {
            targetAcquired = true;

        } else {
            
            targetAcquired = false;

        }

    }

	void Update()
	{

        if (targetAcquired)
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

