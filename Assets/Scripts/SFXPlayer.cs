using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer instance;

    private AudioSource audioSource;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void PlaySFX(AudioClip sfx) {
        audioSource.clip = sfx;
        audioSource.Play();
    }
}
