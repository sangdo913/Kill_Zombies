using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    float HP = 7;
    UnityEngine.AI.NavMeshAgent agent;

    Transform rotation;

    AudioSource[] sound;
    public AudioClip attack;
    public AudioClip dead;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    AudioClip[] hit;

    
    SkinnedMeshRenderer leftHand;

    SphereCollider handCollider;

    Animator Zombieani;

    float waitTime;
    float attackSpeed;

    bool[] mode;
    // Use this for initialization
    void Start () {
        hit = new AudioClip[3];
        hit[0] = hit1;
        hit[1] = hit2;
        hit[2] = hit3;
        
        mode = new bool[3];

        Zombieani = GetComponent<Animator>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sound = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.stopFlg)
        {
            foreach (AudioSource a in sound)
            {
                a.Stop();
            }
            return;
        }
        agent.destination = Player.playerTransform.position;

        

        Zombieani.SetFloat("HP", HP);
        Zombieani.SetFloat("distance",Vector3.Distance(Player.playerTransform.position, transform.position));

        if(HP <= 0)
        {
            agent.speed = 0;
            agent.angularSpeed = 0;
            if (sound[0].clip != dead)
            {
                int deadmode;
                sound[0].clip = dead;
                sound[0].volume = 0.3f;
                sound[0].Play();

                deadmode = Random.Range(0, 2);
                for (int i = 0; i < 3; i++)
                    mode[i] = false;

                mode[deadmode] = true;

                Zombieani.SetBool("mode1", mode[0]);
                Zombieani.SetBool("mode2", mode[1]);
                Zombieani.SetBool("mode3", mode[2]);
            }
            
            waitTime += Time.deltaTime;

            if (waitTime > 1.5f)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            int deadSound;            

            deadSound = Random.Range(0, 2);            

            if(!sound[0].isPlaying)
            {
                sound[0].clip = hit[deadSound];
                sound[0].volume = 0.3f;
                sound[0].Play();
            }
            
            HP--;
        }
    }
}
