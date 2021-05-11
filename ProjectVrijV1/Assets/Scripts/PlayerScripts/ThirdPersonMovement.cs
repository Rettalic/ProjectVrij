using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Rigidbody rb;

    //Player Movement--------------------------------
    public float speed = 12f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jump = 0.5f;
    private float jumpHeight;
    Vector3 velocity;
    bool isGrounded;
    public float dash = 5f;
    public float standardSpeed = 12f;
    //player movement end --------------------------

    //timer-----------------------------------------
    public float coolDownTime = 2f;
    private float nextFireTime = 0;

    //collision-------------------------------------
    bool bColliding;
    public Transform colliderCheck;
    public float radiusCollider = 0.4f;
    //collision end --------------------------------

    private float jumpTimer;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpHeight = jump;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded == true)
        {
            Debug.Log("we landed");
        }

        //get input for movement from standard thing with ASWD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bColliding = Physics.Raycast(colliderCheck.position, transform.TransformDirection(new Vector3(x, 0, z)), radiusCollider);

        /* if (Time.time > nextFireTime)
         {
             if (Input.GetKeyDown(KeyCode.LeftShift) && z == 1 || Input.GetKeyDown(KeyCode.Q) && z == 1)
             {
                 speed = dash;
                 nextFireTime = Time.time + coolDownTime;
             }
             else
             {
                 speed = standardSpeed;
             }
         }
         */

        //collision detection and nullifying speed.
        if (!bColliding)
        {
            transform.Translate(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed);
        }
        //Jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }

        //shoot detection
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fire!");
        }

        //timer
        if (jumpTimer >= 0)
        {
            jumpTimer = jumpTimer - Time.deltaTime;
        }

        if (jumpTimer <= 0 && jumpHeight != jump)
        {
            jump = jumpHeight;
        }




    }

    public void JumpBuff(float jumpTimer, float multiplier)
    {
        this.jumpTimer = jumpTimer;
        jump *= multiplier;
        Debug.Log("Jumpin" + multiplier);
    }

}