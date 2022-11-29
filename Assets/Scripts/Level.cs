using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private List<Bubble> bubbles = new List<Bubble>();

	public int despawnYLevel = -10;

	private void Update() {
		if (Game.instance.player.transform.position.y <= despawnYLevel) {
			TeleportPlayerToSpawnPoint();
		}
	}

	public void Init() {
		TeleportPlayerToSpawnPoint();
		foreach (Bubble bubble in GetComponentsInChildren<Bubble>()) {
			AddBubble(bubble);
		}
		UI.instance.SetBubbleCount(bubbles.Count);
	}

	private void TeleportPlayerToSpawnPoint() {
		Game.instance.player.controller.TeleportTo(GetComponentInChildren<SpawnPoint>().transform.position);
		Game.instance.player.controller.SetRotation(GetComponentInChildren<SpawnPoint>().transform.rotation.eulerAngles);
	}

	private void AddBubble(Bubble bubble) {
		bubbles.Add(bubble);
		bubble.SubscribeToLevel(this);
	}

	public void NotifyBubbleCaught(Bubble bubble) {
		bubbles.Remove(bubble);
		UI.instance.SetBubbleCount(bubbles.Count);
		if (bubbles.Count == 0) GoToNextLevel();
	}

	private void GoToNextLevel() {
		Game.instance.GoToNextLevel();
	}
}
