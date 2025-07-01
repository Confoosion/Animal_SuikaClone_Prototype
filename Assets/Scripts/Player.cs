using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float move = 0f;
    private Rigidbody2D rigidBody;
    public GameObject playerObject;
    public float speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        //if(playerObject.transform.position.x > -2f && playerObject.transform.position.x < 8f)
        rigidBody.velocity = new Vector2(move * speed, 0f);
        if(playerObject.transform.position.x < -2f)
        {
            playerObject.transform.position = new Vector2(-2f, playerObject.transform.position.y);
        }
        else if(playerObject.transform.position.x > 8f)
        {
            playerObject.transform.position = new Vector2(8f, playerObject.transform.position.y);
        }
    }
}
