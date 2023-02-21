using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isDodgingHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDodgingHash = Animator.StringToHash("isDodging");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {   
        bool isDodging = animator.GetBool(isDodgingHash);
        bool dodgePressed = Input.GetKey("w");
        bool isJumping = animator.GetBool(isJumpingHash);
        bool jumpPressed = Input.GetKey("space");

        if(!isDodging && dodgePressed){
            animator.SetBool(isDodgingHash, true);
        }
        if(isDodging && !dodgePressed){
            animator.SetBool(isDodgingHash, false);
        }
        if(!isJumping && jumpPressed){
            animator.SetBool(isJumpingHash, true);
        }
        if(isJumping && !jumpPressed){
            animator.SetBool(isJumpingHash, false);
        }
    }
}
