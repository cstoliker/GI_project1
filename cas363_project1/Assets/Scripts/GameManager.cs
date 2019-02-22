using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static int score;
    private static double health;
    public Text scoreCounter;
    public Text winMessage;
    public Text healthCounter;
    public Text loseMessage;
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        winMessage.text = "";
        loseMessage.text = "";
        ClearScore();
    }

    public Pooler GetObstaclePool(Pooler pooler)
    {
        return pooler;
    }

    public void SetHealth()
    {
        health = 3;
        GameManager.instance.UpdateHealth();
    }

    public void LoseHealth()
    {
        health--;
        GameManager.instance.UpdateHealth();
    }

    public void GainHealth()
    {
        health++;
        GameManager.instance.UpdateHealth();
    }

    public double GetHealth()
    {
        return health;
    }

    public void AddScore()
    {
        score += 500;
        GameManager.instance.UpdateScore();
    }

    public void ClearScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

    void UpdateScore()
    {
        scoreCounter.text = "Score: " + score;
        WinMessage();
    }

    void WinMessage()
    {
        if(score >= 10000)
        {
            winMessage.text = "Congratulations! You Win!";
            Destroy(player);
        }
    }

    void UpdateHealth()
    {
        healthCounter.text = "Health: " + health;
        LoseMessage();
    }

    void LoseMessage()
    {
        if(health <= 0)
        {
            loseMessage.text = "Good thing you aren't a pilot.";
        }
    }
}
