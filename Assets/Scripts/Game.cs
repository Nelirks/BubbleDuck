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

	private void Start() {
		if (instance != null) throw new System.Exception("Two instances of Game cannot coexist");
		instance = this;
		player = FindObjectOfType<Player>();
		StartCoroutine(LoadFirstLevel());
	}

	public void GoToNextLevel() {
		Debug.Log(currentLevel + " / " + maxLevel);
		if (currentLevel < maxLevel) {
			StartCoroutine(LoadNextLevel());
		}
		else Debug.Log("MAX LEVEL REACHED"); 
	}

	private IEnumerator LoadNextLevel() {
		AsyncOperation ao = SceneManager.UnloadSceneAsync("Level" + currentLevel);
		yield return ao;
		++currentLevel;
		ao = SceneManager.LoadSceneAsync("level" + currentLevel, LoadSceneMode.Additive);
		yield return ao;
	}

	private IEnumerator LoadFirstLevel() {
		AsyncOperation ao = SceneManager.LoadSceneAsync("Level" + currentLevel, LoadSceneMode.Additive);
		yield return ao;
	}

}
