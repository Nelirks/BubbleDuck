using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    private Button resumeButton;
    private Button mainMenuButton;
    // Start is called before the first frame update
    void Awake() {
        foreach (Button button in FindObjectsOfType<Button>()) {
            if (button.name == "ResumeButton") resumeButton = button;
            else if (button.name == "MainMenuButton") mainMenuButton = button;
        }
    }

	private void OnEnable() {
        RegisterButtons();
    }

	private void OnDisable() {
        UnregisterButtons();
	}

	private void RegisterButtons() {
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void UnregisterButtons() {
        resumeButton.onClick.RemoveListener(ResumeGame);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
    }

    public void ResumeGame() {
        Game.instance.SetPause(false);
    }

    public void GoToMainMenu() {
        Game.instance.GoToMainMenu();
    }
}
