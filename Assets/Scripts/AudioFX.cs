using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource audioS;
    //sonido del 0 choque
    void Start()
    {
        audioS = GetComponent<AudioSource>();    
    }
    public void FXSonidoChoque() 
    {
        audioS.clip = fxs[0];
        audioS.Play();

    }

    public void FXMusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }
    //sonido del 1 music meme

}
