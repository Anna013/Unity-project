
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Coins: " + FindObjectOfType<PlayerCollision>().returnCoins().ToString();

    }
}
