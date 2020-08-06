using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelToLoad;
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject crossFade;
    private void Awake()
    {
        crossFade.SetActive(true);
    }
    public void LoadNextLevel(int levelToLoad)
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
