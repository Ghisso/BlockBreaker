using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables   

    BoxCollider2D myBoxCollider2D;
    SpriteRenderer mySpriteRenderer;
    [SerializeField] Sprite[] hitSprites;
    int nbHits;
    Level level;
    float respawnTimer;
    [SerializeField] float timeToRespawn = 10f;
    bool respawnTimerActive;
    int maxHits, respawnPhase;
    const float collideTime = 0.15f;
    float collideTimer = 0;
    bool canCollide = true;

    #endregion

    #region Unity Methods

    void Start()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        nbHits = 0;
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        respawnTimer = 0f;
        respawnTimerActive = false;
        maxHits = hitSprites.Length;
        respawnPhase = 1;
    }

    void Update()
    {
        collideTimer += Time.deltaTime;
        canCollide |= collideTimer > collideTime;

        if (respawnTimerActive)
        {
            respawnTimer += Time.deltaTime;
            if(respawnTimer >= respawnPhase * timeToRespawn / maxHits)
            {
                nbHits--;
                mySpriteRenderer.sprite = hitSprites[nbHits];
                respawnPhase++;
            }
            if(respawnPhase > maxHits)
            {
                respawnPhase = 1;
                myBoxCollider2D.enabled = true;
                Color tmp = mySpriteRenderer.color;
                tmp.a = 1f;
                mySpriteRenderer.color = tmp;
                level.CountBreakableBlocks();
                respawnTimerActive = false;
                respawnTimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable" && canCollide)
        {
            HandleHit();
        }
    }

    #endregion

    #region My Methods

    private void HandleHit()
    {
        nbHits++;
        if (nbHits >= maxHits)
        {
            myBoxCollider2D.enabled = false;
            Color tmp = mySpriteRenderer.color;
            tmp.a = 0.3f;
            mySpriteRenderer.color = tmp;
            level.BlockDestroyed();
            respawnTimerActive = true;
        }
        else
        {
            DisplayNextSprite();
        }
        collideTimer = 0f;
    }

    private void DisplayNextSprite()
    {
        mySpriteRenderer.sprite = hitSprites[nbHits];
    }

    #endregion
}
