using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMov player;
    

    [HideInInspector]
    public int nCoins = 0;

    void OnCollisionEnter(Collision c) {

        if(c.collider.tag == "Jump"){
            FindObjectOfType<GameManager>().BigJump();
        }
        
        if(c.collider.tag == "Sphere") {
            FindObjectOfType<AudioManager>().Play("Death");
            Debug.Log("hit sphere");
            player.Death();
            FindObjectOfType<GameManager>().GameOver();

        }
        

    }

     void OnTriggerEnter(Collider c) {
        if(c.gameObject.layer == 7){
            Destroy(c.gameObject);
            FindObjectOfType<AudioManager>().Stop("Coin");
            FindObjectOfType<AudioManager>().Play("Coin");
            nCoins++;
            //Debug.Log("coins col " + nCoins);
        }

        if(c.GetComponent<Collider>().tag == "Fall") {
            FindObjectOfType<AudioManager>().Play("Death");
            Debug.Log("hit sphere");
            player.Death();
            FindObjectOfType<GameManager>().GameOver();

        }

     }

     public int returnCoins(){
         return nCoins;
     }

}
