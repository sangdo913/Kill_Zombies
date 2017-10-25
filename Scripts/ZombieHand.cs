using UnityEngine;
using System.Collections;

public class ZombieHand : MonoBehaviour {
    AudioSource[] attack;
    SphereCollider hand;
    SkinnedMeshRenderer handPosition;
    Transform zombie;

    public AudioClip sound;
    float waitTime=0.5f;
    public  bool isHit = false;

    // Use this for initialization
    void Start () {
        attack = GetComponents<AudioSource>();
        hand = GetComponent<SphereCollider>();
        handPosition = GetComponent<SkinnedMeshRenderer>();
        zombie = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.stopFlg)
        {
            foreach(AudioSource a in attack)
            {
                a.Stop();
            }
            return;
        }
        transform.rotation = Quaternion.Euler(0,-zombie.transform.rotation.y,0);
        hand.center = handPosition.bounds.center - zombie.position;
        waitTime += Time.deltaTime;
        if (isHit)
            isHit = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if(waitTime >1f)
            {
                isHit = true;
                attack[0].clip = sound;
                attack[0].volume = 0.2f;
                attack[0].Play();
                waitTime = 0;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isHit = false;
    }

}
