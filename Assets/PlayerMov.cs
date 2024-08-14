using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jump;



    private Vector3 moveDirection;
    public Vector3 velocity;
    private CharacterController controller;
    private Animator anim;

    [SerializeField] private Rigidbody rb;
    public float turnSmoothTime = 0.1f;
    float smoothSpeed;
    public Transform cam;



   private  void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }


    private void Update()
    {
        
        Move();
         

        if(!Input.GetKey(KeyCode.LeftShift) || !isGrounded){
            FindObjectOfType<AudioManager>().Stop("RunGrass");
        }

        if(moveDirection == Vector3.zero || Input.GetKey(KeyCode.LeftShift) || !isGrounded){
            FindObjectOfType<AudioManager>().Stop("Walking");
        }               


    }

    private void Move(){

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0){
                velocity.y = -2f;
                
        }

        float moveZ = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        


        if(isGrounded){

             if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
                Walk();
            }

             else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                 FindObjectOfType<AudioManager>().Play("RunGrass");
                Run();
            }

             else if(moveDirection == Vector3.zero ){
                 Idle();
            }
             
            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
             }

        }

        moveDirection *= moveSpeed;

        if(moveDirection.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime; //calculate gravity
        controller.Move(velocity * Time.deltaTime); //aplay gravity

    }



    private void Idle(){
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        FindObjectOfType<AudioManager>().Play("Walking");
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;     
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump(){
        JumpAnim();
        velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        controller.Move(moveDirection * Time.deltaTime);

  
    }

    private void Slide(){
        anim.SetTrigger("slide");
    }

    private void JumpAnim(){
        anim.SetTrigger("Jump");
    }

    public void Death(){
        anim.SetTrigger("Death");
    }

    

    

    

    
}
