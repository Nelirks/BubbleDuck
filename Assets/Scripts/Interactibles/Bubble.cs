using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
		Destroy(gameObject);
	}
}
