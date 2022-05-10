using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public FixedJoystick moveJoystick;   
    private Rigidbody rdb;
    public GameObject currentCamera;
    private float moveH, moveV, speedMove = 5;
    float jumptime;
    public Animator anim;
    public float jumpspeed = 8;
    public float gravity = 20;
    public Transform rightHandObj, leftHandObj;
    private float verticalVelocity;
    bool jumpbtn = false;
    bool jumpbtndown = false;
    bool jumpbtnrelease = false;
    public Movimentacao controller;



    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        currentCamera = Camera.main.gameObject;
        controller = GetComponent<Movimentacao>();
    }

    public void Jump()
    {
        jumptime -= Time.fixedDeltaTime;
        jumptime = Mathf.Clamp01(jumptime);
        rdb.AddForce(Vector3.up * jumptime * jumpspeed);
    }

    void Update()
    {
        movePlayer();

        if (Input.GetButtonDown("Jump"))
        {
            jumpbtn = true;
            jumpbtndown = true; 
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpbtn = false;
            jumptime = 0;

            /*if (controller.isGrounded)
            {
                verticalVelocity = -gravity * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity = jumpspeed;
                }
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;   
            }
            Vector3 moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y =Input.GetAxis("Vertical");
            controller.Move(moveVector * Time.deltaTime);*/

        }
    }

    void movePlayer()
    {
        //moveH = Input.GetAxis("Horizontal");
        //moveV = Input.GetAxis("Vertical");
        moveH = moveJoystick.Horizontal;
        moveV = moveJoystick.Vertical;
        Vector3 dir = new Vector3 (moveH, 0, moveV);
        rdb.velocity = new Vector3(moveH*speedMove, rdb.velocity.y, moveV*speedMove);
        if (dir != Vector3.zero)
        {
            transform.LookAt(transform.position + dir);
        }
    }

    void FixedUpdate()
    {
        Vector3 relativedirection = currentCamera.transform.TransformVector(moveH, 0 ,moveV);
        relativedirection = new Vector3(relativedirection.x, jumptime, relativedirection.z);

        Vector3 relativeDirectionWOy = relativedirection;
        relativeDirectionWOy = new Vector3(relativedirection.x, 0, relativedirection.z);

        anim.SetFloat("Speed", rdb.velocity.magnitude);
    }


 

}
