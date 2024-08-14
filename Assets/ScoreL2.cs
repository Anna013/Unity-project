
using UnityEngine;
using UnityEngine.UI;

public class ScoreL2 : MonoBehaviour
{
    //private PlayerCollision pc;
    public Text scoreText;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Coins: " + FindObjectOfType<PlayerColliderL2>().returnCoins().ToString();

    }
}
