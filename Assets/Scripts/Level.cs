using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Variables

    [SerializeField] int nbBreakableBlocks;
    int pointsPerBlockDestroyed;
    int score;
    SceneLoader sceneloader;

    #endregion

    #region Unity Methods

    void Start ()
    {
        nbBreakableBlocks = 0;
        score = 0;
        pointsPerBlockDestroyed = 73;
        sceneloader = FindObjectOfType<SceneLoader>();
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
        if(nbBreakableBlocks <= 0)
        {
            sceneloader.LoadGameOverScene();
        }
    }

    #endregion
}
