using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float lastSpawn = 0;
    private GameManager gameManager;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjectSpawn();
    }

    void ObjectSpawn()
    {
        Pooler obstaclePool = new Pooler();
        Pooler tokenPool = new Pooler();

        //GameManager.instance.GetReferences();
       
        GameObject asteroid = obstaclePool.GetPooledObject();
        GameObject token = tokenPool.GetPooledObject();

        if ((Time.fixedTime - lastSpawn) > 1.5f)
        {
            if (asteroid != null && Random.Range(0, 100) < 20)
            {
                asteroid.transform.position = new Vector2(transform.position.x, transform.position.y);
                asteroid.SetActive(true);
                lastSpawn = Time.fixedTime;
            } else if (token != null && Random.Range(0, 100) < 25)
            {
                token.transform.position = new Vector2(transform.position.x, transform.position.y);
                token.SetActive(true);
                lastSpawn = Time.fixedTime;
            }
        }
    }
}
