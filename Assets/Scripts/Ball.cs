﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    #region Variables

    public bool isLost { get; private set;} = false;
    public bool isStarted { get; set; } = false;
    Paddle paddle;
    Rigidbody2D myRigidbody2D;

    [SerializeField] [RangeAttribute(0, 50)]
    float xPush = 2.0f, yPush = 15.0f;

    [SerializeField] [RangeAttribute(0, 2)]
    float randomPush = 0.2f;

    float yOffset;

    #endregion

    #region Unity Methods

    void Start ()
    {
        paddle = FindObjectOfType<Paddle>();
        yOffset = transform.position.y - paddle.transform.position.y;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {
        if(!isStarted)
        {
            Vector2 newBallPos = new Vector2(paddle.transform.position.x, paddle.transform.position.y + yOffset);
            transform.position = newBallPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
            
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(randomPush, randomPush);
        myRigidbody2D.velocity += velocityTweak;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLost = true;
    }

    #endregion
}
