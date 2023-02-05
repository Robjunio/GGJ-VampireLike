using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounf : MonoBehaviour
{

    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = audioData.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundButton(AudioClip sonzinho)
    {
        AudioClip otherClip = sonzinho;
        audioData.clip = otherClip;
        audioData.Play();
    }
}
