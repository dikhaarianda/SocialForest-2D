using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    public void BackScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName);
    }
}
