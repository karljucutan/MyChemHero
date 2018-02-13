using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueAnimator : MonoBehaviour {

    Image img;
    private Color original, newColor;

	// Use this for initialization
	void Start () {
        newColor = new Color32(0,130,120,255);
        img = gameObject.GetComponent<Image>();
        original = img.color;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector4(Mathf.PingPong(Time.time,0.5f)+1,transform.localScale.x, transform.localScale.y, transform.localScale.z);
        float t = Mathf.PingPong(Time.time, 1.0f);
        img.color = Color.Lerp(original, newColor, t);
	}
}
