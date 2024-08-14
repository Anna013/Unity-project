
using UnityEngine;


public class PlayerMovLevel2 : MonoBehaviour
{
 
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sideForce = 500f;
    private Animator anim;


    void FixedUpdate(){

        rb.AddForce(0,0,forwardForce  * Time.deltaTime);

        if(Input.GetKey("d")){
            rb.AddForce(sideForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a")){
            rb.AddForce(-sideForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if(rb.position.y < 20){
            FindObjectOfType<GameManager>().GameOver();
        }
    
    }


}
