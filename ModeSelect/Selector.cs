using UnityEngine;
using System.Collections;

public class Selector : size {
    RectTransform rect;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        calScale();
    }
	
	// Update is called once per frame
	void Update () {
        rect.localScale = new Vector3(200,160*scaleY,160*scaleX);
	}
}
