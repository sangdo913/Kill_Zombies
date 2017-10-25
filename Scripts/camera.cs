using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
    
    float xAxis, zAxis;
    AudioSource a;

    // Use this for initialization
    void Start () {
        a = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Player.stopFlg)
        {
            a.Stop();
            return;
        }

        if (Player.playerTransform.position.x < 4 && Player.playerTransform.position.x > -6)
        {
            xAxis = Player.playerTransform.position.x;
        }
	// Update is called once per frame
        if(Player.playerTransform.position.z<3 && Player.playerTransform.position.z>-6)
        {
            zAxis = Player.playerTransform.position.z;
        }
        transform.position = new Vector3(xAxis, 7, zAxis);
       
	}
}
