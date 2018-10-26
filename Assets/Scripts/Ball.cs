﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    #region Variables

    bool isStarted = false;
    Paddle paddle;
    float yOffset, xPush = 2.0f, yPush = 15.0f, randomPush = 0.1f;
    Rigidbody2D myRigidbody2D;

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
        SceneLoader scene = FindObjectOfType<SceneLoader>();
        scene.LoadGameOverScene();
    }

    #endregion
}
