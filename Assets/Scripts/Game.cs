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

	private AudioClip spawnSFX;

	private void Start() {
		if (instance != null) throw new System.Exception("Two instances of Game cannot coexist");
		instance = this;
		spawnSFX = Resources.Load<AudioClip>("SoundEffect/Spawn");
		player = FindObjectOfType<Player>();
		player.controller.enabled = false;
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
		else StartCoroutine(GoToMainMenu());
	}

	private IEnumerator LoadNextLevel() {
		player.controller.enabled = false;
		yield return UI.instance.sceneTransition.Fade(SceneTransition.FadeDirection.IN);
		yield return SceneManager.UnloadSceneAsync("Level" + currentLevel);
		++currentLevel;
		yield return SceneManager.LoadSceneAsync("level" + currentLevel, LoadSceneMode.Additive);
		FindObjectOfType<Level>().Init();
		SFXPlayer.instance.PlaySFX(spawnSFX);
		yield return UI.instance.sceneTransition.Fade(SceneTransition.FadeDirection.OUT);
		player.controller.ResetStats();
		player.controller.enabled = true;
	}

	private IEnumerator LoadFirstLevel() {
		AsyncOperation ao = SceneManager.LoadSceneAsync("Level" + currentLevel, LoadSceneMode.Additive);
		yield return ao;
		FindObjectOfType<Level>().Init();
		SFXPlayer.instance.PlaySFX(spawnSFX);
		yield return UI.instance.sceneTransition.Fade(SceneTransition.FadeDirection.OUT);
		player.controller.ResetStats();
		player.controller.enabled = true;
	}

	public void SetPause(bool pause) {
		isPaused = pause;
		Time.timeScale = pause ? 0 : 1;
		player.controller.canMove = !pause;
		UI.instance.DisplayPauseMenu(pause);
		Cursor.lockState = pause ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = pause;
	}

	public IEnumerator GoToMainMenu() {
		Time.timeScale = 1;
		player.controller.enabled = false;
		yield return UI.instance.sceneTransition.Fade(SceneTransition.FadeDirection.IN);
		yield return SceneManager.LoadSceneAsync("Menu");
	}

	public bool IsPaused { get => isPaused; }
}
