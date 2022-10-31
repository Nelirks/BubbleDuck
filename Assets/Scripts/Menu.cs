using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Button playButton;
    private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton = transform.Find("Buttons").Find("PlayButton").GetComponent<Button>();
        quitButton = transform.Find("Buttons").Find("QuitButton").GetComponent<Button>();
        RegisterButtons();
    }

    private void RegisterButtons() {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
	}

    private void UnregisterButtons() {
        playButton.onClick.RemoveListener(StartGame);
        quitButton.onClick.RemoveListener(QuitGame);
    }

    public void StartGame() {
        UnregisterButtons();
        SceneManager.LoadSceneAsync("Game");
	}

    public void QuitGame() {
        UnregisterButtons();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit ();
    #endif
    }
}
