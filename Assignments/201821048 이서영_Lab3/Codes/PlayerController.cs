using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;

    private float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float pushPower = 2.0f;
    private Vector3 velocity;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * y;

        controller.Move(direction * speed * Time.deltaTime);

       
        //move the controller
        controller.Move(velocity * Time.deltaTime);
    }
}
