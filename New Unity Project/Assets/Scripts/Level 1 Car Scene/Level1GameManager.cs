using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1GameManager : MonoBehaviour
{
    public Image distanceBar;
    public GameObject player;
    LevelLoader LevelLoader;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        LevelLoader = FindObjectOfType<LevelLoader>();
        StartCoroutine(AddDistance());
    }
    

    IEnumerator AddDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / (4 - (player.GetComponent<PlayerCar>().screenPos.x * 2f)));
            distanceBar.fillAmount += 0.01f;
            Debug.Log(0.5f / (2 - (player.GetComponent<PlayerCar>().screenPos.x * 1f)));
            if(distanceBar.fillAmount >= 1f)
            {
                StopCoroutine(AddDistance());
                LevelLoader.LoadNextLevel(0);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
