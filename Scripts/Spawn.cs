using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject monster;

    float waitTime = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        waitTime += Time.deltaTime;

        if (waitTime > 10f)
        {
            Instantiate(monster, transform.position, transform.rotation);
            waitTime = 0;
        }
	}
}
