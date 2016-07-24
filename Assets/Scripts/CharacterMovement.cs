using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float turnSmoother = 10f;
    public float speedDamping = 0.2f;
    public float characterSpeed = 2f;

    private Animator characterAnimator;
    private int keyPressed = 1;


    void Awake()
    {
        characterAnimator = GetComponent<Animator>();
    }  
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // check for horizontal movement (x-axis)
        float vertical = Input.GetAxis("Vertical"); // check for vertical movement (z-axis)

        // determine camera view and appropriate animation
        if (Input.GetKey("1"))
        {
            keyPressed = 1;
            characterAnimator.SetBool("isWalking", false);
        }
        else if (Input.GetKey("2"))
        {
            keyPressed = 2;
            characterAnimator.SetBool("isWalking", false);
        }
        else if (Input.GetKey("3"))
        {
            keyPressed = 3;
            characterAnimator.SetBool("isWalking", true);
        }

        // check if player is shooting and set appropriate animation
        if (Input.GetKeyDown("e"))
        {
            characterAnimator.SetTrigger("Attack");
        }

        Movement(horizontal, vertical);

    } 

    // controls movement of character
    void Movement(float h, float v)
    {
        // checks if movement is occuring and sets appropriate animations, rotations and movement
        if (h != 0f || v != 0f)
        {
            if (keyPressed == 1 || keyPressed == 2) // 3rd person or orbiting camera
            {
                characterAnimator.SetBool("isWalking", false);
                characterAnimator.SetFloat("speed", 5f);
            }
            else if (keyPressed == 3) // 1st person camera
            {
                characterAnimator.SetFloat("speed", 0f);
                characterAnimator.SetBool("isWalking", true);
            }

            CharacterRotation(h,v);
            GetComponent<Rigidbody>().velocity = new Vector3(h * characterSpeed, 0f, v * characterSpeed);
            Vector3 currentPosition = GetComponent<Rigidbody>().position;
            GetComponent<Rigidbody>().MovePosition(currentPosition + GetComponent<Rigidbody>().velocity * Time.deltaTime);
        }
        else if (h == 0f && v == 0f)
        {
            characterAnimator.SetFloat("speed", 0.00f); // makes animation idle
        }
        
    }

    // performs rotation of character according to direction of movement
    void CharacterRotation(float h, float v)
    {
        Vector3 facingDirection = new Vector3(h, 0f, v);

        Quaternion finalRotation = Quaternion.LookRotation(facingDirection, Vector3.up);

        Quaternion incrementRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, finalRotation, turnSmoother * Time.deltaTime);

        GetComponent<Rigidbody>().MoveRotation(incrementRotation);
    }

    // checks for collision and sets idle animation
    void OnCollisionEnter(Collision collisionObject)
    {
        characterAnimator.SetFloat("speed", 0.00f);
    }
    

}
