using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    #region Variables

    [SerializeField] int nbBreakableBlocks; //just for debugging
    [SerializeField] int pointsPerBlockDestroyed;
    [SerializeField] public int score; //just for debugging
    [SerializeField] public int savedScore;//just for debugging
    [SerializeField] TextMeshProUGUI    scoreText;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Ball ball;
    [SerializeField] Paddle paddle;
    [SerializeField] SceneLoader sceneloader;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Level>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start ()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject tmp = canvas.gameObject.transform.GetChild(0).gameObject;
        scoreText = tmp.GetComponent<TextMeshProUGUI>();
        nextLevelPanel = canvas.gameObject.transform.GetChild(1).gameObject;
        gameOverPanel = canvas.gameObject.transform.GetChild(2).gameObject;
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        sceneloader = FindObjectOfType<SceneLoader>();

        nbBreakableBlocks = 0;
        savedScore = score;
        score = savedScore;
        pointsPerBlockDestroyed = 73;
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
            savedScore = score;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        //Main menu scene
        if (level == 0)
            Reset();
        //Any Scene except Main Menu and GameOver
        else if (level < sceneloader.GetTotalNumberOfScenesInBuild())
        {
            scoreText = FindObjectOfType<TextMeshProUGUI>();

            Canvas canvas = FindObjectOfType<Canvas>();
            GameObject tmp = canvas.gameObject.transform.GetChild(0).gameObject;
            scoreText = tmp.GetComponent<TextMeshProUGUI>();
            nextLevelPanel = canvas.gameObject.transform.GetChild(1).gameObject;
            gameOverPanel = canvas.gameObject.transform.GetChild(2).gameObject;
            ball = FindObjectOfType<Ball>();
            paddle = FindObjectOfType<Paddle>();
            sceneloader = FindObjectOfType<SceneLoader>();
            score = savedScore;
            scoreText.text = "Score: " + score.ToString();
        }
        //Game Over scene
        else
        {
            GameObject tmp = GameObject.Find("ScoreText");
            scoreText = tmp.GetComponent<TextMeshProUGUI>();
            scoreText.text = score.ToString();
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

    #endregion
}
