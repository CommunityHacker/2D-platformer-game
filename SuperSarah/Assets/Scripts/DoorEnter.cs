using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEnter : MonoBehaviour {
    // get tag of collider and load by name
    void OnTriggerEnter2D(Collider2D other)
        {
            StartCoroutine(LoadNextLevel());
        }

    IEnumerator LoadNextLevel()
    {

        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
