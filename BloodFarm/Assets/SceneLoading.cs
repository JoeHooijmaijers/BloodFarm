using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public string sceneToLoad = "SampleScene";
    public ScoreInt score;

    public void LoadScene()
    {
        score.score = 0;
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
