using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public string nextScene;

    public void NextGame()
    {
        SceneManager.LoadScene(nextScene);
    }
}
