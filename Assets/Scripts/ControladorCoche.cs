using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject cocheGO;
    public int anguloDeGiro=1;
    public int velocidad=30;
    // Start is called before the first frame update
    void Start()
    {
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        float giroEnZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);
        giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;

        cocheGO.transform.rotation = quaternion.Euler(0, 0, giroEnZ);
    }
}
