using UnityEngine;
using System.Collections;

public class size : MonoBehaviour {
    public const float screenWidth = 1280;
    public const float screenHeight = 720;
    public const float msgY = screenWidth/2;
    public const float msgX = screenHeight/2;

    RectTransform ract;

    public float scaleX;
    public float scaleY;

    float msgPosY;
    float msgPosX;

    // Use this for initialization
    void Start () {
        ract = GetComponent<RectTransform>();
        calScale();
      
        ract.localScale = new Vector3 (scaleX,scaleY,0);
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);

    }

    public void calScale()
    {
        scaleX = Screen.width / screenWidth;
        scaleY = Screen.height / screenHeight;

        msgPosY = msgY * scaleY;
        msgPosX = msgX * scaleX;
    }
}
