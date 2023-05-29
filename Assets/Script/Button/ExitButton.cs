using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public GameObject quit;
    private Button exitButton;

    void Start()
    {
        exitButton = GetComponent<Button>();
    }

    public void ExitQuit()
    {
        PlayerPrefs.DeleteAll();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
