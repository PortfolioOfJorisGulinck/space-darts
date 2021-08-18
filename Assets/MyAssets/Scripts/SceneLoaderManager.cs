using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    [SerializeField]
    private float transitionTime = 1.2f;

    [SerializeField]
    private Animator transition;

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    //Coroutine
    private IEnumerator LoadScene(string sceneName)
    {
        // Start animation
        transition.SetTrigger("Start");

        // Wait till the end of the animation
        yield return new WaitForSeconds(transitionTime);

        // load new scene
        SceneManager.LoadScene(sceneName);
    }
}

