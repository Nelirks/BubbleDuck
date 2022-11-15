using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EnableButtons();
    }

    private void EnableButtons() {
        playButton.interactable = true;
        quitButton.interactable = true;
	}

    private void DisableButtons() {
        playButton.interactable = false;
        quitButton.interactable = false;
    }

    public void StartGame() {
        DisableButtons();
        SceneManager.LoadSceneAsync("Game");
	}

    public void QuitGame() {
        DisableButtons();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit ();
    #endif
    }
}
