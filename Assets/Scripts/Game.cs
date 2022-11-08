using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] int currentLevel;
	[SerializeField] private int maxLevel;
	public Player player;

    public static Game instance;

	private bool isPaused;

	private void Start() {
		if (instance != null) throw new System.Exception("Two instances of Game cannot coexist");
		instance = this;
		player = FindObjectOfType<Player>();
		SetPause(false);
		StartCoroutine(LoadFirstLevel());
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SetPause(!isPaused);
		}
	}

	public void GoToNextLevel() {
		if (currentLevel < maxLevel) {
			StartCoroutine(LoadNextLevel());
		}
		else GoToMainMenu();
	}

	private IEnumerator LoadNextLevel() {
		player.gameObject.SetActive(false);
		AsyncOperation ao = SceneManager.UnloadSceneAsync("Level" + currentLevel);
		yield return ao;
		++currentLevel;
		ao = SceneManager.LoadSceneAsync("level" + currentLevel, LoadSceneMode.Additive);
		yield return ao;
		FindObjectOfType<Level>().Init();
		Game.instance.player.gameObject.SetActive(true);
	}

	private IEnumerator LoadFirstLevel() {
		AsyncOperation ao = SceneManager.LoadSceneAsync("Level" + currentLevel, LoadSceneMode.Additive);
		yield return ao;
		FindObjectOfType<Level>().Init();
	}

	public void SetPause(bool pause) {
		isPaused = pause;
		Time.timeScale = pause ? 0 : 1;
		player.controller.canMove = !pause;
		UI.instance.DisplayPauseMenu(pause);
		Cursor.lockState = pause ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = pause;
	}

	public void GoToMainMenu() {
		SceneManager.LoadScene("Menu");
	}

	public bool IsPaused { get => isPaused; }
}
