using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolling : MonoBehaviour
{
    public Transform[] points;
    int current; 
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*Time.deltaTime);
            Vector3 targetDirection = points[current].position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
