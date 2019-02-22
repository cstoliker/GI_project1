using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    private GameManager gameManager;
    public GameObject Explosion;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameManager.instance.SetHealth();
    }

    // Update is called once per frame
    void Update() {
        float xSpeed;
        float ySpeed;

        if (Input.GetKey(KeyCode.D)) {
            xSpeed = 1;
        } else if (Input.GetKey(KeyCode.A)) {
            xSpeed = -1;
        } else {
            xSpeed = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            ySpeed = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            ySpeed = -1;
        } else {
            ySpeed = 0;
        }

        rb.velocity = new Vector2(xSpeed, ySpeed) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            GameManager.instance.LoseHealth();
            if (GameManager.instance.GetHealth() <= 0)
            {
                PlayExplosion();
                Die();
            }

        } else if (collision.gameObject.CompareTag("token"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameManager.instance.AddScore();
            if (GameManager.instance.GetHealth() < 3)
            {
                GameManager.instance.GainHealth();
            }
            else if (GameManager.instance.GetHealth() >= 3)
            {
                GameManager.instance.SetHealth();
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
