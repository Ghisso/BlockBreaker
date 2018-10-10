using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16.0f;
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update ()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        mousePosX = Mathf.Clamp(mousePosX, 1f, screenWidthInUnits - 1);
        Vector2 paddlePos = new Vector2(mousePosX, transform.position.y);
        transform.position = paddlePos;
	}
}
