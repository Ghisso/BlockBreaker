using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour 
{
    BoxCollider2D myBoxCollider2D;
    SpriteRenderer mySpriteRenderer;
    [SerializeField] Sprite[] hitSprites;
    int nbHits;
    Level level;

	// Use this for initialization
	void Start ()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        nbHits = 0;
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        nbHits++;
        int maxHits = hitSprites.Length;
        if(nbHits >= maxHits)
        {
            Destroy(gameObject);
            level.BlockDestroyed();
        }
        else
        {
            DisplayNextSprite();
        }
    }

    private void DisplayNextSprite()
    {
        mySpriteRenderer.sprite = hitSprites[nbHits];
    }
}
