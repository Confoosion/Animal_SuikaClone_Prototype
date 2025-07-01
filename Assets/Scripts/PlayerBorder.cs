using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public float xPosition;

    void OnTriggerEnter2D(Collider2D player)
    {
        player.transform.position = new Vector2(xPosition, 9.45f);
        Debug.Log("border");
    }
}
