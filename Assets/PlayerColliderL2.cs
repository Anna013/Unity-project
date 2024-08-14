using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderL2 : MonoBehaviour
{

    public PlayerMovLevel2 player;
    [HideInInspector]
    public int nCoins = 0;


    void OnCollisionEnter(Collision c){

        if(c.collider.tag == "Obstacle"){
            FindObjectOfType<AudioManagerL2>().Play("Death");
            player.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        
     
        
    }

    void OnTriggerEnter(Collider c) {

        if(c.gameObject.layer == 7){
            Destroy(c.gameObject);
            FindObjectOfType<AudioManagerL2>().Stop("Coin");
            FindObjectOfType<AudioManagerL2>().Play("Coin");
            nCoins++;
            Debug.Log("coins col " + nCoins);
        }

        if(c.GetComponent<Collider>().tag == "Fall") {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public int returnCoins(){
         return nCoins;
     }
}
