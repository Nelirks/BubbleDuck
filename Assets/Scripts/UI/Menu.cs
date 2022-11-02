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
        foreach(Button button in FindObjectsOfType<Button>()) {
            if (button.name == "PlayButton") playButton = button;
            else if (button.name == "QuitButton") quitButton = button;
		}
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
