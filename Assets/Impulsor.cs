using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulsor : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody rbObjetivo;
    Collider colisionador;
    public float fuerza;
    public int tipoChoque;
    public GameObject objetivo;
    public GameObject blocker;
    public Transform posSpawn;
    private void Awake()
    {
        tipoChoque = Random.Range(1, 4);
        objetivo = GameObject.FindGameObjectWithTag("objetivo");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbObjetivo = objetivo.GetComponent<Rigidbody>();
        colisionador = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Choque"))
        {
            if (tipoChoque == 1)
            {
                rbObjetivo.velocity = (rb.velocity * -1);
            }
            else if (tipoChoque == 2)
            {
                rb.mass = (rbObjetivo.mass / 10);
                blocker = Instantiate(blocker, posSpawn);
                other.gameObject.SetActive(false);
            }
            else if (tipoChoque == 3)
            {
                rb.mass = (rbObjetivo.mass * 3);
                colisionador.material = null;
            }
        }
    }
}
