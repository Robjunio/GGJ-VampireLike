using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void RetryLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void LoadScene(string lvlName)
    {
        // throw new System.NotImplementedException();
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
    }
}
