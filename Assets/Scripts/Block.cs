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
        respawnTimer = 0f;
        respawnTimerActive = false;
        maxHits = hitSprites.Length;
        respawnPhase = 1;
        if (tag != "Unbreakable")
            level.CountBreakableBlocks();
    }


    void Update()
    {
        UpdateColliderTimer();
        if(tag == "Respawn")
            HandleRespawn();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Unbreakable" && canCollide)
        {
            HandleHit();
        }
    }

    #endregion


    #region My Methods

    private void HandleRespawn()
    {
        if (respawnTimerActive)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= respawnPhase * timeToRespawn / maxHits)
            {
                nbHits--;
                mySpriteRenderer.sprite = hitSprites[nbHits];
                respawnPhase++;
            }
            if (respawnPhase > maxHits)
            {
                respawnPhase = 1;
                myBoxCollider2D.enabled = true;
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 1f);
                level.CountBreakableBlocks();
                respawnTimerActive = false;
                respawnTimer = 0;
            }
        }
    }


    private void UpdateColliderTimer()
    {
        collideTimer += Time.deltaTime;
        canCollide |= collideTimer > collideTime;
    }


    private void HandleHit()
    {
        nbHits++;
        if (nbHits >= maxHits && tag == "Respawn")
        {
            myBoxCollider2D.enabled = false;
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 0.3f);
            level.BlockDestroyed();
            respawnTimerActive = true;
        }
        else if (nbHits >= maxHits && tag != "Respawn")
        {
            Destroy(gameObject);
            level.BlockDestroyed();
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
