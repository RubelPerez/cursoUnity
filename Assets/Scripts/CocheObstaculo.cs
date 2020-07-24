using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFXGO;
    public AudioFX audioFXScript;

    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFXGO = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFXGO.GetComponent<AudioFX>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coche>() !=null) 
        {
            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject);
        }
    }
}
