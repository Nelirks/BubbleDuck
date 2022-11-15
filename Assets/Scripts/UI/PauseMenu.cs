using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public Button resumeButton;
    public Button mainMenuButton;

	private void OnEnable() {
        EnableButtons();
    }

	private void OnDisable() {
        DisableButtons();
	}

	private void EnableButtons() {
        resumeButton.interactable = true;
        mainMenuButton.interactable = true;
    }

    private void DisableButtons() {
        resumeButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void ResumeGame() {
        Game.instance.SetPause(false);
    }

    public void GoToMainMenu() {
        Game.instance.GoToMainMenu();
    }
}
