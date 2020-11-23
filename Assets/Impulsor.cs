using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Impulsor : MonoBehaviour
{
    public Text tipoDeChoque;
    public PhysicMaterial rubber;
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
        //tipoChoque = 2;
        objetivo = GameObject.FindGameObjectWithTag("objetivo");
        if (tipoChoque == 1)
        {
            tipoDeChoque.text = "Tipo de Choque: Elastico";
        }
        else if (tipoChoque == 2)
        {
            tipoDeChoque.text = "Tipo de Choque: Inelastico";
        }
        else if (tipoChoque == 3)
        {
            tipoDeChoque.text = "Tipo de Choque: Plastico";
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbObjetivo = objetivo.GetComponent<Rigidbody>();
        colisionador = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Debouncer"))
        {
            colisionador.material = null;
        }
        if (other.CompareTag("Choque"))
        {
            if (tipoChoque == 1)
            {
                colisionador.material = rubber;
                rbObjetivo.velocity = (rb.velocity * -1);
            }
            else if (tipoChoque == 2)
            {
                colisionador.material = rubber;
                rb.mass = (rbObjetivo.mass / 10);
                blocker = Instantiate(blocker, posSpawn.position, transform.rotation);
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
