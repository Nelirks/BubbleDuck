using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	private Level level;

	public void SubscribeToLevel(Level level) {
		this.level = level;
	}

	private void OnTriggerEnter(Collider other) {
		level.NotifyBubbleCaught(this);
		Destroy(gameObject);
	}
}
