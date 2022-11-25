using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpBubble : Bubble
{
	[SerializeField] private float jumpUpPower = 4.0f;

	protected override void OnTriggerEnter(Collider other) {
		other.GetComponent<PlayerController>().jumpSpeed += jumpUpPower;
		base.OnTriggerEnter(other);
	}
}
