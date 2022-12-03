using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public static AudioManger audioManger;
    public AudioSource audioSource;
    public AudioClip jumpSound;

    public AudioSource BGMSource;
    public AudioClip[] BGMList;

    // Start is called before the first frame update
    private void Start()
    {
        audioManger = this;

        int lv = GameObject.Find("Canvas").GetComponent<UIController>().level;
        if (lv == -1)
        {
            BGMSource.clip = BGMList[0];
        }else if (lv < 2)
        {
            BGMSource.clip = BGMList[1];
        }
        else if(lv < 6)
        {
            BGMSource.clip = BGMList[2];
        }
        else
        {
            BGMSource.clip = BGMList[3];
        }
        BGMSource.Play();
    }

    void Update()
    {
        BGMSource.volume = PlayerPrefs.GetFloat("BGM");
    }

    public void JumpAudio()
    {
        audioSource.clip = jumpSound;
        audioSource.volume = PlayerPrefs.GetFloat("SFX");
        audioSource.Play();
    }
}
