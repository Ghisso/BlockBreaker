using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    #region Variables

    [SerializeField] int nbBreakableBlocks; //just for debugging
    [SerializeField] int pointsPerBlockDestroyed;
    [SerializeField] int score; //just for debugging
    SceneLoader sceneloader;
    TextMeshProUGUI scoreText;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Ball ball;
    [SerializeField] Paddle paddle;

    #endregion

    #region Unity Methods

    void Start ()
    {
        nbBreakableBlocks = 0;
        score = 0;
        pointsPerBlockDestroyed = 73;
        sceneloader = FindObjectOfType<SceneLoader>();
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = "Score: "+score.ToString();
    }

    private void Update()
    {
        if (ball.isLost == true)
        {
            gameOverPanel.SetActive(true);
            paddle.canMove = false;
            ball.isStarted = false;
        }
    }

    #endregion

    #region My Methods

    public void CountBreakableBlocks()
    {
        nbBreakableBlocks++;
    }


    public void BlockDestroyed()
    {
        nbBreakableBlocks --;
        score += pointsPerBlockDestroyed;
        scoreText.text = "Score: " + score.ToString();
        if (nbBreakableBlocks <= 0)
        {
            nextLevelPanel.SetActive(true);
            paddle.canMove = false;
            ball.isStarted = false;
        }
    }

    #endregion
}
