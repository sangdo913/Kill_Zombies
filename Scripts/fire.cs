using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.firePoint.x + 0.9f*Player.playerTransform.forward.x,
            1.1f * Player.firePoint.y,
            Player.firePoint.z + 0.9f*Player.playerTransform.forward.z);
        transform.rotation = Player.playerTransform.rotation;
        Destroy(gameObject, 0.1f);
	}
}
