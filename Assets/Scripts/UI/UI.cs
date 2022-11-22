using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    private TextMeshProUGUI bubbles;
    private PauseMenu pauseMenu;
    public SceneTransition sceneTransition;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) throw new System.Exception("Multiples instances of UI can't coexist.");
        instance = this;
        bubbles = transform.Find("Bubbles").GetComponent<TextMeshProUGUI>();
        pauseMenu = GetComponentInChildren<PauseMenu>();
        sceneTransition = GetComponentInChildren<SceneTransition>();
    }

	public void SetBubbleCount(int count) {
        bubbles.text = count.ToString();
	}

    public void DisplayPauseMenu(bool display) {
        pauseMenu.gameObject.SetActive(display);
	}
}
