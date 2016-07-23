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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey("1"))
        {
            keyPressed = 1;
        }
        else if (Input.GetKey("2"))
        {
            keyPressed = 2;
        }
        else if (Input.GetKey("3"))
        {
            keyPressed = 3;
        }

        Movement(horizontal, vertical);

    } 

    void Movement(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            if (keyPressed == 1 || keyPressed == 2)
            {
                characterAnimator.SetBool("isWalking", false);
                characterAnimator.SetFloat("speed", 5f);
            }
            else if (keyPressed == 3)
            {
                characterAnimator.SetFloat("speed", 0f);
                characterAnimator.SetBool("isWalking", true);
            }
            //characterAnimator.SetFloat("speed", 5f);
            CharacterRotation(h,v);
            GetComponent<Rigidbody>().velocity = new Vector3(h * characterSpeed, 0f, v * characterSpeed);
            //Vector3 movingSpeed = new Vector3(h*characterSpeed, 0f, v*characterSpeed);
            Vector3 currentPosition = GetComponent<Rigidbody>().position;
            GetComponent<Rigidbody>().MovePosition(currentPosition + GetComponent<Rigidbody>().velocity * Time.deltaTime);
        }
        else if (h == 0f && v == 0f)
        {
            characterAnimator.SetFloat("speed", 0.00f);
        }
        
    }


    void CharacterRotation(float h, float v)
    {
        Vector3 facingDirection = new Vector3(h, 0f, v);

        Quaternion finalRotation = Quaternion.LookRotation(facingDirection, Vector3.up);

        Quaternion incrementRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, finalRotation, turnSmoother * Time.deltaTime);

        GetComponent<Rigidbody>().MoveRotation(incrementRotation);
    }

    void OnCollisionEnter(Collision collisionObject)
    {
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        characterAnimator.SetFloat("speed", 0.00f);
    }
    

}
