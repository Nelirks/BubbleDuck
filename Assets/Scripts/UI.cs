using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;
    private TextMeshProUGUI bubbles;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) throw new System.Exception("Multiples instances of UI can't coexist.");
        instance = this;
        bubbles = transform.Find("Bubbles").GetComponent<TextMeshProUGUI>();
        Debug.Log(bubbles);
    }

    public void SetBubbleCount(int count) {
        bubbles.text = count.ToString();
	}
}
