using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    public GameObject Loader;
    public GameObject img;
    public GameObject screen;
    public Slider loadingSlider;


    public void NextScene(int index)
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(LoadScene(index));
    }

    public IEnumerator LoadScene(int index)
    {
        loadingSlider.value = 0;
        Loader.SetActive(true);
        img.SetActive(true);
        screen.SetActive(false);

        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        float progress = 0;

        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);
            loadingSlider.value = progress;

            if(progress >= 0.9f)
            {
                loadingSlider.value = 1;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
