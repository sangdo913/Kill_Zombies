using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour {
    public AudioClip Select;
    public AudioClip CompleteSelect;
    public static bool CursorDown;
    bool Stopflg;
    float WaitTime;
    AudioSource Sound;
    Transform SelectorTransform;

    

    // Use this for initialization
    void Start() {
        CursorDown = false;
        Stopflg = false;

        Sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0) Time.timeScale = 1;
        if (Input.GetButtonDown("UP"))
        {
            if (CursorDown == true && Stopflg == false)
            {
                CursorDown = false;
                Sound.clip = Select;
                Sound.Play();
            }
        }

        if (Input.GetButtonDown("DOWN"))
        {
            if(CursorDown == false && Stopflg == false)
            {
                CursorDown = true;
                Sound.clip = Select;
                Sound.Play();
            }
        }

        if(Input.GetButtonDown("SELECT")&& Stopflg == false)
        {
            Stopflg = true;
            Sound.clip = CompleteSelect;
            Sound.Play();
        }
        if(Stopflg == true)
        {
            WaitTime += Time.deltaTime;
            if (WaitTime > 1.5)
            {
                switch (CursorDown)
                {
                    case false:
                        SceneManager.LoadScene("Survival");
                        break;
                }
            }
        }
	}
}

