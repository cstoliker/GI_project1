using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public Pooler objectPool;
    public float min = 2f;
    public float max = 3f;

    private void Start()
    {
        StartCoroutine(startSpawning());
        min = transform.position.x;
        max = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 10, min + max) - min, transform.position.y, transform.position.z);
    }

    private void SpawnObject()
    {
        GameObject newItem = objectPool.GetPooledObject();
        newItem.transform.position = transform.position;
        newItem.transform.rotation = transform.rotation;
        newItem.SetActive(true);
    }

    IEnumerator startSpawning()
    {
        while (true)
        {
            int randomTime = UnityEngine.Random.Range(5, 10); //picks a random time
            int randomChance = UnityEngine.Random.Range(0, 100);
            if (randomChance < 50)
            {
                yield return new WaitForSeconds(randomTime);
                SpawnObject();
            }
        }
    }
}