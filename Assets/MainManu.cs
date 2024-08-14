using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{

    public void StartGame(){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit(){
       Debug.Log("Game is quit");
       Application.Quit();
    }
}
