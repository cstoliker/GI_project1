using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
