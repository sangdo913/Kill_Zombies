using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{

    public AudioClip attackObstacle;
    public AudioClip attackZombie;

    public float speed;

    float WaitTime;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        direction = new Vector3(transform.forward.x, 0, transform.forward.z);

        transform.position +=direction * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.collider.tag == "Obstacle")
        {
            if (!Player.playerAudio[3].isPlaying)
            {
                Player.playerAudio[3].clip = attackObstacle;
                Player.playerAudio[3].volume = 0.05f;
                Player.playerAudio[3].Play();
                
            }
            else if(!Player.playerAudio[4].isPlaying)
            {
                Player.playerAudio[4].clip = attackObstacle;
                Player.playerAudio[4].volume = 0.05f;
                Player.playerAudio[4].Play();
                
            }
            else if (!Player.playerAudio[5].isPlaying)
            {
                Player.playerAudio[5].clip = attackObstacle;
                Player.playerAudio[5].volume = 0.05f;
                Player.playerAudio[5].Play();
                
            }
            Destroy(gameObject);
         }
        else if (collision.collider.tag == "Zombie")
         {
            if (!Player.playerAudio[3].isPlaying)
            {
                Player.playerAudio[3].clip = attackZombie;
                Player.playerAudio[3].volume = 0.2f;
                Player.playerAudio[3].Play();
            }
            else if (!Player.playerAudio[4].isPlaying)
            {
                Player.playerAudio[4].clip = attackZombie;
                Player.playerAudio[4].volume = 0.2f;
                Player.playerAudio[4].Play();
            }
            else
            {
                Player.playerAudio[5].clip = attackZombie;
                Player.playerAudio[5].volume = 0.2f;
                Player.playerAudio[5].Play();
            }
            Destroy(gameObject);
         }

    }
}
