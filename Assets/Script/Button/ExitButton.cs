using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    public GameObject quit;
    private Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        exitButton = GetComponent<Button>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;


        #else 
            Application.Quit();

        #endif
    }
}
