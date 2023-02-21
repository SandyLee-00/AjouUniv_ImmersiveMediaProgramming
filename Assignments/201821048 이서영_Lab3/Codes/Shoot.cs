using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private CharacterController controller;
    public float range = 20;
    public Transform gunEndPoint;
    public LayerMask shootableMask;
    public LayerMask GroundMask;
    public AudioSource audioSource;
    bool mousePressed;
    Vector3 mousePosition;
    private int killed = 0;
    private bool isGrounded;

    private GameObject gobj;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        mousePressed = Input.GetMouseButtonDown(0);

        if (mousePressed)
        {
            mousePosition = Input.mousePosition;
            audioSource.Play();
        }

        isGrounded = controller.isGrounded;
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (mousePressed && Physics.Raycast(ray, out hit, range, shootableMask))
        {
            hit.collider.attachedRigidbody.AddForce(ray.direction * 100f);

            if (hit.collider.gameObject.tag == "Pin")
            {
                gobj = hit.collider.gameObject;
                gobj.GetComponent<Renderer>().material.color = Color.yellow;
                killed += 1;
                Debug.Log("killed : " + killed);
                hit.collider.gameObject.tag = "killedPin";
            }
            else if (hit.collider.gameObject.tag == "Enemy")
            {
                gobj = hit.collider.gameObject;
                Destroy(gobj);
                killed += 1;
                Debug.Log("killed : " + killed);
            }
            else if (hit.collider.gameObject.tag == "Friend")
            {
                Debug.Log("game over shoot friend");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        else if (!isGrounded && mousePressed && Physics.Raycast(ray, out hit, range, GroundMask))
        {
            float distanceToGround = hit.distance;
            Debug.Log("distanceToGround : " + distanceToGround);
        }
    }
}
