using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	private Level level;
	private static AudioClip sfx;

	private void Start() {
		if (sfx == null) sfx = Resources.Load<AudioClip>("SoundEffect/Bubble");
	}

	public void SubscribeToLevel(Level level) {
		this.level = level;
	}

	private void OnTriggerEnter(Collider other) {
		level.NotifyBubbleCaught(this);
		SFXPlayer.instance.PlaySFX(sfx);
		Destroy(gameObject);
	}
}
