using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0F;

    //private bool isfollowing = true;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // look at the target
        transform.LookAt(target);
        //// Method 1: Translate() -- move forward.
        //// This requires turning towards the target, which we did above.
        //Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        //transform.Translate(movement);

        // Method 2: MoveTowards() -- move towards the target's position.
        // This works also without turning towards the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
