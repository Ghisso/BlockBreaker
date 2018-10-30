using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    #region My Methods

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadStartScene()
    {
        //FindObjectOfType<Level>().Reset();
        SceneManager.LoadScene(0);
    }


    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public int GetTotalNumberOfScenesInBuild()
    {
        return SceneManager.sceneCountInBuildSettings;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
