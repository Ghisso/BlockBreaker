using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour 
{
    BoxCollider2D myBoxCollider2D;
    SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start ()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            Destroy(gameObject);
        }
    }
}
