using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;

    private float endPosition;
    private float spriteHeight;
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        spriteHeight = bottom.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y - spriteHeight);
        endPosition = top.transform.position.y - spriteHeight;
    }



    // Update is called once per frame
    void Update()
    {
        MovePiece(bottom);
        MovePiece(top);

        if(bottom.transform.position.y <= endPosition)
        {
            ResetPiece(bottom);
        }

        if(top.transform.position.y <= endPosition)
        {
            ResetPiece(top);
        }
    }

    void MovePiece(GameObject piece)
    {
        piece.transform.Translate(new Vector3(0f, -transform.up.y * (movementSpeed / 100), 0f));
    }

    void ResetPiece(GameObject piece)
    {
        piece.transform.position = new Vector2(piece.transform.position.x, piece.transform.position.y + spriteHeight * 2);
    }
}
