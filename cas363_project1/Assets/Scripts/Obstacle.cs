using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObjects
{
    public float rotationSpeed;
    public static Pooler objectPool;
    private GameManager gameManager;
    public GameObject Explosion;

    void Start()
    {
        rigidB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(speed);
        Rotate();
    }

    void Rotate()
    {
        rigidB.AddTorque(rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            PlayExplosion();
        }
        if(collision.gameObject.CompareTag("barrier") || collision.gameObject.CompareTag("player"))
        {
            gameObject.SetActive(false);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
