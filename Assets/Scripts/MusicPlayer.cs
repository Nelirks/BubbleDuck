using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    private AudioSource audioSource;

    private AudioClip mainTheme;

	private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(transform.parent.gameObject);
        mainTheme = Resources.Load<AudioClip>("Music/MainTheme");
        audioSource = GetComponent<AudioSource>();
	}
	// Start is called before the first frame update
	void Start()
    {
        audioSource.clip = mainTheme;
        audioSource.Play();
    }
}
