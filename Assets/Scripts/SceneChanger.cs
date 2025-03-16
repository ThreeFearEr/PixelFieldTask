using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public static SceneChanger Instance;
    private void Awake() {
        if(Instance == null) Instance = this;
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    /// <summary>
    /// Usedd for cycling levels when the level is done
    /// </summary>
    public void NextLevel() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else {
            SceneManager.LoadScene("menu");
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
