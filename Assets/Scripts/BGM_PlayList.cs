using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_PlayList : MonoBehaviour
{
    public AudioClip[] BGM_clips;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = RandomClip();
            audioSource.Play();
        }
    }
    private AudioClip RandomClip()
    {
        int random = Random.Range(0, BGM_clips.Length);
        return BGM_clips[random];
    }
}
