
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool endGame = false;
    public float delay = 1f;
    public GameObject complteLevel;
     public PlayerMov player;

    public void GameOver(){
        if(endGame == false){
            Debug.Log("game over");
            endGame = true;
            Invoke("Restart", delay);
        }
        

    }

    public void BigJump(){
         Debug.Log("Big Jump");
         player.velocity.y = Mathf.Sqrt(400);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("restart  "+ SceneManager.GetActiveScene().name);
    }

    public void Win(){
        Debug.Log("win");
        complteLevel.SetActive(true);
    }
    
}
