using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorAnimator : MonoBehaviour {

    private Text text;
    private Color[] colors;
    private float duration = 4;

    // Use this for initialization
    void Start () {
        colors = new Color[]{Color.blue, Color.red, Color.green, Color.yellow, Color.blue};
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float t = Mathf.Repeat(Time.time, duration) / duration;
        text.color = AdvColorLerp(t, colors);
    }

    public static Color AdvColorLerp(float t, params Color[] colors)
    {
        int c = colors.Length - 1;  // number of transitions
        t = Mathf.Clamp01(t) * c;   // expand t from 0-1 to 0-c
        int index = (int)Mathf.Clamp(Mathf.Floor(t), 0, c - 1); // get current index and clamp
        t -= index; // subract the index to get back a value of 0-1
        return Color.Lerp(colors[index], colors[index + 1], t);
    }
}
