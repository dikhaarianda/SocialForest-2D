using UnityEngine;
using UnityEngine.SceneManagement;

public class TrachScene : MonoBehaviour
{
    [SerializeField] private GameObject trash;
    [SerializeField] private string changeScene;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if(trash == null)
            {
                SceneManager.LoadScene(changeScene);
            }
        }
    }
}