using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	private RawImage fadeOutUIImage;
	public float fadeSpeed = 0.8f;

	public enum FadeDirection {
		IN, //Alpha = 1
		OUT // Alpha = 0
	}

	private void Start() {
		fadeOutUIImage = GetComponent<RawImage>();
	}

	public IEnumerator Fade(FadeDirection fadeDirection) {
		float alpha = (fadeDirection == FadeDirection.OUT) ? 1 : 0;
		float fadeEndValue = (fadeDirection == FadeDirection.OUT) ? 0 : 1;
		if (fadeDirection == FadeDirection.OUT) {
			while (alpha >= fadeEndValue) {
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
			fadeOutUIImage.enabled = false;
		}
		else {
			fadeOutUIImage.enabled = true;
			while (alpha <= fadeEndValue) {
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
		}
	}

	private void SetColorImage(ref float alpha, FadeDirection fadeDirection) {
		fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
		alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.OUT) ? -1 : 1);
	}
}
