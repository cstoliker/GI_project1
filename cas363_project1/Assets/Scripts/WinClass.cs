using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinClass : MonoBehaviour
{
    public GameObject message;
    private GameManager gameManager;

    void Awake()
    {
        message.SetActive(false);
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void Update()
    {
        CheckWin();
    }

    // Update is called once per frame
    public void CheckWin()
    {
        if(GameManager.instance.GetScore() >= 100000)
        {
            message.SetActive(true);
        }
    }
}
