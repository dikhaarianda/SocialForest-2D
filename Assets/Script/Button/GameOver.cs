using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName;

    public void BackScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
