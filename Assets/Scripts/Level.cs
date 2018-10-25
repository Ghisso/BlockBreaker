using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int nbBreakableBlocks;
    int pointsPerBlockDestroyed;
    int score;
    SceneLoader sceneloader;

	// Use this for initialization
	void Start ()
    {
        nbBreakableBlocks = 0;
        score = 0;
        pointsPerBlockDestroyed = 73;
        sceneloader = FindObjectOfType<SceneLoader>();
	}
	
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
}
