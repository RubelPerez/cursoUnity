using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject ContenedorCallesGo;
    public GameObject[] ContenedorCallesArray;
    public Vector3 medidaLimitePantalla;

    public bool salioDePantalla;
    int ContadorCalles = 0;
    int numeroSelectorCalles;
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;
    public GameObject calleAnterior;
    public GameObject calleNueva;
    public float tamañoCalle;
    public GameObject mCamGo;
    public Camera mCampComp;
    void Start()
    {
        InicioJuego();
    }

    void InicioJuego() 
    {
        ContenedorCallesGo = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCampComp = mCamGo.GetComponent<Camera>();
        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
    }

    void VelocidadMotorCarretera() 
    {
        velocidad = 30;
    }
    void Update()
    {
        if (inicioJuego==true && juegoTerminado==false) { 
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoCalles();

            }
            
        }

      
    }
    void DestruyoCalles() 
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
        CrearCalles();
    
    }
    void MedirPantalla() 
    {
        medidaLimitePantalla = new Vector3(0, mCampComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f,0);
    }
    void BuscoCalles() 
    {
        ContenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        for (int i=0; i< ContenedorCallesArray.Length; i++) 
        {
            ContenedorCallesArray[i].gameObject.transform.parent = ContenedorCallesGo.transform;
            ContenedorCallesArray[i].gameObject.SetActive(false);
            ContenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        CrearCalles();
    }

    void CrearCalles() 
    {
        ContadorCalles++;
        numeroSelectorCalles = Random.Range(0, ContenedorCallesArray.Length);
        GameObject Calle = Instantiate(ContenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + ContadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }
    void PosicionoCalles() 
    {
        calleAnterior = GameObject.Find("Calle"+(ContadorCalles-1));
        calleNueva = GameObject.Find("Calle" + ContadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(
            calleAnterior.transform.position.x,
            calleAnterior.transform.position.y+tamañoCalle,
            0
            );
        salioDePantalla = false;
    }
    void MidoCalle() 
    {
        for (int i =0; i<calleAnterior.transform.childCount;i++) 
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null) 
            { 
            float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
            tamañoCalle = tamañoCalle + tamañoPieza;
            }
        }
    }
}
