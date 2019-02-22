using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MovingObjects
{

    // Start is called before the first frame update
    void Start()
    {
        rigidB = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
