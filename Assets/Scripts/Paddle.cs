﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region Variables

    public bool canMove { get; set; } = true;
    [SerializeField] float screenWidthInUnits = 16.0f;

    #endregion

    #region Unity Methods

    void Start ()
    {
		
	}


    void Update ()
    {
        if(canMove)
        {
            float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            mousePosX = Mathf.Clamp(mousePosX, 1f, screenWidthInUnits - 1);
            transform.position = new Vector2(mousePosX, transform.position.y);
        }

	}

    #endregion
}
