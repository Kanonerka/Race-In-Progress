using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }
    private AudioClip GetRandomClip() 
    {
        return clips[Random.Range(0,6)];
    
    }
    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            audioSource.clip = GetRandomClip();
            
        }
    }
}
