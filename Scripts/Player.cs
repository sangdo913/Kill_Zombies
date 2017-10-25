using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    float HP = 5;
    public GameObject fire;
    public GameObject gameOverLogo;

    public GameObject bullet;
    public static float damage;
    public static float speed = 3;
    public float attackSpeed;
    public float rotationSpeed;
    public Transform fireStartPosition;
    public static Vector3 firePoint;
    public static Transform playerTransform;

    public static Vector3 direction;

    Animation player;
    AnimationState motion;
    

    float attackWaitTime;

    public static AudioSource[] playerAudio;
    public AudioClip footStep;
    public AudioClip attack;
    public AudioClip ouch;
    public AudioClip GameOver;

    Ray ray;
    RaycastHit hit;
    Vector3 forward;
    Vector3 firePosition;

    public static bool stopFlg = false;


    CharacterController characterController;

    // Use this for initialization
    void Start() {
        playerTransform = GetComponent<Transform>();
        player = GetComponent<Animation>();
        characterController = GetComponent<CharacterController>();
        playerAudio = GetComponents<AudioSource>();
        attackWaitTime = 10;      
}
	
	// Update is called once per frame
	void Update () {
        if(stopFlg)
        {
            foreach(AudioSource a in playerAudio)
            {
                a.Stop();
            }
            if (stopFlg && Input.GetButtonDown("SELECT"))
            {
                SceneManager.LoadScene("ModeSelect");
            }
            return;
        }
        firePoint = fireStartPosition.position;
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, 100);

        forward = Vector3.Slerp(transform.forward,
                new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z),
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z)));


        transform.LookAt(transform.position + forward);
        

        if (direction.sqrMagnitude>0)
        {
            transform.position +=direction * speed * Time.deltaTime;
            player.Play("run_forward");
            playerAudio[0].clip = footStep;
            if(!playerAudio[0].isPlaying)
                playerAudio[0].Play();
        }
        else
        {
            player.Play("idle");
            playerAudio[0].Stop();
        }

        if (Input.GetButton("Fire1"))
        {
            if (attackWaitTime > attackSpeed)
            {
                firePosition = new Vector3(fireStartPosition.position.x + 1f * transform.forward.x,
                    fireStartPosition.position.y,
                    fireStartPosition.position.z + 1f * transform.forward.z);

                Instantiate(fire, firePosition, Quaternion.FromToRotation(Vector3.forward, new Vector3(transform.forward.x,0,transform.forward.z)));
  
                Instantiate(bullet, firePosition, Quaternion.FromToRotation(Vector3.forward, new Vector3(transform.forward.x, 0, transform.forward.z)));

                if (!playerAudio[1].isPlaying)
                {
                    playerAudio[1].clip = attack;
                    playerAudio[1].Play();
                }
                else
                {
                    if (!playerAudio[2].isPlaying)
                    {
                        playerAudio[2].clip = attack;
                        playerAudio[2].volume = playerAudio[1].volume;
                        playerAudio[2].Play();
                    }
                }
                attackWaitTime = 0;
            }
        }
        attackWaitTime += Time.deltaTime;

        if((HP<0 || transform.position.y < -5) && !stopFlg)
        {
            Instantiate(gameOverLogo, transform.position, transform.rotation);
            playerAudio[0].clip = GameOver;
            playerAudio[0].volume = 0.3f;
            playerAudio[0].Play();
            stopFlg = true;
            Time.timeScale = 0;
        }

       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ZombieHand")
        {
            ZombieHand zombieHand = collision.gameObject.GetComponent<ZombieHand>();
            if(zombieHand.isHit)
            {
                HP--;
                Debug.Log("맞았습니다!");
            }
        }
       


    }
}

