using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private List<Bubble> bubbles = new List<Bubble>();

	private void Start() {
		foreach (Bubble bubble in GetComponentsInChildren<Bubble>()) {
			AddBubble(bubble);
		}
		Game.instance.player.transform.position = GetComponentInChildren<SpawnPoint>().transform.position;
	}

	private void AddBubble(Bubble bubble) {
		bubbles.Add(bubble);
		bubble.SubscribeToLevel(this);
	}

	public void NotifyBubbleCaught(Bubble bubble) {
		bubbles.Remove(bubble);
		if (bubbles.Count == 0) GoToNextLevel();
	}

	private void GoToNextLevel() {
		Game.instance.GoToNextLevel();
	}
}
